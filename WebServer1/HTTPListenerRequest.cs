using System;
using System.IO;

namespace WebServerUsingSocket
{
    public class HTTPListenerRequest
    {
        public Uri Url { get; }
        public string HttpMethod { get; }
        public string ContentType { get; }

        public string Content { get; }

        public HTTPListenerRequest(Uri uri,string httpMethod,string content)
        {
            Url = uri;
            HttpMethod = httpMethod;
            ContentType = null;
            Content = content;
        }
    }
}