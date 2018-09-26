using System;
using System.Collections.Generic;
using System.Text;
using HackerNewsFeed.Libs.Models;
using System.Threading.Tasks;

namespace HackerNewsFeed.Libs.Services
{
    public interface IHackerNewsServices
    {
        Task<IEnumerable<int>> GetNewsItemIdsByCategory(string category);
        Task<IEnumerable<NewsItemModel>> GetNewsItemsByIds(int[] id);
    }
}
