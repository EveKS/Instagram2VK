using CsQuery;
using Instagram2VK.Services.Html;
using Instagram2VK.Services.Json;
using Instagram2VK.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Instagram2VK.JsonModel.InstagramNext;

namespace Instagram2VK.Services.Instagram
{
    class InstagramService : IInstagramService
    {
        const int COUNT = 12;
        private IHtmlService _htmlService;
        private IJsonService _jsonService;

        public InstagramService()
        {
            _htmlService = new HtmlService();
            _jsonService = new JsonService();
        }

        /// <summary>
        /// Получаем контент первой страници
        /// </summary>
        /// <param name="url"></param>
        /// <param name="queryId"></param>
        /// <returns></returns>
        async Task<InstagramLoadViewModel> IInstagramService.InstagramLoadAsync(string url)
        {
            var json = await GetInstagramJsonAsync(url);

            var instagram = _jsonService.JsonConvertDeserializeObject<Models.Instagram.Instagram>(json);

            var profiles = instagram?.EntryData?.ProfilePage;
            if (profiles == null)
            {
                return null;
            }

            var token = profiles.FirstOrDefault()?.User?.Media?.PageInfo?.EndCursor;
            if (string.IsNullOrWhiteSpace(token))
            {
                return null;
            }

            var owner = profiles.FirstOrDefault()?
                .User?.Media?.Nodes?.FirstOrDefault()?.Owner?.Id;
            if (string.IsNullOrWhiteSpace(owner))
            {
                return null;
            }

            var vkItemViewModels = profiles.SelectMany(prof =>
                     prof?.User?.Media?.Nodes?.Select(node => new VkItemViewModel
                     {
                         Likes = node?.EdgeMediaPreviewLike?.Count ?? node?.Likes.Count,
                         Coments = node?.EdgeMediaToComment?.Count ?? node.Comments?.Count,
                         Text = string.Join("\n", node?.EdgeMediaToCaption?.Edges?.Select(o => o?.Node?.Text) ?? new List<string> { node?.Caption }),
                         Photo = new List<string> { node?.DisplaySrc },
                         Date = node?.Date ?? node?.TakenAtTimestamp
                     }))
                    .ToList();

            var result = new InstagramLoadViewModel
            {
                Token = token,
                Owner = owner,
                VkItemViewModels = vkItemViewModels
            };

            return result;
        }

        /// <summary>
        /// Получаем контент кнопки NEXT
        /// </summary>
        /// <param name="url"></param>
        /// <param name="queryId"></param>
        /// <param name="owner"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        async Task<InstagramLoadViewModel> IInstagramService.InstagramNextAsync(string url, string queryId, string owner, string token)
        {
            var jsonNext = await GetNextJsonAsync(queryId, owner, COUNT, token);
            if (string.IsNullOrWhiteSpace(jsonNext))
            {
                return null;
            }

            var instagramNext = _jsonService.JsonConvertDeserializeObject<InstagramNext>(jsonNext);
            if (instagramNext.Status != "ok")
            {
                return new InstagramLoadViewModel
                {
                    Error = $"Instagram query error: {instagramNext.Message}"
                };
            }

            var media = instagramNext?.Data?.User?.EdgeOwnerToTimelineMedia;
            if (media == null)
            {
                return null;
            }

            var vkItemViewModels = media.Edges?.Select(prof =>
                new VkItemViewModel
                {
                    Likes = prof?.Node?.EdgeMediaPreviewLike?.Count,
                    Coments = prof?.Node?.EdgeMediaToComment?.Count,
                    Text = string.Join("\n", prof?.Node?.EdgeMediaToCaption?.Edges?.Select(o => o?.Node?.Text) ?? new List<string> { string.Empty }),
                    Photo = new List<string> { prof?.Node?.DisplayUrl },
                    Date = prof?.Node?.TakenAtTimestamp
                })
                .ToList();

            if (media.PageInfo?.HasNextPage == true)
            {
                token = media.PageInfo?.EndCursor;
            }
            else
            {
                token = null;
            }

            var result = new InstagramLoadViewModel
            {
                Token = token,
                Owner = owner,
                VkItemViewModels = vkItemViewModels
            };

            return result;
        }

        /// <summary>
        /// Получить первый JSON страници
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<string> GetInstagramJsonAsync(string url)
        {
            string json = null;

            url = CreateInstagramUriString(url);

            var html = await _htmlService.GetAsync(url);
            CQ cq = CQ.Create(html);
            json = cq["body script"]
                .FirstOrDefault(js => js.TextContent.Contains("_sharedData"))
                .TextContent.Replace("window._sharedData =", string.Empty)
                .TrimEnd(';');

            return json;
        }

        /// <summary>
        /// Эмуляция нажатия кнопки NEXT и получение JSON ответа
        /// </summary>
        /// <param name="query_id"></param>
        /// <param name="id"></param>
        /// <param name="first"></param>
        /// <param name="after"></param>
        /// <returns></returns>
        private async Task<string> GetNextJsonAsync(string query_id, string id, int first, string after)
        {
            string json = null;

            // https://www.instagram.com/graphql/query/?query_id=17888483320059182&variables={"id":"1187237132","first":100,"after":"AQAuVsBTXbqB0J2eDJholKSRf09-4yPON6WHTbM-0_UN9xSSEB67yHZwaCOPhQcTEYHXx6XmIljj3xUJaV-WnlV9EkFTzhXz0bBWCj2O45nMoA"}
            var query = JsonConvert.SerializeObject(new { id = id, first = first, after = after });

            var url = $@"https://www.instagram.com/graphql/query/?query_id={query_id}&variables={query}";
            json = await _htmlService.GetAsync(url);

            return json;
        }

        /// <summary>
        /// Формируем строку запроса
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string CreateInstagramUriString(string url)
        {
            if (!url.Contains(@"instagram.com"))
            {
                url = $@"https://www.instagram.com/{url}/?hl=ru";
            }

            return url;
        }
    }
}
