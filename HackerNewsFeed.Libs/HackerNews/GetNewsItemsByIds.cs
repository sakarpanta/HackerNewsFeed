
using System;
using System.Threading.Tasks;
using HackerNewsFeed.Libs.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;

namespace HackerNewsFeed.Libs.HackerNews
{
    public class GetNewsItemsByIds : IGetNewsItemsByIds
    {

        public async Task<IEnumerable<NewsItemModel>> ReturnItemDetailsByIds(int[] ids, IMemoryCache cache)
        {
            var newsItems = new List<NewsItemModel>();
            var batchSize = 50;
            int batchCount = (int)Math.Ceiling((double)ids.Length / batchSize);
            
            for(int i = 0; i < batchCount; i++)
            {
                var currentBatchIds = ids.Skip(i * batchSize).Take(batchSize);
                var tasks = currentBatchIds.Select(id => this.GetNewsItem(id,cache));
                newsItems.AddRange(await Task.WhenAll(tasks));
            }
            return newsItems;
        }

        public async Task<NewsItemModel> GetNewsItem(int id, IMemoryCache cache)
        {
            if(cache.TryGetValue<NewsItemModel>(id, out NewsItemModel newsItemModel))
            {
                return newsItemModel;
            }
            using (var client = new HttpClient())
            {
                var url = new Uri($"https://hacker-news.firebaseio.com/v0/item/{id}.json");

                var response = await client.GetAsync(url).ConfigureAwait(false);
                var newsItem = JsonConvert.DeserializeObject<NewsItemModel>(await response.Content.ReadAsStringAsync());
                
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                                            .SetAbsoluteExpiration(TimeSpan.FromDays(1));
                return cache.Set<NewsItemModel>(id, newsItem, cacheEntryOptions);
            }
        }
    }
}
