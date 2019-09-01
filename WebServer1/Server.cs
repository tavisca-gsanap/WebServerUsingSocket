using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WebServerUsingSocket
{
    public class Server
    {
        public HTTPListener Listener { get; set; }
        public WebAppList WebAppList { get; }

        public Server(WebAppList webAppList)
        {
            WebAppList = webAppList;
        }
    }
}
