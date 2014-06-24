#region -- Copyrights --
// ***********************************************************************
// Simple HTTP Server in C#
// by David Jeske
//
// http://www.codeproject.com/Articles/137979/Simple-HTTP-Server-in-C
//
// The Code Project Open License (CPOL) 1.02 (http://www.codeproject.com/info/cpol10.aspx)
// ***********************************************************************
// Preamble
// 
// This License governs Your use of the Work. This License is intended to allow developers to use the Source Code and Executable Files provided as part of the Work in any application in any form.
// 
// The main points subject to the terms of the License are:
// 
//     Source Code and Executable Files can be used in commercial applications;
//     Source Code and Executable Files can be redistributed; and
//     Source Code can be modified to create derivative works.
//     No claim of suitability, guarantee, or any warranty whatsoever is provided. The software is provided "as-is".
//     The Article(s) accompanying the Work may not be distributed or republished without the Author's consent
// 
// This License is entered between You, the individual or other entity reading or otherwise making use of the Work licensed pursuant to this License and the individual or other entity which offers the Work under the terms of this License ("Author").
// ***********************************************************************
// License
// 
// THE WORK (AS DEFINED BELOW) IS PROVIDED UNDER THE TERMS OF THIS CODE PROJECT OPEN LICENSE ("LICENSE"). THE WORK IS PROTECTED BY COPYRIGHT AND/OR OTHER APPLICABLE LAW. ANY USE OF THE WORK OTHER THAN AS AUTHORIZED UNDER THIS LICENSE OR COPYRIGHT LAW IS PROHIBITED.
// 
// BY EXERCISING ANY RIGHTS TO THE WORK PROVIDED HEREIN, YOU ACCEPT AND AGREE TO BE BOUND BY THE TERMS OF THIS LICENSE. THE AUTHOR GRANTS YOU THE RIGHTS CONTAINED HEREIN IN CONSIDERATION OF YOUR ACCEPTANCE OF SUCH TERMS AND CONDITIONS. IF YOU DO NOT AGREE TO ACCEPT AND BE BOUND BY THE TERMS OF THIS LICENSE, YOU CANNOT MAKE ANY USE OF THE WORK.
// 
//     Definitions.
//         "Articles" means, collectively, all articles written by Author which describes how the Source Code and Executable Files for the Work may be used by a user.
//         "Author" means the individual or entity that offers the Work under the terms of this License.
//         "Derivative Work" means a work based upon the Work or upon the Work and other pre-existing works.
//         "Executable Files" refer to the executables, binary files, configuration and any required data files included in the Work.
//         "Publisher" means the provider of the website, magazine, CD-ROM, DVD or other medium from or by which the Work is obtained by You.
//         "Source Code" refers to the collection of source code and configuration files used to create the Executable Files.
//         "Standard Version" refers to such a Work if it has not been modified, or has been modified in accordance with the consent of the Author, such consent being in the full discretion of the Author.
//         "Work" refers to the collection of files distributed by the Publisher, including the Source Code, Executable Files, binaries, data files, documentation, whitepapers and the Articles.
//         "You" is you, an individual or entity wishing to use the Work and exercise your rights under this License.
//     Fair Use/Fair Use Rights. Nothing in this License is intended to reduce, limit, or restrict any rights arising from fair use, fair dealing, first sale or other limitations on the exclusive rights of the copyright owner under copyright law or other applicable laws.
//     License Grant. Subject to the terms and conditions of this License, the Author hereby grants You a worldwide, royalty-free, non-exclusive, perpetual (for the duration of the applicable copyright) license to exercise the rights in the Work as stated below:
//         You may use the standard version of the Source Code or Executable Files in Your own applications.
//         You may apply bug fixes, portability fixes and other modifications obtained from the Public Domain or from the Author. A Work modified in such a way shall still be considered the standard version and will be subject to this License.
//         You may otherwise modify Your copy of this Work (excluding the Articles) in any way to create a Derivative Work, provided that You insert a prominent notice in each changed file stating how, when and where You changed that file.
//         You may distribute the standard version of the Executable Files and Source Code or Derivative Work in aggregate with other (possibly commercial) programs as part of a larger (possibly commercial) software distribution.
//         The Articles discussing the Work published in any form by the author may not be distributed or republished without the Author's consent. The author retains copyright to any such Articles. You may use the Executable Files and Source Code pursuant to this License but you may not repost or republish or otherwise distribute or make available the Articles, without the prior written consent of the Author.
//     Any subroutines or modules supplied by You and linked into the Source Code or Executable Files of this Work shall not be considered part of this Work and will not be subject to the terms of this License.
//     Patent License. Subject to the terms and conditions of this License, each Author hereby grants to You a perpetual, worldwide, non-exclusive, no-charge, royalty-free, irrevocable (except as stated in this section) patent license to make, have made, use, import, and otherwise transfer the Work.
//     Restrictions. The license granted in Section 3 above is expressly made subject to and limited by the following restrictions:
//         You agree not to remove any of the original copyright, patent, trademark, and attribution notices and associated disclaimers that may appear in the Source Code or Executable Files.
//         You agree not to advertise or in any way imply that this Work is a product of Your own.
//         The name of the Author may not be used to endorse or promote products derived from the Work without the prior written consent of the Author.
//         You agree not to sell, lease, or rent any part of the Work. This does not restrict you from including the Work or any part of the Work inside a larger software distribution that itself is being sold. The Work by itself, though, cannot be sold, leased or rented.
//         You may distribute the Executable Files and Source Code only under the terms of this License, and You must include a copy of, or the Uniform Resource Identifier for, this License with every copy of the Executable Files or Source Code You distribute and ensure that anyone receiving such Executable Files and Source Code agrees that the terms of this License apply to such Executable Files and/or Source Code. You may not offer or impose any terms on the Work that alter or restrict the terms of this License or the recipients' exercise of the rights granted hereunder. You may not sublicense the Work. You must keep intact all notices that refer to this License and to the disclaimer of warranties. You may not distribute the Executable Files or Source Code with any technological measures that control access or use of the Work in a manner inconsistent with the terms of this License.
//         You agree not to use the Work for illegal, immoral or improper purposes, or on pages containing illegal, immoral or improper material. The Work is subject to applicable export laws. You agree to comply with all such laws and regulations that may apply to the Work after Your receipt of the Work.
//     Representations, Warranties and Disclaimer. THIS WORK IS PROVIDED "AS IS", "WHERE IS" AND "AS AVAILABLE", WITHOUT ANY EXPRESS OR IMPLIED WARRANTIES OR CONDITIONS OR GUARANTEES. YOU, THE USER, ASSUME ALL RISK IN ITS USE, INCLUDING COPYRIGHT INFRINGEMENT, PATENT INFRINGEMENT, SUITABILITY, ETC. AUTHOR EXPRESSLY DISCLAIMS ALL EXPRESS, IMPLIED OR STATUTORY WARRANTIES OR CONDITIONS, INCLUDING WITHOUT LIMITATION, WARRANTIES OR CONDITIONS OF MERCHANTABILITY, MERCHANTABLE QUALITY OR FITNESS FOR A PARTICULAR PURPOSE, OR ANY WARRANTY OF TITLE OR NON-INFRINGEMENT, OR THAT THE WORK (OR ANY PORTION THEREOF) IS CORRECT, USEFUL, BUG-FREE OR FREE OF VIRUSES. YOU MUST PASS THIS DISCLAIMER ON WHENEVER YOU DISTRIBUTE THE WORK OR DERIVATIVE WORKS.
//     Indemnity. You agree to defend, indemnify and hold harmless the Author and the Publisher from and against any claims, suits, losses, damages, liabilities, costs, and expenses (including reasonable legal or attorneys’ fees) resulting from or relating to any use of the Work by You.
//     Limitation on Liability. EXCEPT TO THE EXTENT REQUIRED BY APPLICABLE LAW, IN NO EVENT WILL THE AUTHOR OR THE PUBLISHER BE LIABLE TO YOU ON ANY LEGAL THEORY FOR ANY SPECIAL, INCIDENTAL, CONSEQUENTIAL, PUNITIVE OR EXEMPLARY DAMAGES ARISING OUT OF THIS LICENSE OR THE USE OF THE WORK OR OTHERWISE, EVEN IF THE AUTHOR OR THE PUBLISHER HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES.
//     Termination.
//         This License and the rights granted hereunder will terminate automatically upon any breach by You of any term of this License. Individuals or entities who have received Derivative Works from You under this License, however, will not have their licenses terminated provided such individuals or entities remain in full compliance with those licenses. Sections 1, 2, 6, 7, 8, 9, 10 and 11 will survive any termination of this License.
//         If You bring a copyright, trademark, patent or any other infringement claim against any contributor over infringements You claim are made by the Work, your License from such contributor to the Work ends automatically.
//         Subject to the above terms and conditions, this License is perpetual (for the duration of the applicable copyright in the Work). Notwithstanding the above, the Author reserves the right to release the Work under different license terms or to stop distributing the Work at any time; provided, however that any such election will not serve to withdraw this License (or any other license that has been, or is required to be, granted under the terms of this License), and this License will continue in full force and effect unless terminated as stated above.
//     Publisher. The parties hereby confirm that the Publisher shall not, under any circumstances, be responsible for and shall not have any liability in respect of the subject matter of this License. The Publisher makes no warranty whatsoever in connection with the Work and shall not be liable to You or any party on any legal theory for any damages whatsoever, including without limitation any general, special, incidental or consequential damages arising in connection to this license. The Publisher reserves the right to cease making the Work available to You at any time without notice
//     Miscellaneous
//         This License shall be governed by the laws of the location of the head office of the Author or if the Author is an individual, the laws of location of the principal place of residence of the Author.
//         If any provision of this License is invalid or unenforceable under applicable law, it shall not affect the validity or enforceability of the remainder of the terms of this License, and without further action by the parties to this License, such provision shall be reformed to the minimum extent necessary to make such provision valid and enforceable.
//         No term or provision of this License shall be deemed waived and no breach consented to unless such waiver or consent shall be in writing and signed by the party to be charged with such waiver or consent.
//         This License constitutes the entire agreement between the parties with respect to the Work licensed herein. There are no understandings, agreements or representations with respect to the Work not specified herein. The Author shall not be bound by any additional provisions that may appear in any communication from You. This License may not be modified without the mutual written agreement of the Author and You.
// ***********************************************************************
#endregion
using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace rSysServer
{
    public class HttpProcessor
    {
        private const int BUF_SIZE = 4096;
        private static int MAX_POST_SIZE = 10 * 1024 * 1024; // 10MB

        public TcpClient Socket;
        public HttpServer Server;

        private Stream inputStream;
        public StreamWriter OutputStream;

        public string HttpMethod;
        public string HttpUrl;
        public string HttpProtocolVersion;
        public string ClientIpAddress;
        public Hashtable HttpHeaders;

        public HttpProcessor(TcpClient socket, HttpServer server)
        {
            this.Socket = socket;
            this.Server = server;
            this.HttpHeaders = new Hashtable();
        }

        private string streamReadLine(Stream inputStream)
        {
            int nextChar;
            string data = "";
            while (true)
            {
                nextChar = inputStream.ReadByte();
                if (nextChar == '\n') { break; }
                if (nextChar == '\r') { continue; }
                if (nextChar == -1) { Thread.Sleep(1); continue; };
                data += Convert.ToChar(nextChar);
            }

            return data;
        }

        public void Process()
        {
            // we can't use a StreamReader for input, because it buffers up extra data on us inside it's
            // "processed" view of the world, and we want the data raw after the headers
            this.inputStream = new BufferedStream(this.Socket.GetStream());

            // we probably shouldn't be using a streamwriter for all output from handlers either
            this.OutputStream = new StreamWriter(new BufferedStream(this.Socket.GetStream()));
            try
            {
                this.ParseRequest();
                this.ReadHeaders();
                if (this.HttpMethod.Equals("GET"))
                {
                    this.HandleGETRequest();
                }
                else if (this.HttpMethod.Equals("POST"))
                {
                    this.HandlePOSTRequest();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.ToString());
                this.WriteFailure();
            }
            this.OutputStream.Flush();
            // bs.Flush(); // flush any remaining output
            this.inputStream = null;
            this.OutputStream = null;
            this.Socket.Close();
        }

        public void ParseRequest()
        {
            string request = this.streamReadLine(this.inputStream);
            string[] tokens = request.Split(' ');
            if (tokens.Length != 3)
            {
                throw new Exception("invalid http request line");
            }
            this.HttpMethod = tokens[0].ToUpper();
            this.HttpUrl = tokens[1];
            this.HttpProtocolVersion = tokens[2];
            this.ClientIpAddress = ((IPEndPoint)this.Socket.Client.RemoteEndPoint).Address.ToString();

            Console.WriteLine("starting: " + request);
            Console.WriteLine("ClientIP: " + this.ClientIpAddress);

        }

        public void ReadHeaders()
        {
            Console.WriteLine("readHeaders()");
            string line;
            while ((line = this.streamReadLine(this.inputStream)) != null)
            {
                if (line.Equals(""))
                {
                    Console.WriteLine("got headers");
                    return;
                }

                int separator = line.IndexOf(':');
                if (separator == -1)
                {
                    throw new Exception("invalid http header line: " + line);
                }
                string name = line.Substring(0, separator);
                int pos = separator + 1;
                while ((pos < line.Length) && (line[pos] == ' '))
                {
                    pos++; // strip any spaces
                }

                string value = line.Substring(pos, line.Length - pos);
                Console.WriteLine("header: {0}:{1}", name, value);
                this.HttpHeaders[name] = value;
            }
        }

        public void HandleGETRequest()
        {
            this.Server.HandleGETRequest(this);
        }

        public void HandlePOSTRequest()
        {
            // this post data processing just reads everything into a memory stream.
            // this is fine for smallish things, but for large stuff we should really
            // hand an input stream to the request processor. However, the input stream 
            // we hand him needs to let him see the "end of the stream" at this content 
            // length, because otherwise he won't know when he's seen it all! 

            Console.WriteLine("get post data start");
            int contentLength = 0;
            MemoryStream ms = new MemoryStream();
            if (this.HttpHeaders.ContainsKey("Content-Length"))
            {
                contentLength = Convert.ToInt32(this.HttpHeaders["Content-Length"]);
                if (contentLength > MAX_POST_SIZE)
                {
                    throw new Exception(string.Format("POST Content-Length({0}) too big for this simple server", contentLength));
                }
                byte[] buf = new byte[BUF_SIZE];
                int toRead = contentLength;
                while (toRead > 0)
                {
                    Console.WriteLine("starting Read, to_read={0}", toRead);

                    int numread = this.inputStream.Read(buf, 0, Math.Min(BUF_SIZE, toRead));
                    Console.WriteLine("read finished, numread={0}", numread);
                    if (numread == 0)
                    {
                        if (toRead == 0)
                        {
                            break;
                        }
                        else
                        {
                            throw new Exception("client disconnected during post");
                        }
                    }
                    toRead -= numread;
                    ms.Write(buf, 0, numread);
                }
                ms.Seek(0, SeekOrigin.Begin);
            }
            Console.WriteLine("get post data end");
            this.Server.HandlePOSTRequest(this, new StreamReader(ms));
        }

        public void WriteSuccess(string contentType = "text/html")
        {
            this.OutputStream.WriteLine("HTTP/1.1 200 OK");
            this.OutputStream.WriteLine("Content-Type: " + contentType);
            this.OutputStream.WriteLine("Connection: close");
            this.OutputStream.WriteLine("");
        }

        public void WriteFailure()
        {
            this.OutputStream.WriteLine("HTTP/1.1 404 File not found");
            this.OutputStream.WriteLine("Connection: close");
            this.OutputStream.WriteLine("");
        }
    }
}
