namespace Instagram2VK.Services.Message
{
    public interface IMessageService
    {
        void ShowError(string error);
        void ShowExclamation(string exlamation);
        void ShowMessage(string message);
    }
}
