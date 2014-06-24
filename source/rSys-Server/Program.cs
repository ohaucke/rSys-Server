using System.Net;
using System.Threading;

namespace rSysServer
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpServer httpServer = new RestApiServer(IPAddress.Parse("127.0.0.1"), 8080);
            Thread thread = new Thread(new ThreadStart(httpServer.Listen));
            thread.Start();
        }
    }
}
