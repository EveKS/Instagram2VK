namespace Instagram2VK.Services
{
    interface IMainService
    {
        string AutorizeString { get; }

        (string access_token, string expires_in, string user_id) GetUserInfo(string tokenString);
    }
}