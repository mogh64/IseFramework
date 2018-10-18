using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.IO;
using System.Net;
using System.Xml;

namespace ISE.Framework.Common.Service.Encoder
{
    public class TextOrMtomEncodingBindingElement : MessageEncodingBindingElement
    {
        public const string IsIncomingMessageMtomPropertyName = "IncomingMessageIsMtom";
        public const string MtomBoundaryPropertyName = "__MtomBoundary";
        public const string MtomStartInfoPropertyName = "__MtomStartInfo";
        public const string MtomStartUriPropertyName = "__MtomStartUri";

        MessageVersion messageVersion = MessageVersion.Default;

        public override MessageEncoderFactory CreateMessageEncoderFactory()
        {
            return new TextOrMtomEncoderFactory(this.messageVersion);
        }
        public override MessageVersion MessageVersion
        {
            get
            {
                return this.messageVersion;
            }
            set
            {
                this.messageVersion = value;
            }
        }
        public override BindingElement Clone()
        {
            return this;
        }
        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
        {
            context.BindingParameters.Add(this);
            return context.BuildInnerChannelFactory<TChannel>();
        }
        public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
        {
            context.BindingParameters.Add(this);
            return context.BuildInnerChannelListener<TChannel>();
        }
        public override bool CanBuildChannelFactory<TChannel>(BindingContext context)
        {
            return context.CanBuildInnerChannelFactory<TChannel>();
        }
        public override bool CanBuildChannelListener<TChannel>(BindingContext context)
        {
            return context.CanBuildInnerChannelListener<TChannel>();
        }
    }
   public class TextOrMtomEncoderFactory : MessageEncoderFactory
    {
        MessageVersion messageVersion;
        TextOrMtomEncoder encoder;

        public TextOrMtomEncoderFactory(MessageVersion messageVersion)
        {
            this.messageVersion = messageVersion;
            this.encoder = new TextOrMtomEncoder(messageVersion);
        }
        public override MessageEncoder Encoder
        {
            get
            {
                return this.encoder;
            }
        }
        public override MessageVersion MessageVersion
        {
            get
            {
                return this.encoder.MessageVersion;
            }
        }
    }
   public class TextOrMtomEncoder : MessageEncoder
    {
        MessageEncoder _textEncoder;
        MessageEncoder _mtomEncoder;
        public TextOrMtomEncoder(MessageEncoder messageEncoder)
            : base()
        {
            if (messageEncoder == null)
                throw new ArgumentNullException("messageEncoder", "A valid message encoder must be passed to the mtomEncoder");
            _textEncoder = new TextMessageEncodingBindingElement(messageEncoder.MessageVersion, Encoding.UTF8).CreateMessageEncoderFactory().Encoder;
            _mtomEncoder = new MtomMessageEncodingBindingElement(messageEncoder.MessageVersion, Encoding.UTF8).CreateMessageEncoderFactory().Encoder;
        }
        public TextOrMtomEncoder(MessageVersion messageVersion)
        {
            _textEncoder = new TextMessageEncodingBindingElement(messageVersion, Encoding.UTF8).CreateMessageEncoderFactory().Encoder;
            _mtomEncoder = new MtomMessageEncodingBindingElement(messageVersion, Encoding.UTF8).CreateMessageEncoderFactory().Encoder;
        }
        public override string ContentType
        {
            get
            {
                return _textEncoder.ContentType;
            }
        }
        public override string MediaType
        {
            get
            {
                return _textEncoder.MediaType;
            }
        }
        public override MessageVersion MessageVersion
        {
            get
            {
                return _textEncoder.MessageVersion;
            }
        }
        public override bool IsContentTypeSupported(string contentType)
        {
            return this._mtomEncoder.IsContentTypeSupported(contentType);
        }
        public override T GetProperty<T>()
        {
            T result = this._textEncoder.GetProperty<T>();
            if (result == null)
            {
                result = this._mtomEncoder.GetProperty<T>();
            }
            if (result == null)
            {
                result = base.GetProperty<T>();
            }
            return result;
        }
        public override System.ServiceModel.Channels.Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
        {
            System.ServiceModel.Channels.Message result = this._mtomEncoder.ReadMessage(buffer, bufferManager, contentType);
            result.Properties.Add(TextOrMtomEncodingBindingElement.IsIncomingMessageMtomPropertyName, IsMtomMessage(contentType));
            return result;
        }
        public override ArraySegment<byte> WriteMessage(System.ServiceModel.Channels.Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)
        {
            if (this.ShouldWriteMtom(message))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    XmlDictionaryWriter mtomWriter = CreateMtomWriter(ms, message);
                    message.WriteMessage(mtomWriter);
                    mtomWriter.Flush();
                    byte[] buffer = bufferManager.TakeBuffer((int)ms.Position + messageOffset);
                    Array.Copy(ms.GetBuffer(), 0, buffer, messageOffset, (int)ms.Position);
                    return new ArraySegment<byte>(buffer, messageOffset, (int)ms.Position);
                }
            }
            else
            {
                return this._textEncoder.WriteMessage(message, maxMessageSize, bufferManager, messageOffset);
            }
        }
        private static bool IsMtomMessage(string contentType)
        {
            return contentType.IndexOf("type=\"application/xop+xml\"", StringComparison.OrdinalIgnoreCase) >= 0;
        }
        private bool ShouldWriteMtom(System.ServiceModel.Channels.Message message)
        {
            object temp;
            return message.Properties.TryGetValue(TextOrMtomEncodingBindingElement.IsIncomingMessageMtomPropertyName, out temp) && (bool)temp;
        }
        private XmlDictionaryWriter CreateMtomWriter(Stream stream, System.ServiceModel.Channels.Message message)
        {
            string boundary = message.Properties[TextOrMtomEncodingBindingElement.MtomBoundaryPropertyName] as string;
            string startUri = message.Properties[TextOrMtomEncodingBindingElement.MtomStartUriPropertyName] as string;
            string startInfo = message.Properties[TextOrMtomEncodingBindingElement.MtomStartInfoPropertyName] as string;
            return XmlDictionaryWriter.CreateMtomWriter(stream, Encoding.UTF8, int.MaxValue, startInfo, boundary, startUri, false, false);
        }

        public override System.ServiceModel.Channels.Message ReadMessage(Stream stream, int maxSizeOfHeaders, string contentType)
        {
            System.ServiceModel.Channels.Message result = this._mtomEncoder.ReadMessage(stream, maxSizeOfHeaders, contentType);
            result.Properties.Add(TextOrMtomEncodingBindingElement.IsIncomingMessageMtomPropertyName, IsMtomMessage(contentType));
            return result;
        }
        public override void WriteMessage(System.ServiceModel.Channels.Message message, Stream stream)
        {
            if (ShouldWriteMtom(message))
            {
                XmlDictionaryWriter mtomWriter = CreateMtomWriter(stream, message);
                message.WriteMessage(mtomWriter);
            }
            else
            {
                _textEncoder.WriteMessage(message, stream);
            }
        }
    }
}
