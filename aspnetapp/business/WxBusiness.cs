using aspnetapp.models;
namespace aspnetapp.Business
{ 
    public class WxBusiness {
        public WxBusiness(string token, string url, string code)
        {
            Token = token;
            Url = url;
            Code = code;
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("https://api.weixin.qq.com/wxa/business/");
        }
        public string Token { get; set; }
        public string Url { get; set; }
        public string Code { get; set; }
        public HttpClient HttpClient { get; set; }

        public async Task<Response> GetResponse()
        {
            var response = new Response();
            var data = await HttpClient.PostAsync(Url, new FormUrlEncodedContent(new List<KeyValuePair<string,string>> { new KeyValuePair<string,string>("code", Code)  }));
            if (data.StatusCode.Equals(200)) {
                response.Data = data.Content;
            }   
            return response;
        }
    }
}