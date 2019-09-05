using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WebServerUsingSocket
{
    public class HTTPListener
    {
        public bool IsListening { get; set; }

        public static readonly string Version = "HTTP/1.1";
        public static readonly object Name = "C# Http Server";
        private Socket _serverSocket;
        private static IPAddress[] temp = Dns.GetHostEntry("localhost").AddressList;
        private IPAddress _ipAddress = Dns.GetHostEntry("localhost").AddressList[temp.Length-1];
        private IPEndPoint _ipEndPoint;
        public HTTPListener(int port)
        {
            _serverSocket = new Socket(_ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Debug.WriteLine($"IP Address is {_ipAddress}");
            _ipEndPoint = new IPEndPoint(_ipAddress, port);
            IsListening = false;

        }
        public void Start()
        {
            IsListening = true;
            _serverSocket.Bind(_ipEndPoint);
            _serverSocket.Listen(10);

            Console.WriteLine("Waiting for connection");
        }
        public void Stop()
        {
            IsListening = false;
        }
        public HTTPListenerContext GetContext()
        {
            Socket _clientSocket = _serverSocket.Accept();
            NetworkStream networkStream = new NetworkStream(_clientSocket);
            StreamReader streamReader = new StreamReader(networkStream);
            String Message = "";
            while (streamReader.Peek() != -1)
            {
                Message += streamReader.ReadLine() + "\n";
            }
            
            Debug.WriteLine("Request: \n" + Message+"\n end");
            HTTPListenerRequest hTTPRequest = HTTPRequestParser.GetHTTPRequest(Message);
            HTTPListenerResponse response = new HTTPListenerResponse(networkStream,hTTPRequest);
            if (hTTPRequest == null)
            {
                return null;
            }
            return new HTTPListenerContext(_clientSocket,hTTPRequest,response);
        }
    }

    internal class HTTPRequestParser
    {
        public static HTTPListenerRequest GetHTTPRequest(String request)
        {
            if (String.IsNullOrEmpty(request))
                return null;
            String[] tokens = request.Split(' ', '\n');
            String type = tokens[0];
            String url = tokens[1];
            String host = tokens[4];
            String referer = "";
            string body = "";
            Debug.WriteLine(request);
            for (int index = 0; index < tokens.Length; index++)
            {
                if (tokens[index] == "Referer:")
                {
                    referer = tokens[index + 1];
                    break;
                }
            }
            Console.WriteLine(String.Format("type : {0} url : {1} @ host : {2} \nReferer: {3}", type, url, host, referer));

            return new HTTPListenerRequest(new Uri("http://"+host+url),type,body);
        }
    }
}
