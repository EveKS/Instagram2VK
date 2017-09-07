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
        private readonly IMessageService _messegeService;

        public MainPresenter(IMain view,
            IInstagramService instagramService,
            IMessageService messegeService)
        {
            _view = view;
            _instagramService = instagramService;
            _messegeService = messegeService;

            _view.BLoadContent += _view_BLoadContent;
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
