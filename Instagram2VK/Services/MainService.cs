using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Instagram2VK.Services
{
    class MainService : IMainService
    {
        #region options
        const string client_id = "5979140";
        const string redirect_uri = "https://oauth.vk.com/blank.html";
        const string display = "page";
        const string scope = "offline,groups,photos,wall,docs";
        const string response_type = "token";
        const string version = "5.67";
        #endregion

        public string AutorizeString =>
            $@"https://oauth.vk.com/authorize?client_id={client_id}&display={display}&redirect_uri={redirect_uri}&scope={scope}&response_type={response_type}&v={version}";

        (string access_token, string expires_in, string user_id) IMainService.GetUserInfo(string tokenString)
        {
            string access_token =
                @"(access_token)=(?<access_token>[^&]+)";
            string expires_in =
                @"(expires_in)=(?<expires_in>[^&]+)";
            string user_id =
                @"(user_id)=(?<user_id>[^&]+)";

            var accessToken = Regex.Matches(tokenString, access_token, RegexOptions.CultureInvariant)
                .OfType<Match>()
                .Select(m => m.Groups["access_token"].Value)
                .FirstOrDefault();

            var expiresIn = Regex.Matches(tokenString, expires_in, RegexOptions.CultureInvariant)
                .OfType<Match>()
                .Select(m => m.Groups["expires_in"].Value)
                .FirstOrDefault();

            var userId = Regex.Matches(tokenString, user_id, RegexOptions.CultureInvariant)
                .OfType<Match>()
                .Select(m => m.Groups["user_id"].Value)
                .FirstOrDefault();

            return (accessToken, userId, expiresIn);
        }
    }
}
