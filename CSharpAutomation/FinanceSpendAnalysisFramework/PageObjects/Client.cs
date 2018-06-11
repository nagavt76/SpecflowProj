using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web;

public enum Verb

{

    GET,

    POST,

    PUT,

    DELETE

}

namespace FinanceSpendAnalysisFramework.PageObjects
{
    class PaymentCass
    {
        public string cust_id { get; set; }
        public int amt { get; set; }
        public string type { get; set; }
        public string date { get; set; }
        public string desc { get; set; }
    }
    public class Client

    {

        public string EndPoint { get; set; }

        public Verb Method { get; set; }

        public string ContentType { get; set; }

        public string PostData { get; set; }

        public HttpStatusCode responseCode { get; set; }

        public string responseValue { get; set; }

        

        public Client()

        {

            EndPoint = "";

            Method = Verb.GET;

            ContentType = "application/JSON";

            PostData = "";

        }

        public Client(string endpoint, Verb method, string postData)

        {

            EndPoint = endpoint;

            Method = method;

            ContentType = "text/json";

            PostData = postData;

        }

        public string Request()

        {

            return Request("");

        }

        public string Request(string parameters)

        {

            var request = (HttpWebRequest)WebRequest.Create(EndPoint + parameters);

            request.Method = Method.ToString();

            request.ContentLength = 0;

            request.ContentType = ContentType;

            using (var response = (HttpWebResponse)request.GetResponse())

            {

                responseValue = string.Empty;

                responseCode = response.StatusCode;

                if (response.StatusCode != HttpStatusCode.OK)

                {

                    var message = String.Format("Faile: Received HTTP {0}", response.StatusCode);

                    throw new ApplicationException(message);

                }

                using (var responseStream = response.GetResponseStream())

                {

                    if (responseStream != null)

                        using (var reader = new StreamReader(responseStream))

                        {

                            responseValue = reader.ReadToEnd();

                        }

                }

                var Currentfolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                var FileName = Path.Combine(Currentfolder, "ApiResponse.json");
                File.WriteAllText(FileName, responseValue);

                return responseValue;

            }



        }

        public void ReadJsonResponse()
        {
            var Currentfolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var FileName = Path.Combine(Currentfolder, "ApiResponse.json");
            string jsonFileContent=File.ReadAllText(FileName);
            dynamic stuff = JsonConvert.DeserializeObject(jsonFileContent);
            Console.WriteLine("json deserialized value is" + stuff.RestResponse.result[1].country);
        }

        public void BuildJson(string custId, int amt, string type, string date, string desc)
        {
            PaymentCass jsonClass = new PaymentCass();

            jsonClass.cust_id = custId;
            jsonClass.amt = amt;
            jsonClass.date = date;
            jsonClass.desc = desc;
            jsonClass.type = type;

            var json = JsonConvert.SerializeObject(jsonClass);

            var Currentfolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var FileName = Path.Combine(Currentfolder, "buildjson.json");
            File.WriteAllText(FileName, json);

        }

        
        public static void UpdatePaymentApi(string url)
        {
            try
            {
                var httpWebRequest =
                    (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                /*httpWebRequest.Headers["Authorization"] =
                    "Basic " + Convert.ToBase64String(
                        Encoding.Default.GetBytes("EBI_Service_User:EBI_Service_User@123"));*/

                string Currentfolder="";
                string FileName = "";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    Currentfolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    
                    FileName = Path.Combine(Currentfolder, "jsonmsg.json");
                    string json = File.ReadAllText(FileName);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Console.WriteLine(result);
                    Currentfolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    
                    FileName = Path.Combine(Currentfolder, "ApiResponse.json");
                    File.WriteAllText(FileName, result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        
    }
}
