
using System; 
using System.Threading.Tasks;
using HackerNewsFeed.Libs.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace HackerNewsFeed.Libs.HackerNews
{
    public class GetNewsItemById : IGetNewsItemById
    {
        public async Task<NewsItemModel> ReturnItemDetailById(int id)
        {
            using (var client = new HttpClient())
            {
                var url = new Uri($"https://hacker-news.firebaseio.com/v0/item/{id}.json");

                var response = await client.GetAsync(url);

                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }

                return JsonConvert.DeserializeObject<NewsItemModel>(json);
            }
        }
    }
}
