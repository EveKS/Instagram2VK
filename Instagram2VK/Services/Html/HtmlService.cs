using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Instagram2VK.Services.Html
{
    class HtmlService : IHtmlService
    {
        private HttpClientHandler Handler()
        {
            return new HttpClientHandler()
            {
                AllowAutoRedirect = true,
                MaxAutomaticRedirections = 15,
                AutomaticDecompression = DecompressionMethods.GZip
                    | DecompressionMethods.Deflate | DecompressionMethods.None
            };
        }

        async Task<string> IHtmlService.PostAsync(string url, FormUrlEncodedContent formContent)
        {
            using (var hendler = Handler())
            {
                using (var httpClient = new HttpClient(hendler))
                {
                    SetClientHeaders(httpClient);

                    using (HttpResponseMessage response = await httpClient.PostAsync(url, formContent))
                    using (HttpContent content = response.Content)
                    {
                        return await content.ReadAsStringAsync();
                    }

                    //using (HttpResponseMessage response = await httpClient.GetAsync(new Uri(url)))
                    //using (var responseStream = await response.Content.ReadAsStreamAsync())
                    //using (var decompressedStream = new GZipStream(responseStream, CompressionMode.Decompress))
                    //using (var streamReader = new StreamReader(decompressedStream))
                    //{
                    //    return await streamReader.ReadToEndAsync();
                    //}
                }
            }
        }

        async Task<string> IHtmlService.PostStreamAsync(string url, MultipartFormDataContent formContent)
        {
            using (var hendler = Handler())
            {
                using (var httpClient = new HttpClient(hendler))
                {
                    SetClientHeaders(httpClient);

                    using (HttpResponseMessage response = await httpClient.PostAsync(url, formContent))
                    using (HttpContent content = response.Content)
                    {
                        return await content.ReadAsStringAsync();
                    }
                }
            }
        }

        async Task<string> IHtmlService.GetAsync(string url)
        {
            using (var hendler = Handler())
            {
                using (var httpClient = new HttpClient(hendler))
                {
                    SetClientHeaders(httpClient);

                    using (HttpResponseMessage response = await httpClient.GetAsync(url))
                    using (HttpContent content = response.Content)
                    {
                        return await content.ReadAsStringAsync();
                    }
                }
            }
        }

        async Task<Stream> IHtmlService.GetStreamAsync(string url, HttpCompletionOption httpCompletionOption)
        {
            using (var hendler = Handler())
            {
                using (var httpClient = new HttpClient(hendler))
                {
                    SetClientHeaders(httpClient);
                    using (var responseContent = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                    {
                        if (responseContent.IsSuccessStatusCode)
                        {
                            return await responseContent.Content.ReadAsStreamAsync();
                        }
                        else
                        {
                            return (default(Stream));
                        }
                    }
                }
            }
        }

        private void SetClientHeaders(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Connection", "keep-alive");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate, sdch");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");
        }
    }
}
