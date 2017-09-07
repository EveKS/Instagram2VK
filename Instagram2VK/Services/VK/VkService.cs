using Instagram2VK.Services.Html;
using Instagram2VK.Services.Json;
using Instagram2VK.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram2VK.Services.VK
{
    partial class VkService : IVkService
    {
        private static Random _rnd;
        private IHtmlService _htmlService;
        private IJsonService _jsonService;

        public VkService()
        {
            _rnd = new Random();

            _htmlService = new HtmlService();
            _jsonService = new JsonService();
        }

        #region posting
        /// <summary>
        /// Постинг выбранных постов
        /// Загружаем нужные посты и информацию о них
        /// </summary>
        /// <param name="group_id"></param>
        /// <param name="timeFrom"></param>
        /// <param name="timeTo"></param>
        /// <param name="vkItems"></param>
        /// <returns></returns>
        async Task IVkService.SetWallAsync(string group_id, string access_token,
            int timeFrom, int timeTo,
            IEnumerable<VkItemViewModel> vkItems)
        {
            var addTime = 30 * 60;
            DateTime dateNow = DateTime.Now;
            long unixTime = ((DateTimeOffset)dateNow).ToUnixTimeSeconds();

            // берем посты из очереди, для определения времени публикаций
            var timeList = await GetTimePostAsync(access_token, "100", "0", $"-{group_id}", string.Empty);
            var count = timeList.Count;

            // Проверяем нет-ли в очереди больше 75 постов
            if (count < 75)
            {
                // настройка времени
                vkItems = SetTimeAsync(group_id, count, unixTime, addTime, timeList, timeFrom, timeTo, vkItems);

                foreach (var item in vkItems)
                {
                    var type = string.Empty;
                    if (item.DocExt?.FirstOrDefault() == "gif")
                    {
                        item.Photo = item.Gif;
                        type = "gif";
                    }

                    var wallPost = await WallPostAsync(access_token, group_id, item.Text, item.PublishDate.ToString(), type, item.Photo?.ToArray());

                    if (!string.IsNullOrWhiteSpace(wallPost) && !wallPost.Contains("error"))
                    {

                    }
                    else
                    {
                        //await _telegramService.SendMessage($"{user.UserName} error: {string.Concat(wallPost.Take(2500))}");

                        if (wallPost.Contains("can only schedule 25 posts on a day"))
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                //await _telegramService.SendMessage($"{user.UserName} длинна очереди более 75, отмена.");
            }
        }

        /// <summary>
        /// Менеджмент времени
        /// </summary>
        /// <param name="group_id"></param>
        /// <param name="count"></param>
        /// <param name="unixTime"></param>
        /// <param name="addTime"></param>
        /// <param name="timeList"></param>
        /// <param name="timeFrom"></param>
        /// <param name="timeTo"></param>
        /// <param name="vkItems"></param>
        /// <returns></returns>
        private IEnumerable<VkItemViewModel> SetTimeAsync(string group_id,
            int count,
            long unixTime,
            int addTime,
            List<long> timeList,
            int? timeFrom,
            int? timeTo,
            IEnumerable<VkItemViewModel> vkItems)
        {
            var length = 0;
            long timeBefore = unixTime;

            foreach (var item in vkItems)
            {
                if (timeFrom != null && timeTo != null)
                {
                    addTime = _rnd.Next(timeFrom.Value * 60, timeTo.Value * 60);
                }

                count = timeList.Count;

                var tmpTime = unixTime;
                if (count > 0 && timeList[0] > unixTime)
                {
                    var newTime = unixTime;
                    while (newTime < timeList[0])
                    {
                        var middle = (timeList[0] - newTime) / 2;
                        if (middle > (addTime - 60))
                        {
                            if (!timeList.Contains(newTime))
                            {
                                unixTime = newTime;
                                break;
                            }
                        }

                        newTime += addTime;
                    }
                }

                if (unixTime == tmpTime)
                {
                    for (int i = 0; i < count - 1; i++)
                    {
                        var newTime = timeList[i] + addTime;
                        var middle = (timeList[i + 1] - timeList[i]) / 2;
                        if (middle > (addTime - 60) &&
                            !timeList.Contains(newTime))
                        {
                            unixTime = newTime;
                            break;
                        }
                    }
                }

                if (tmpTime == unixTime)
                {
                    if (count > 0)
                    {
                        unixTime = timeList[count - 1] + addTime;
                    }
                    else
                    {
                        unixTime += addTime;
                    }
                }

                while (timeList.Contains(unixTime))
                {
                    unixTime += addTime;
                }

                timeList.Add(unixTime);
                timeList.Sort();

                item.PublishDate = unixTime;
                length++;
            }

            return vkItems;
        }

        #endregion
    }
}
