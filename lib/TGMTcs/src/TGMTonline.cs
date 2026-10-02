using System;
using System.IO;
using System.Net;
#if !NET_35
using System.Net.Http;
#endif
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;


namespace TGMTcs
{
    public class TGMTonline
    {
        bool m_isWaitingMessage = true;
        public static event EventHandler<TGMTonlineArgs> onListenMessage;

        private static readonly HttpClient client = new HttpClient();

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ~TGMTonline()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsInternetAvailable(string url = "1.1.1.1")
        {
            try
            {
                using (var ping = new Ping())
                {
                    for (int i = 0; i < 3; i++) // Retry up to 3 times
                    {
                        var reply = ping.Send(url, 500);
                        if (reply == null)
                            return false;
                        if (reply.Status == IPStatus.Success)
                            return true;
                    }                    
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string SendGETrequestAsync(string request)
        {
            return "";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string SendGETrequest(string request)
        {

#if NET_35
            // Create a request for the URL. 		
            WebRequest httpRequest = WebRequest.Create(request);
            // If required by the server, set the credentials.
            httpRequest.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse();
            // Display the status.
            string StatusDescription = response.StatusDescription;
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;

#else
            try
            {
                using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
                {
                    WebRequest wrGETURL;
                    wrGETURL = WebRequest.Create(request);

                    WebProxy myProxy = new WebProxy("myproxy", 80);
                    myProxy.BypassProxyOnLocal = true;

                    wrGETURL.Proxy = WebProxy.GetDefaultProxy();

                    Stream objStream = wrGETURL.GetResponse().GetResponseStream();
                    StreamReader objReader = new StreamReader(objStream);

                    string respond = objReader.ReadToEnd();
                    return respond;
                }
            }
            catch(Exception ex)
            {
                return "";
            }            
#endif
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////


        public static async void SendGETrequest(string url, Action<int, string> callback, int timeout = 0)
        {
            Console.WriteLine($">>>> GET {DateTime.Now}");

            int statusCode;
            string responseString;

            try
            {
                HttpResponseMessage result;

                if (timeout > 0)
                {
                    using (var cts = new System.Threading.CancellationTokenSource())
                    {
                        cts.CancelAfter(TimeSpan.FromSeconds(timeout));
                        result = await client.GetAsync(url, cts.Token).ConfigureAwait(false);
                    }
                }
                else
                {
                    result = await client.GetAsync(url).ConfigureAwait(false);
                }

                using (result)
                {
                    statusCode = (int)result.StatusCode;
                    responseString = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
            }
            catch (TaskCanceledException ex)
            {
                statusCode = 408;
                responseString = BuildErrorJson(
                    timeout > 0
                        ? $"Request timeout after {timeout} seconds"
                        : "Request cancelled: " + ex.Message);
            }
            catch (HttpRequestException ex)
            {
                statusCode = 503;
                responseString = BuildErrorJson("Không kết nối được server: " + ex.Message);
            }
            catch (Exception ex)
            {
                statusCode = 399;
                responseString = BuildErrorJson("Không kết nối được server: " + ex.Message);
            }

            Console.WriteLine($"<<<< GET {DateTime.Now}");

            try
            {
                callback?.Invoke(statusCode, responseString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("SendGETrequest callback error: " + ex);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static async void SendPOSTrequest(string url, Dictionary<string, string> values, Action<int, string> callback, int timeout = 0)
        {
            Console.WriteLine($">>>> {DateTime.Now}");

            int statusCode;
            string responseString;

            try
            {
                var sb = new StringBuilder();

                foreach(var pair in values)
                {
                    if(sb.Length > 0)
                        sb.Append('&');

                    sb.Append(Uri.EscapeDataString(pair.Key));
                    sb.Append('=');

                    // Escape value in chunks to avoid Uri.EscapeDataString
                    // maximum input length.
                    sb.Append(EscapeDataStringLarge(pair.Value));
                }


                using(var content = new StringContent( sb.ToString(), Encoding.UTF8, "application/x-www-form-urlencoded")) 
                {
                    HttpResponseMessage result;

                    if(timeout > 0)
                    {
                        using(var cts = new System.Threading.CancellationTokenSource())
                        {
                            cts.CancelAfter(TimeSpan.FromSeconds(timeout));
                            result = await client.PostAsync(url, content, cts.Token).ConfigureAwait(false);
                        }
                    }
                    else
                    {
                        result = await client.PostAsync(url, content).ConfigureAwait(false);
                    }

                    using(result)
                    {
                        statusCode = (int)result.StatusCode;
                        responseString = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    }
                }
            }
            catch (TaskCanceledException ex)
            {
                statusCode = 408;
                responseString = BuildErrorJson(
                    timeout > 0
                        ? $"Request timeout after {timeout} seconds"
                        : "Request cancelled: " + ex.Message);
            }
            catch (HttpRequestException ex)
            {
                statusCode = 503;
                responseString = BuildErrorJson("Không kết nối được server: " + ex.Message);
            }
            catch (Exception ex)
            {
                statusCode = 399;
                responseString = BuildErrorJson("Không kết nối được server: " + ex.Message);
            }

            Console.WriteLine($"<<<< {DateTime.Now}");

            // callback nằm ngoài try của HTTP.
            // Exception trong callback không bị nhầm thành lỗi network.
            try
            {
                callback?.Invoke(statusCode, responseString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("SendPOSTrequest callback error: " + ex);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static string EscapeDataStringLarge(string value)
        {
            const int chunkSize = 1000;

            var sb = new StringBuilder();

            for(int i = 0; i < value.Length; i += chunkSize)
            {
                int length = Math.Min(chunkSize, value.Length - i);

                sb.Append(
                    Uri.EscapeDataString(value.Substring(i, length))
                );
            }

            return sb.ToString();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static string BuildErrorJson(string message)
        {
            if (message == null)
                message = "";

            message = message
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\r", "\\r")
                .Replace("\n", "\\n")
                .Replace("\t", "\\t");

            return "{\"Error\":\"" + message + "\"}";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        Socket m_socket;
        bool m_connectSuccess = false;
        public bool SetTargetSocket(string ip, int port)
        {
            try
            {
                m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ipAdd = IPAddress.Parse(ip);
                IPEndPoint remoteEP = new IPEndPoint(ipAdd, port);
                m_socket.Connect(remoteEP);

                m_connectSuccess = true;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                m_connectSuccess = false;
            }

            return m_connectSuccess;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string SendMessageToSocket(string msg, bool waitRespondMessage = false)
        {
            if (!m_connectSuccess)
                return "Error: Connection failed";

            try
            {
                //Start sending stuf..
                byte[] byData = Encoding.ASCII.GetBytes(msg);
                m_socket.Send(byData);
                if (waitRespondMessage)
                {
                    byte[] buffer = new byte[1024];
                    int iRx = m_socket.Receive(buffer);
                    char[] chars = new char[iRx];

                    Decoder d = Encoding.UTF8.GetDecoder();
                    int charLen = d.GetChars(buffer, 0, iRx, chars, 0);
                    string receive = new string(chars);

                    return receive;
                }
                else
                    return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void StartListening()
        {
            if (!m_connectSuccess)
                return;// "Error: Connection failed";
            Decoder decoder = Encoding.ASCII.GetDecoder();
            try
            {
                //begin connection
                byte[] byData = Encoding.ASCII.GetBytes("O");
                m_socket.Send(byData);
                while (m_isWaitingMessage)
                {
                    byte[] buffer = new byte[1024];
                    int iRx = m_socket.Receive(buffer);
                    char[] chars = new char[iRx];


                    int charLen = decoder.GetChars(buffer, 0, iRx, chars, 0);
                    string receive = new string(chars);

                    onListenMessage?.Invoke(null, new TGMTonlineArgs(receive));
                    Console.WriteLine(receive);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static async Task DownloadImageAsync(string url, string imagePathAbsToSave)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                if (string.IsNullOrWhiteSpace(imagePathAbsToSave)) throw new ArgumentNullException(nameof(imagePathAbsToSave));

                // Build URL (ensure no duplicate slashes)
                


                using (var response = await client.GetAsync((string)url, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false))
                {
                    response.EnsureSuccessStatusCode();

                    // Ensure directory exists
                    var dir = Path.GetDirectoryName(imagePathAbsToSave);
                    if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    using (var fileStream = new FileStream(imagePathAbsToSave, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        await responseStream.CopyToAsync((Stream)fileStream).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void DownloadImage(string url, string imagePathAbsToSave)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));
                if (string.IsNullOrWhiteSpace(imagePathAbsToSave)) throw new ArgumentNullException(nameof(imagePathAbsToSave));


                using (var response = client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead)
                                            .GetAwaiter().GetResult())
                {
                    response.EnsureSuccessStatusCode();

                    var dir = Path.GetDirectoryName(imagePathAbsToSave);
                    if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    using (var responseStream = response.Content.ReadAsStreamAsync().GetAwaiter().GetResult())
                    {
                        using (var fileStream = new FileStream(imagePathAbsToSave, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            responseStream.CopyTo(fileStream); // fully synchronous copy
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DownloadImage error: " + ex.Message);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void StopListening()
        {
            m_isWaitingMessage = false;
            if (m_socket.IsBound)
            {
                m_socket.Disconnect(false);
            }
            m_socket.Close();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class TGMTonlineArgs : EventArgs
        {
            public string message;

            public TGMTonlineArgs(string msg)
            {
                message = msg;
            }
        }
    }
}