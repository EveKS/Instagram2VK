using Instagram2VK.Services;
using Instagram2VK.Services.Instagram;
using Instagram2VK.Services.Message;
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
            _view.BGenerateTocken += _view_BGenerateTocken;
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
            var contentLoad = await _instagramService.InstagramLoadAsync(_view.InstagramPage);
            if(contentLoad != null)
            {

            }
        }
    }
}
