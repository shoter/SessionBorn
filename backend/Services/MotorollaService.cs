using Services.DTOs.Motorllas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Services
{
    public class MotorollaService : IMotorollaService
    {
        public void DoRequest(MotorollaSimpleModel model)
        {
            GetPOSTResponse(new Uri("https://hacknarok.release.commandcentral.com/"), model, null);
        }

        private void GetPOSTResponse<TModel>(Uri uri, TModel data, Action<HttpWebResponse> callback)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);

            request.Method = "PUT";
            request.ContentType = "application/json;charset=utf-8";
            request.Headers.Add("Authorization", "Basic aTFXa2xtTkpIUWZZbEht");

            string json = new JavaScriptSerializer().Serialize(data);

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            byte[] bytes = encoding.GetBytes(json);

            request.ContentLength = bytes.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                // Send the data.
                requestStream.Write(bytes, 0, bytes.Length);
            }

            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
                //Now you have your response.
                //or false depending on information in the response
                if (responseText.Contains("successfully sent") == false)
                    throw new Exception("O nie. Coś poszło nie tak!");
            }
        }
    }
}
