using System.Net.Http;
using System.Collections.Generic;
public class webApi
{
    public static string MyUsername{set; get;}
    public static string FrindUsername{set; get;}
    public static string sendData(string Url , Dictionary<string , string> data)
    {
        using (HttpClient Client = new HttpClient())
        {
            FormUrlEncodedContent Content = new FormUrlEncodedContent(data);
            HttpResponseMessage Response = Client.PostAsync(Url, Content).Result;
            return Response.Content.ReadAsStringAsync().Result;
        }
    }
}