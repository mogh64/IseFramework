using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ISE.Framework.Common.Service
{
    [DataContract]
    public class UserHeaderToken
    {
        public UserHeaderToken()
        {
            Token = string.Empty;
        }
        public void Clear()
        {
            this.Token = string.Empty;
        }
        [DataMember]
        public string Token { get; set; }
        public void Add(string key, string value)
        {
            string text =  CreateSection(key, value);
            if (!ContainKey(key))
               this.Token += text;
            else
            {
                Replace(key, value);
            }
        }
        public void Remove(string key)
        {
            string newToken = string.Empty;
            string[] textList =  this.Token.Split(';');
            for (int i = 0; i < textList.Length; i++)
            {
                string value = textList[i];
                string[] vals = value.Split(':');
                if (vals.Count() == 2)
                {
                    if (vals[0] != key) {
                        newToken += CreateSection(vals[0], vals[1]);
                    }
                }
            }
            Token = newToken;
        }
        public bool ContainKey(string key)
        {
           
            string[] textList = this.Token.Split(';');
            for (int i = 0; i < textList.Length; i++)
            {
                string value = textList[i];
                string[] vals = value.Split(':');
                if (vals.Count() == 2)
                {
                    if (vals[0] == key)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void Replace(string key, string value)
        {
           string oldValue = GetValue(key);
           string oldPair = string.Format("{0}:{1}", key, oldValue);
           string newPir = string.Format("{0}:{1}", key, value);
           this.Token = this.Token.Replace(oldPair, newPir);
        }
        public string GetValue(string key)
        {
            string keyValue = "";
            string[] textList = this.Token.Split(';');
            for (int i = 0; i < textList.Length; i++)
            {
                string value = textList[i];
                string[] vals = value.Split(':');
                if (vals.Count() == 2)
                {
                    if (vals[0] == key)
                    {
                        keyValue = vals[1];
                        break;
                    }
                }
            }
            return keyValue;
        }
        private string CreateSection(string key, string value)
        {
            string text = string.Format("{0}:{1};",key,value);
            return text;
        }
    }
}
