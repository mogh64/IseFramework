using ISE.Framework.Utility.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ISE.Framework.Common.Service.Wcf
{
    public class CustomHeader : MessageHeader
    {
        private const string CUSTOM_HEADER_NAME = "ISEHeader";
        private const string External_CUSTOM_HEADER_NAME = "ExtISEHeader";
        private const string CUSTOM_HEADER_NAMESPACE = "http://www.iseikco.com/";

        private ServiceHeader _customData;

        public ServiceHeader CustomData
        {
            get
            {
                return _customData;
            }
        }

        public CustomHeader()
        {
        }

        public CustomHeader(ServiceHeader customData)
        {
            _customData = customData;
        }

        public override string Name
        {
            get { return (CUSTOM_HEADER_NAME); }
        }

        public override string Namespace
        {
            get { return (CUSTOM_HEADER_NAMESPACE); }
        }

        protected override void OnWriteHeaderContents(
            System.Xml.XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ServiceHeader));
            StringWriter textWriter = new StringWriter();
            serializer.Serialize(textWriter, _customData);
            textWriter.Close();

            string text = textWriter.ToString();

            writer.WriteElementString(CUSTOM_HEADER_NAME, "Key", text.Trim());
        }

        public static ServiceHeader ReadHeader(System.ServiceModel.Channels.Message request)
        {
            Int32 headerPosition = request.Headers.FindHeader(CUSTOM_HEADER_NAME, CUSTOM_HEADER_NAMESPACE);
            if (headerPosition == -1)
            {
                // this header is for external request for example ikco
                Int32 extHeaderPosition = request.Headers.FindHeader(External_CUSTOM_HEADER_NAME, CUSTOM_HEADER_NAMESPACE);
                if(extHeaderPosition==-1)
                    return null;
                MessageHeaderInfo extHeaderInfo = request.Headers[extHeaderPosition];

                XmlNode[] extContent = request.Headers.GetHeader<XmlNode[]>(extHeaderPosition);




                ServiceHeader customExternalData = XmlSerializerHelper.DeserializeNodes<ServiceHeader>(extContent);
                return customExternalData;
            }
                

            MessageHeaderInfo headerInfo = request.Headers[headerPosition];

            XmlNode[] content = request.Headers.GetHeader<XmlNode[]>(headerPosition);

            string text = content[0].InnerText;

            XmlSerializer deserializer = new XmlSerializer(typeof(ServiceHeader));
            TextReader textReader = new StringReader(text);
            ServiceHeader customData = (ServiceHeader)deserializer.Deserialize(textReader);
            textReader.Close();

            return customData;
        }
    }
}
