using System;
using System.IO;
using System.Net.Sockets;

namespace WebServerUsingSocket
{
    public class HTTPListenerResponse
    {
        public NetworkStream OutputStream { get; }
        public string ContentType { get; set; }
        public int StatusCode { get; set; }
        public long ContentLength64{get;set;}

        public HTTPListenerResponse(NetworkStream stream, HTTPListenerRequest request)
        {
            OutputStream = stream;
        }
        public void Write(Byte[] _data)
        {
            StreamWriter streamWriter = new StreamWriter(OutputStream);
            try
            {
                streamWriter.WriteLine(String.Format("{0} {1}\r\nServer: {2}\r\nContent-Type: {3}\r\nAccept-Ranges: bytes\r\nContent-Length: {4}\r\n"
                                                 , HTTPListener.Version, StatusCode, HTTPListener.Name, ContentType, _data.Length));
                streamWriter.Flush();
                OutputStream.Write(_data, 0, _data.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                OutputStream.Dispose();
            }
        }
    }
}