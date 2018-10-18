/**
 * File name: GZipMessageEncoder.cs 
 * Author: Mosfiqur.Rahman
 * Date: 11/12/2009 3:54:04 PM format: MM/dd/yyyy
 * 
 * 
 * Modification history:
 * Name				Date					Desc
 * 
 *  
 * Version: 1.0
 * */

#region Using Directives

using ISE.Framework.Common.Aspects;
using System;
using System.IO;
using System.IO.Compression;
using System.ServiceModel.Channels;

#endregion

namespace WcfExtensions
{
    public class BinaryMessageEncoder : MessageEncoder
    {
        #region Members & Variables

        static string BinaryContentType = "application/soap+msbin1";
        
        

        //This implementation wraps an inner encoder that actually converts a WCF Message
        //into textual XML, binary XML or some other format. This implementation then compresses the results.
        //The opposite happens when reading messages.
        //This member stores this inner encoder.
        MessageEncoder innerEncoder;

        #endregion

        #region Constructors

        //We require an inner encoder to be supplied (see comment above)
        public BinaryMessageEncoder(MessageEncoder messageEncoder)
            : base()
        {
            if (messageEncoder == null)
                throw new ArgumentNullException("messageEncoder", "A valid message encoder must be passed to the GZipEncoder");
            innerEncoder = messageEncoder;
        }

        #endregion

        #region Properties

        public override string ContentType
        {
            get { return BinaryContentType; }
        }

        public override string MediaType
        {
            get { return BinaryContentType; }
        }

        //SOAP version to use - we delegate to the inner encoder for this
        public override MessageVersion MessageVersion
        {
            get { return innerEncoder.MessageVersion; }
        }

        #endregion

        #region Methods 

        //Helper method to compress an array of bytes
    

        #endregion

        #region MessageEncoder Members

        //One of the two main entry points into the encoder. Called by WCF to decode a buffered byte array into a Message.
        public override Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
        {           

            var returnMessage = innerEncoder.ReadMessage(buffer, bufferManager);
            returnMessage.Properties.Encoder = this;
            LogManager.GetLogger().Debug("innerEncoderReadMessage");
            return returnMessage;
        }

        //One of the two main entry points into the encoder. Called by WCF to encode a Message into a buffered byte array.
        public override ArraySegment<byte> WriteMessage(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)
        {
            //Use the inner encoder to encode a Message into a buffered byte array
            var buffer = innerEncoder.WriteMessage(message, maxMessageSize, bufferManager, messageOffset);
            LogManager.GetLogger().Debug("innerEncoderWriteMessage");
            //Compress the resulting byte array

            return buffer;
           
        }

        public override Message ReadMessage(Stream stream, int maxSizeOfHeaders, string contentType)
        {           
            return innerEncoder.ReadMessage(stream, maxSizeOfHeaders);
        }

        public override void WriteMessage(Message message, System.IO.Stream stream)
        {
           
            innerEncoder.WriteMessage(message, stream);
           
            // stream, so we need to flush here.
            stream.Flush();
        }

        #endregion
    }
}

// end of namespace
