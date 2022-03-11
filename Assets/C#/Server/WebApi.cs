using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
public class webApi
{
    public static string MyUsername{set; get;}
    public static string FrindUsername{set; get;}
    public static async Task<string> sendData(string Url , Dictionary<string , string> data)
    {
        return await Task<string>.Run(()=>
        {
            using (HttpClient Client = new HttpClient())
            {
                FormUrlEncodedContent Content = new FormUrlEncodedContent(data);
                HttpResponseMessage Response = Client.PostAsync(Url, Content).Result;
                return Response.Content.ReadAsStringAsync().Result;
            }
        });
    }
}