using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace WebServerUsingSocket
{
    public class HTTPListenerContext
    {
        public HTTPListenerRequest Request { get; }
        public HTTPListenerResponse Response { get; }
        public Socket Socket { get;  }

        public HTTPListenerContext(Socket socket, HTTPListenerRequest request,HTTPListenerResponse response)
        {
            Request = request;
            Response = response;
            Socket = socket;
        } 
    }
}
