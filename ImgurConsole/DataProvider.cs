using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Authentication;
using Imgur.API.Models.Impl;
using System.Web.Script.Serialization;
using System.Net;
using Imgur.API.Endpoints.Impl;

namespace ImgurConsole
{

    public class DataProvider
    {
        const string ClientId = "59b901759d20a52";
        const string ClientSecret = "9fa708a1d20975d47e425c255ebd60acc49c2b58";
        ImgurClient imgurClient;
        OAuth2Endpoint endpoint;
        public string authorizationUri;


        Image ImgurImage;
        
        public DataProvider()
        {
            //GetPin(ClientId, ClientSecret);
            //imgurClient = new ImgurClient(ClientId, ClientSecret);
            //ImgurImage = new Image();
            //endpoint = new OAuth2Endpoint(imgurClient);
            //authorizationUri = endpoint.GetAuthorizationUrl(Imgur.API.Enums.OAuth2ResponseType.Token);
        }
        public static string GetPin(string clientId, string clientSecret)
        {
            string OAuthUrlTemplate = "https://api.imgur.com/oauth2/authorize?client_id={0}&response_type={1}&state={2}";
            string RequestUrl = String.Format(OAuthUrlTemplate, clientId, "pin", "ok");
            string Pin = String.Empty;

            // Promt the user to browse to that URL or show the Webpage in your application
            // ... 

            return Pin;
        }

        public static ImgurToken GetToken(string clientId, string clientSecret, string pin)
        {
            string Url = "https://api.imgur.com/oauth2/token/";
            string DataTemplate = "client_id={0}&client_secret={1}&grant_type=pin&pin={2}";
            string Data = String.Format(DataTemplate, clientId, clientSecret, pin);

            using (WebClient Client = new WebClient())
            {
                string ApiResponse = Client.UploadString(Url, Data);

                // Use some random JSON Parser, you´ll get access_token and refresh_token
                var Deserializer = new JavaScriptSerializer();
                var Response = Deserializer.DeserializeObject(ApiResponse) as Dictionary<string, object>;

                return new ImgurToken()
                {
                    AccessToken = Convert.ToString(Response["access_token"]),
                    RefreshToken = Convert.ToString(Response["refresh_token"])
                };
            }
        }
    }

    public class ImgurToken
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
