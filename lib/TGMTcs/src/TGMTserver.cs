using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace TGMTcs
{
    public class TGMTserver
    {
        private static TGMTserver _instance;
        private readonly object _sync = new object();
        private HttpListener _listener;
        private Thread _listenerThread;
        DateTime _lastRequest = DateTime.MinValue;
        string state = "";

        public delegate void OnGetRequestHandler(HttpListenerRequest req, HttpListenerResponse res);
        public OnGetRequestHandler onGetRequest;

        public delegate void OnPostRequestHandler(HttpListenerRequest req, HttpListenerResponse res);
        public OnPostRequestHandler onPostRequest;

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static TGMTserver GetInstance()
        {
            if(_instance == null)
            {
                _instance = new TGMTserver();
            }
            return _instance;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Start(int port=80)
        {
            lock (_sync)
            {
                if (_listener != null)
                    return;

                var listener = new HttpListener();
                listener.Prefixes.Add($"http://+:{port}/");
                listener.Start();

                _listener = listener;

                _listenerThread = new Thread(() => ListenLoop(listener));
                _listenerThread.IsBackground = true;
                _listenerThread.Start();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Stop()
        {
            HttpListener listener;

            lock (_sync)
            {
                listener = _listener;
                _listener = null;
                _listenerThread = null;
            }

            listener?.Close();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ListenLoop(HttpListener listener)
        {
            try
            {
                while (listener.IsListening)
                {
                    var context = listener.GetContext();
                    ThreadPool.QueueUserWorkItem(_ => HandleRequest(context));
                }
            }
            catch (HttpListenerException)
            {
                // Listener was stopped, exit the loop
            }
            catch (ObjectDisposedException)
            {
                // Listener was disposed, exit the loop
            }
            catch (Exception ex)
            {
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        void HandleRequest(HttpListenerContext ctx)
        {
            _lastRequest = DateTime.Now;
            try
            {
                var req = ctx.Request;
                var res = ctx.Response;
#if DEBUG
                Console.WriteLine($"REQUEST → {req.HttpMethod} {req.Url.AbsolutePath}");
#endif
                //timeFromLastRequestSeconds = 0;
                _lastRequest = DateTime.Now;
                state = "Connected";


                if(req.HttpMethod == "POST")
                {
                    HandlePost(req, res);
                }
                else if(req.HttpMethod == "GET")
                {
                    HandleGet(req, res);
                }
                else
                {
                    res.StatusCode = 404;
                    res.Close();
                }
            }
            catch(Exception ex)
            {
#if DEBUG
                Console.WriteLine("ERROR: " + ex.Message);
#endif
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        void HandleGet(HttpListenerRequest req, HttpListenerResponse res)
        {
            //string snFromDevice = req.QueryString["SN"];

            if(onGetRequest != null)
            {
                onGetRequest(req, res);                
            }
            else
            {
                WriteText(res, "OK");
            }   
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        void HandlePost(HttpListenerRequest req, HttpListenerResponse res)
        {
            string path = req.Url.AbsolutePath.ToLower();
#if DEBUG
            Console.WriteLine($"POST to {path}");
#endif
            state = "Connected";
//            using(var reader = new StreamReader(req.InputStream, req.ContentEncoding))
//            {
//                string body = reader.ReadToEnd();
//#if DEBUG
//                Console.WriteLine(">>>" + body);
//#endif
//            }

            if(onPostRequest != null)
            {
                onPostRequest(req, res);
            }
            else
            {
                WriteText(res, "OK");
                res.Close();    
            }                
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void WriteText(HttpListenerResponse res, string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);

            res.StatusCode = 200;
            res.ProtocolVersion = HttpVersion.Version11;
            res.KeepAlive = false;
            res.SendChunked = false;
            res.ContentType = "text/plain";
            res.ContentLength64 = buffer.Length;

            res.OutputStream.Write(buffer, 0, buffer.Length);
            res.OutputStream.Close();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Dictionary<string, string> GetParam(HttpListenerRequest req)
        {
            Dictionary<string, string> postParams = new Dictionary<string, string>();
            using(var reader = new StreamReader(req.InputStream, req.ContentEncoding))
            {
                string body = reader.ReadToEnd();
                var parsedParams = HttpUtility.ParseQueryString(body);
                foreach(string key in parsedParams.AllKeys)
                {
                    postParams[key] = parsedParams[key];
                }
            }

            return postParams;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string GetClientIp(HttpListenerRequest req)
        {
            string xForwardedFor = req.Headers["X-Forwarded-For"];
            if(!string.IsNullOrWhiteSpace(xForwardedFor))
            {
                string forwardedIp = xForwardedFor.Split(',')[0].Trim();
                if(!string.IsNullOrWhiteSpace(forwardedIp))
                    return forwardedIp;
            }

            string xRealIp = req.Headers["X-Real-IP"];
            if(!string.IsNullOrWhiteSpace(xRealIp))
                return xRealIp.Trim();

            string ip = req.RemoteEndPoint?.Address?.ToString() ?? "";

            if(ip == "::1")
                return "127.0.0.1";

            if(ip.StartsWith("::ffff:"))
                return ip.Substring(7);

            return ip;
        }
    }
}
