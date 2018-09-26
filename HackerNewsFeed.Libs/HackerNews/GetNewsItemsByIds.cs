
using System;
using System.Threading.Tasks;
using HackerNewsFeed.Libs.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace HackerNewsFeed.Libs.HackerNews
{
    public class GetNewsItemsByIds : IGetNewsItemsByIds
    {
        public async Task<IEnumerable<NewsItemModel>> ReturnItemDetailsByIds(int[] ids)
        {
            var newsItems = new List<NewsItemModel>();
            var batchSize = 50;
            int batchCount = (int)Math.Ceiling((double)ids.Length / batchSize);
            
            for(int i = 0; i < batchCount; i++)
            {
                var currentBatchIds = ids.Skip(i * batchSize).Take(batchSize);
                var tasks = currentBatchIds.Select(id => this.GetNewsItem(id));
                newsItems.AddRange(await Task.WhenAll(tasks));
            }
            return newsItems;
        }

        public async Task<NewsItemModel> GetNewsItem(int id)
        {
            using (var client = new HttpClient())
            {
                var url = new Uri($"https://hacker-news.firebaseio.com/v0/item/{id}.json");

                var response = await client.GetAsync(url).ConfigureAwait(false);
                var newsItem = JsonConvert.DeserializeObject<NewsItemModel>(await response.Content.ReadAsStringAsync());
                return newsItem;
            }
        }
    }
}
