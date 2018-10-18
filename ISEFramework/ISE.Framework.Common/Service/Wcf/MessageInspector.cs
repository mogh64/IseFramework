using ISE.Framework.Common.Aspects;
using ISE.Framework.Common.Service.Encoder;
// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using ISE.Framework.Common.Service.ServiceBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace ISE.Framework.Common.Service.Wcf
{
    public class MessageInspector : IClientMessageInspector, IDispatchMessageInspector
    {
        ClientCredentials crendentials = null;
        public MessageInspector(ClientCredentials credentials)
        {
            this.crendentials = credentials;
        }
        public MessageInspector()
        {
      
        }
        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
           
            LogManager.GetLogger().Debug("AfterReceiveReply");
           
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {

         
            LogManager.GetLogger().Debug("BeforeSendRequest");
            MessageBuffer buffer = request.CreateBufferedCopy(Int32.MaxValue);
            request = buffer.CreateMessage();

            ServiceHeader customData = new ServiceHeader();

            customData.KerberosID = ClientContextBucket.KerberosID;
            customData.SiteminderToken = ClientContextBucket.SiteminderToken;
            customData.UserID = ClientContextBucket.UserID;
            customData.UserToken = ClientContextBucket.UserHeaderToken;
            customData.VerificationCode = ClientContextBucket.VerificationCode;
            CustomHeader header = new CustomHeader(customData);

            // Add the custom header to the request.
            request.Headers.Add(header);

            return null;
        }

        public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
        {
            LogManager.GetLogger().Debug("AfterReceiveRequest");
            MessageBuffer buffer = request.CreateBufferedCopy(Int32.MaxValue);
            request = buffer.CreateMessage();
          //  System.ServiceModel.Channels.Message messageCopy = buffer.CreateMessage();

            // Read the custom context data from the headers
            ServiceHeader customData = CustomHeader.ReadHeader(request);

            // Add an extension to the current operation context so
            // that our custom context can be easily accessed anywhere.
            ServerContext customContext = new ServerContext();

            if (customData != null)
            {
                customContext.UserID = customData.UserID;
                customContext.KerberosID = customData.KerberosID;
                customContext.SiteminderToken = customData.SiteminderToken;
                customContext.UserHeaderToken = customData.UserToken;
                customContext.VerificationCode = customData.VerificationCode;
            }
            if (OperationContext.Current.IncomingMessageProperties.ContainsKey("CurrentContext"))
            {
                OperationContext.Current.IncomingMessageProperties.Remove("CurrentContext");
            }
            OperationContext.Current.IncomingMessageProperties.Add(
                     "CurrentContext", customContext);
            //*****************
            object result;
            request.Properties.TryGetValue(TextOrMtomEncodingBindingElement.IsIncomingMessageMtomPropertyName, out result);
            return result;
        }

        public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            LogManager.GetLogger().Debug("BeforeSendReply");
            OperationContext.Current.Extensions.Remove(ServerContext.Current);
            //************************
            bool isMtom = (correlationState is bool) && (bool)correlationState;
            reply.Properties.Add(TextOrMtomEncodingBindingElement.IsIncomingMessageMtomPropertyName, isMtom);
            if (isMtom)
            {
                string boundary = "uuid:" + Guid.NewGuid().ToString();
                string startUri = "http://tempuri.org/0";
                string startInfo = "application/soap+xml";
                string contentType = "multipart/related; type=\"application/xop+xml\";start=\"<" +
                    startUri +
                    ">\";boundary=\"" +
                    boundary +
                    "\";start-info=\"" +
                    startInfo + "\"";

                HttpResponseMessageProperty respProp;
                if (reply.Properties.ContainsKey(HttpResponseMessageProperty.Name))
                {
                    respProp = reply.Properties[HttpResponseMessageProperty.Name] as HttpResponseMessageProperty;
                }
                else
                {
                    respProp = new HttpResponseMessageProperty();
                    reply.Properties[HttpResponseMessageProperty.Name] = respProp;
                }

                respProp.Headers[HttpResponseHeader.ContentType] = contentType;
                respProp.Headers["MIME-Version"] = "1.0";

                reply.Properties[TextOrMtomEncodingBindingElement.MtomBoundaryPropertyName] = boundary;
                reply.Properties[TextOrMtomEncodingBindingElement.MtomStartInfoPropertyName] = startInfo;
                reply.Properties[TextOrMtomEncodingBindingElement.MtomStartUriPropertyName] = startUri;
            }
        }
    }
}
