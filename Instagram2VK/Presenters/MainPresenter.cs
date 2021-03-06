﻿using Instagram2VK.Services;
using Instagram2VK.Services.Instagram;
using Instagram2VK.Services.Message;
using Instagram2VK.Services.VK;
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
        private readonly IVkService _vkService;
        private readonly IMessageService _messegeService;

        private string access_token;
        private string user_id;
        private string expires_in;

        private bool isNext;

        private string token;
        private string owner;
        private IEnumerable<VkItemViewModel> vkItems;

        public MainPresenter(IMain view,
            IInstagramService instagramService,
            IMainService mainService,
            IVkService vkService,
            IMessageService messegeService)
        {
            _view = view;
            _instagramService = instagramService;
            _mainService = mainService;
            _vkService = vkService;
            _messegeService = messegeService;

            _view.BLoadContentEvent += _view_BLoadContent;
            _view.BGetTockenEvent += _view_BGetTocken;
            _view.BGenerateTockenEvent += _view_BGenerateTocken;
            _view.BPostToVKEvent += _view_BPostToVKEvent;

            _vkService.AppendProgressMaxValue += _vkService_AppendProgressMaxValue;
            _vkService.AppendProgressMessage += _vkService_AppendProgressMessage;
            _vkService.AppendProgressValue += _vkService_AppendProgressValue;
        }

        private void _vkService_AppendProgressValue(object sender, EventArgs e)
        {
            if (sender is int)
            {
                _view.SetMessageValue = (int)sender;
            }
        }

        private void _vkService_AppendProgressMessage(object sender, EventArgs e)
        {
            if (sender is string)
            {
                _view.SetMessageProgress = (string)sender;
            }
        }

        private void _vkService_AppendProgressMaxValue(object sender, EventArgs e)
        {
            if (sender is int)
            {
                _view.SetMessageMaxValue = (int)sender;
            }
        }

        private async void _view_BPostToVKEvent(object sender, EventArgs e)
        {
            try
            {
                _view.ToggleBtnLoadContent = false;
                _view.ToggleBtnPostToVK = false;

                var groupId = _view.VkGroup;
                if (string.IsNullOrWhiteSpace(groupId))
                {
                    _messegeService.ShowExclamation("Укажите ВК группу");
                    return;
                }

                int timeFrom, timeTo;
                if(!int.TryParse(_view.TimeFrom, out timeFrom))
                {
                    _messegeService.ShowExclamation("Введите корректное значение времени между постами");
                    return;
                }

                if (!int.TryParse(_view.TimeTo, out timeTo))
                {
                    _messegeService.ShowExclamation("Введите корректное значение времени между постами");
                    return;
                }

                // filters
                vkItems = vkItems.Where(item =>
                   !item.Text.Contains("www") && !item.Text.Contains("http") &&
                   !item.Text.Contains(".blog"));

                groupId = _mainService.GetDomainString(groupId);

                await _vkService.SetWallAsync(groupId, access_token, timeFrom, timeTo, vkItems);
            }
            catch (Exception ex)
            {
                _messegeService.ShowError(ex.Message);
            }
            finally
            {
                _view.ToggleBtnLoadContent = true;
                _view.ToggleBtnPostToVK = true;
            }
        }

        private void _view_BGetTocken(object sender, EventArgs e)
        {
            try
            {
                _view.ToggleBtnGetToken = false;

                var responseString = _view.Browser.Url.AbsoluteUri;
                var userInfo = _mainService.GetUserInfo(responseString);

                access_token = userInfo.access_token;
                _view.Token = access_token;

                user_id = userInfo.user_id;
                _view.UserId = user_id;

                expires_in = userInfo.expires_in;
                _view.ExpiresIn = expires_in;
            }
            catch (Exception ex)
            {
                _messegeService.ShowError(ex.Message);
            }
            finally
            {
                _view.ToggleBtnGetToken = true;
                _view.ToggleBtnLoadContent = true;
            }
        }

        private void _view_BGenerateTocken(object sender, EventArgs e)
        {
            try
            {
                _view.ToggleBtnGenerateTocken = false;

                _view.Browser.ScriptErrorsSuppressed = true;
                _view.Browser.Navigate(_mainService.AutorizeString);

                _view.TabContainer.SelectTab("tabBrowser");
            }
            catch (Exception ex)
            {
                _messegeService.ShowError(ex.Message);
            }
            finally
            {
                _view.ToggleBtnGenerateTocken = true;
                _view.ToggleBtnGetToken = true;
            }
        }

        private async void _view_BLoadContent(object sender, EventArgs e)
        {
            try
            {
                _view.ToggleBtnLoadContent = false;
                InstagramLoadViewModel contentLoad = null;

                var instagramPage = _view.InstagramPage;
                if (string.IsNullOrWhiteSpace(instagramPage))
                {
                    _messegeService.ShowExclamation("Укажите страницу инстаграм");
                    return;
                }

                if (isNext)
                {
                    var queryId = _view.QueryId;
                    if (string.IsNullOrWhiteSpace(queryId))
                    {
                        _messegeService.ShowExclamation("Укажите query_id");
                        return;
                    }

                    contentLoad = await _instagramService.InstagramNextAsync(instagramPage, queryId, owner, token);
                }
                else
                {
                    contentLoad = await _instagramService.InstagramLoadAsync(instagramPage);
                    isNext = true;
                }

                if (contentLoad != null)
                {
                    token = contentLoad.Token;
                    _view.IToken = token;

                    owner = contentLoad.Owner;
                    _view.IOwner = owner;

                    vkItems = contentLoad.VkItemViewModels;
                }
            }
            catch (Exception ex)
            {
                _messegeService.ShowError(ex.Message);
            }
            finally
            {
                _view.ToggleBtnPostToVK = true;
                _view.ToggleBtnLoadContent = true;
                _view.BtnLoadContentText = "Загрузить еще";
                _view.ToggleBtnLoadContent = true;
            }
        }
    }
}
