// developer mortaza ghahremani
// email: mortaza.ghahremani@gmail.com
// produced in august 2014
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Text;
using System.Threading;

namespace ISE.Framework.Common.Token
{
    public class TokenCache
    {
        private const int DefaultTimeout = 1000;
        private static Dictionary<Uri, SecurityToken> tokens = new Dictionary<Uri, SecurityToken>();
        private static ReaderWriterLock tokenLock = new ReaderWriterLock();
        private TokenCache()
        {
        }
        public static SecurityToken GetToken(Uri endpoint)
        {
            SecurityToken token = null;
            tokenLock.AcquireReaderLock(DefaultTimeout);
            try
            {
                tokens.TryGetValue(endpoint, out token);
                return token;
            }
            finally
            {
                tokenLock.ReleaseReaderLock();
            }
        }
        public static void AddToken(Uri endpoint, SecurityToken token)
        {
            tokenLock.AcquireWriterLock(DefaultTimeout);
            try
            {
                if (tokens.ContainsKey(endpoint))
                    tokens.Remove(endpoint);
                tokens.Add(endpoint, token);
            }
            finally
            {
                tokenLock.ReleaseWriterLock();
            }
        }
    }
}
