namespace Instagram2VK.Services
{
    interface IMainService
    {
        string AutorizeString { get; }

        string GetDomainString(string groupId);
        (string access_token, string expires_in, string user_id) GetUserInfo(string tokenString);
    }
}