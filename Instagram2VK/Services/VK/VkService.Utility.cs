using Instagram2VK.JsonModel.VK;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Instagram2VK.Services.VK
{
    partial class VkService
    {
        const string VERSION = "5.67";
        const int DELAY = 1000 / 3 + 9;

        private async Task<List<long>> GetTimePostAsync(string access_token, string count, string offset, string owner_id, string domain)
        {
            var url = "https://api.vk.com/method/wall.get";
            var values = new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("access_token", access_token),
                        new KeyValuePair<string, string>("offset", offset),
                        new KeyValuePair<string, string>("count", count),
                        new KeyValuePair<string, string>("filter", "postponed"),
                        new KeyValuePair<string, string>("v", VERSION)
                    };

            if (!string.IsNullOrWhiteSpace(owner_id.Trim('-')))
            {
                values.Add(new KeyValuePair<string, string>("owner_id", owner_id));
            }
            else
            {
                values.Add(new KeyValuePair<string, string>("domain", domain));
            }

            using (var formContent = new FormUrlEncodedContent(values))
            {
                var result = await _htmlService.PostAsync(url, formContent);
                if (!result.Contains("error"))
                {
                    var response = _jsonService.JsonConvertDeserializeObjectWithNull<WallGetResponse>(result);

                    return response?.Response?.Items?.Select(it => it.Date)
                        .Where(date => date != 0).ToList();
                }
            }

            return null;
        }

        /// <summary>
        /// Запостить сообщение
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="group_id"></param>
        /// <param name="message"></param>
        /// <param name="publish_date_unixtime"></param>
        /// <param name="photo_url"></param>
        /// <returns></returns>
        private async Task<string> WallPostAsync(string access_token, string group_id, string message, string publish_date_unixtime, string type, params string[] file_url)
        {
            string result = string.Empty;

            var url = "https://api.vk.com/method/wall.post";

            var attachments = new List<string>(10);
            if (file_url != null && file_url.All(o => !string.IsNullOrWhiteSpace(o)))
            {
                foreach (var file in file_url)
                {
                    if (string.IsNullOrWhiteSpace(type))
                    {
                        type = Path.GetExtension(file);
                    }

                    var saveWallfile = await SaveWallFileAsync(access_token, group_id, file, type);

                    attachments.Add(string.Join(",", JObject.Parse(saveWallfile)["response"]
                        .Select(o => $"{(type == "gif" ? "doc" : "photo")}{o["owner_id"]}_{o["id"]}")));
                }
            }

            var content = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("access_token", access_token),
                    new KeyValuePair<string, string>("owner_id", $"-{group_id}"),
                    new KeyValuePair<string, string>("message", message),
                    new KeyValuePair<string, string>("publish_date", publish_date_unixtime),
                    new KeyValuePair<string, string>("v", VERSION)
                };


            if (attachments.Any(o => o != null))
            {
                content.Add(new KeyValuePair<string, string>("attachments", string.Join(",", attachments)));
            }

            using (var formContent = new FormUrlEncodedContent(content))
            {
                result = await HttpPostAsync(url, formContent);
            }

            return result;
        }

        private async Task<string> SaveWallFileAsync(string access_token, string group_id, string file_url, string file_type)
        {
            var result = string.Empty;
            var method = file_type.Contains("gif") ? "docs.getWallUploadServer" : "photos.getWallUploadServer";

            //upload_url, album_id, user_id
            var uploadServer = await FileGetWallUploadServerAsync(access_token, group_id, method);

            var upload_url = (string)JObject.Parse(uploadServer)["response"]?["upload_url"];
            var album_id = (string)JObject.Parse(uploadServer)["response"]?["album_id"];
            var user_id = (string)JObject.Parse(uploadServer)["response"]?["user_id"];

            if (!string.IsNullOrWhiteSpace(upload_url))
            {
                var uploadedFiles = await UploadFilesAsync(access_token, file_url, upload_url, file_type);
                //server, photo, hash
                if (file_type != "gif")
                {
                    var server = (string)JObject.Parse(uploadedFiles)["server"];
                    var photo = (string)JObject.Parse(uploadedFiles)["photo"];
                    var hash = (string)JObject.Parse(uploadedFiles)["hash"];

                    result = await SaveWallFileAsync(access_token, group_id,
                        photo, server, hash,
                        null);
                }
                else
                {
                    var file = (string)JObject.Parse(uploadedFiles)["file"];

                    result = await SaveWallFileAsync(access_token, group_id,
                        null, null, null,
                        file);
                }
            }

            return result;
        }

        private async Task<string> SaveWallFileAsync(string access_token, string group_id,
            string photo, string server, string hash,
            string file)
        {
            var result = string.Empty;

            var url = "https://api.vk.com/method/";

            var content = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("access_token", access_token),
                    new KeyValuePair<string, string>("group_id", group_id),
                    new KeyValuePair<string, string>("v", VERSION)
                };

            if (string.IsNullOrWhiteSpace(file))
            {
                content.Add(new KeyValuePair<string, string>("hash", hash));
                content.Add(new KeyValuePair<string, string>("server", server));
                content.Add(new KeyValuePair<string, string>("photo", photo));

                url += "photos.saveWallPhoto";
            }
            else
            {
                content.Add(new KeyValuePair<string, string>("file", file));

                url += "docs.save";
            }

            using (var formContent = new FormUrlEncodedContent(content))
            {
                result = await HttpPostAsync(url, formContent);
            }

            return result;
        }

        /// <summary>
        /// Отправка файлов по ссылке
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="photo_url"></param>
        /// <param name="upload_url"></param>
        /// <returns></returns>
        private async Task<string> UploadFilesAsync(string access_token, string file_url, string upload_url, string file_type)
        {
            string result = string.Empty;

            if (!string.IsNullOrWhiteSpace(file_url))
            {
                Stopwatch delay = Stopwatch.StartNew();


                using (var stream = await _htmlService.GetStreamAsync(file_url, HttpCompletionOption.ResponseHeadersRead))
                using (var form = new MultipartFormDataContent
                {
                    { new StringContent(access_token, Encoding.UTF8), "access_token" },
                    { new StringContent(VERSION, Encoding.UTF8), "v" }
                })
                {
                    var name = Path.GetFileName(file_url);
                    using (var streamContent = CreateFileContent(stream, name, file_type))
                    {
                        form.Add(streamContent);
                        result = await _htmlService.PostStreamAsync(upload_url, form);
                    }
                }

                delay.Stop();
                var delayTime = DELAY - delay.Elapsed.TotalMilliseconds;
                if (delayTime > 0)
                {
                    await Task.Delay((int)delayTime);
                }
            }

            return result;
        }

        /// <summary>
        /// Stream to StreamContent
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="name"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        private StreamContent CreateFileContent(Stream stream, string name, string file_type)
        {
            var isPhoto = file_type != "gif";
            if (!isPhoto)
            {
                name = "isgif.gif";
            }

            var fileContent = new StreamContent(stream);
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = isPhoto ? "photo" : "file",
                FileName = name
            };

            var contentType = isPhoto ? "application/octet-stream" : "image/gif";
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            return fileContent;
        }

        private async Task<string> FileGetWallUploadServerAsync(string access_token, string group_id, string method)
        {
            var result = string.Empty;

            var url = $"https://api.vk.com/method/{method}";
            using (var formContent = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("access_token", access_token),
                    new KeyValuePair<string, string>("group_id", group_id),
                    new KeyValuePair<string, string>("v", VERSION),
                }))
            {
                result = await HttpPostAsync(url, formContent);
            }

            return result;
        }

        /// <summary>
        /// Пост запрос
        /// </summary>
        /// <param name="url"></param>
        /// <param name="formContent"></param>
        /// <returns></returns>
        private async Task<string> HttpPostAsync(string url, FormUrlEncodedContent formContent)
        {
            var result = string.Empty;

            Stopwatch delay = Stopwatch.StartNew();

            result = await _htmlService.PostAsync(url, formContent);

            delay.Stop();

            var delayTime = DELAY - delay.Elapsed.TotalMilliseconds;
            if (delayTime > 0)
            {
                await Task.Delay((int)delayTime);
            }

            return result;
        }
    }
}
