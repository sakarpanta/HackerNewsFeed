using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HackerNewsFeed.Libs.Models;

namespace HackerNewsFeed.Libs.HackerNews
{
    public class GetIdsByCategory : IGetIdsByCategory
    {
        public async Task<IEnumerable<int>> ReturnIdsOfCategory(string category)
        {
            using (var client = new HttpClient())
            {
                var url = new Uri($"https://hacker-news.firebaseio.com/v0/{category}stories.json");
                var response = await client.GetAsync(url);
            }
        }
    }
}
