using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace rSysServer
{
    public class RestApiServer : HttpServer
    {
        private Data data;

        public RestApiServer(IPAddress ipAddress, int port)
            : base(ipAddress, port)
        {
            this.data = new Data();
            this.data.Start();
        }

        public override void HandleGETRequest(HttpProcessor p)
        {
            Console.WriteLine("request: {0}", p.HttpUrl);

            if (p.HttpUrl.ToLower().StartsWith("/api/"))
            {
                p.WriteSuccess("application/json");
                switch (this.MatchEndpoint(p.HttpUrl.ToLower()))
                {
                    case ApiEndPoint.All:
                        p.OutputStream.WriteLine(this.data.ToJson());
                        break;
                    case ApiEndPoint.CpuUsage:
                        this.ParseUrlAndWriteToOutputStream(this.data.CpuUsage, p);
                        break;
                    case ApiEndPoint.Memory:
                        p.OutputStream.WriteLine(this.data.Memory.ToJson());
                        break;
                    case ApiEndPoint.PhysicalDisks:
                        this.ParseUrlAndWriteToOutputStream(this.data.PhysicalDisks, p);
                        break;
                    case ApiEndPoint.LogicalDisks:
                        this.ParseUrlAndWriteToOutputStream(this.data.LogicalDisks, p);
                        break;
                    case ApiEndPoint.NetworkAdapters:
                        this.ParseUrlAndWriteToOutputStream(this.data.NetworkAdapters, p);
                        break;
                    case ApiEndPoint.Load:
                        p.OutputStream.WriteLine(this.data.Load.ToJson());
                        break;
                    case ApiEndPoint.Processes:
                        p.OutputStream.WriteLine(this.data.Processes.ToJson());
                        break;
                    case ApiEndPoint.AvailableMethods:
                        p.OutputStream.WriteLine(Enum.GetNames(typeof(ApiEndPoint)).ToJson());
                        break;
                    case ApiEndPoint.SystemInformations:
                        p.OutputStream.WriteLine(this.data.SystemInformations.ToJson());
                        break;
                }
            }
            else
            {
                p.WriteFailure();
            }
        }

        private void ParseUrlAndWriteToOutputStream<T>(List<T> source, HttpProcessor p)
        {
            Regex regex = new Regex("/api/[a-z]*/(?<name>([# \\-a-z0-9]+))", RegexOptions.IgnoreCase);
            Group match = regex.Match(HttpUtility.UrlDecode(p.HttpUrl).ToLower()).Groups["name"];
            if (match.Success)
            {
                T item = source.Find(x => { return x.ToString().StartsWith("Instance: " + match.Value); });
                if (item != null)
                {
                    rSysServer.Utilities.DebugOutput(p.HttpUrl.ToLower() + ": " + item.ToString());
                    p.OutputStream.WriteLine(item.ToJson());
                    return;
                }
            }
            rSysServer.Utilities.DebugOutput(p.HttpUrl.ToLower() + ": " + source.ToPrettyString());
            p.OutputStream.WriteLine(source.ToJson());
        }

        public override void HandlePOSTRequest(HttpProcessor p, StreamReader inputData)
        {
            Console.WriteLine("POST request: {0}", p.HttpUrl);
            p.WriteFailure();
        }

        private ApiEndPoint MatchEndpoint(string url)
        {
            foreach (ApiEndPoint item in Enum.GetValues(typeof(ApiEndPoint)))
            {
                if (url.StartsWith("/api/" + item.ToString().ToLower()))
                {
                    return item;
                }
            }

            return ApiEndPoint.All;
        }
    }

}



/*p.WriteSuccess();
p.OutputStream.WriteLine("<html><body><h1>test server</h1>");
p.OutputStream.WriteLine("Current Time: " + DateTime.Now.ToString());
p.OutputStream.WriteLine("url : {0}", p.HttpUrl);
p.OutputStream.WriteLine("ip : {0}", p.ClientIpAddress);

p.OutputStream.WriteLine("<form method=post action=/form>");
p.OutputStream.WriteLine("<input type=text name=foo value=foovalue>");
p.OutputStream.WriteLine("<input type=submit name=bar value=barvalue>");
p.OutputStream.WriteLine("</form>");*/



/*string data = inputData.ReadToEnd();
p.WriteSuccess();
p.OutputStream.WriteLine("<html><body><h1>test server</h1>");
p.OutputStream.WriteLine("<a href=/test>return</a><p>");
p.OutputStream.WriteLine("postbody: <pre>{0}</pre>", data);*/