using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Discord.Net
{
    public class DiscordLoginClient
    {
        public async Task<string> LoginWithEmailAndPasswordAsync(string Email, string Password)
        {
            var url = "https://discordapp.com/api/v6/auth/login";
            var client = new HttpClient();
            var reqm = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url),
            };
            reqm.Content = new StringContent(

                JsonConvert.SerializeObject(new
                {
                    email = Email,
                    password = Password
                }),
                Encoding.UTF8,
                "application/json");
            var response = await client.SendAsync(reqm);
            var responseString = await response.Content.ReadAsStringAsync();
            var responseDic = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseString);
            if (responseDic.ContainsKey("captcha_key"))
            {
                return "Invalid Email";
            }
            if (responseDic.ContainsKey("password"))
            {
                return "Password does not match";
            }
            return responseDic["token"];
        }

    }
}
