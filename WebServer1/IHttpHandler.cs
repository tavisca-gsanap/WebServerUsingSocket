using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WebServerUsingSocket
{
    public interface IHttpHandler
    {
        void Handle(WebApp webApp, HTTPListenerContext HTTPListenerContext);
    }
}
