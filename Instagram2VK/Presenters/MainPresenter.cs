using Instagram2VK.Services;
using Instagram2VK.Services.Instagram;
using Instagram2VK.Services.Message;
using Instagram2VK.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram2VK.Presenters
{
    class MainPresenter
    {
        private readonly IMain _view;
        private readonly IInstagramService _instagramService;
        private readonly IMainService _mainService;
        private readonly IMessageService _messegeService;

        private string access_token;
        private string user_id;
        private string expires_in;

        private string token;
        private string owner;
        private IEnumerable<VkItemViewModel> vkItems;

        public MainPresenter(IMain view,
            IInstagramService instagramService,
            IMainService mainService,
            IMessageService messegeService)
        {
            _view = view;
            _instagramService = instagramService;
            _mainService = mainService;
            _messegeService = messegeService;

            _view.BLoadContent += _view_BLoadContent;
            _view.BGetTocken += _view_BGetTocken;
            _view.BGenerateTocken += _view_BGenerateTocken;
        }

        private void _view_BGetTocken(object sender, EventArgs e)
        {
            _view.TogleBtnGetToken = false;
            var responseString = _view.Browser.Url.AbsoluteUri;
            var userInfo = _mainService.GetUserInfo(responseString);

            access_token = userInfo.access_token;
            _view.Token = access_token;

            user_id = userInfo.user_id;
            _view.UserId = user_id;

            expires_in = userInfo.expires_in;
            _view.ExpiresIn = expires_in;

            _view.TogleBtnGetToken = true;
            _view.TogleBtnLoadContent = true;
        }

        private void _view_BGenerateTocken(object sender, EventArgs e)
        {
            _view.Browser.ScriptErrorsSuppressed = true;
            _view.Browser.Navigate(_mainService.AutorizeString);

            _view.TabContainer.SelectTab("tabBrowser");
            _view.TogleBtnGenerateTocken = false;
            _view.TogleBtnGetToken = true;
        }

        private async void _view_BLoadContent(object sender, EventArgs e)
        {
            _view.TogleBtnLoadContent = false;
            var contentLoad = await _instagramService.InstagramLoadAsync(_view.InstagramPage);
            if(contentLoad != null)
            {
                token = contentLoad.Token;
                _view.IToken = token;

                owner = contentLoad.Owner;
                _view.IOwner = owner;

                vkItems = contentLoad.VkItemViewModels;
            }

            _view.TogleBtnLoadContent = true;
        }
    }
}
