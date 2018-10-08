using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HackerNewsFeed.Libs.Models;
using HackerNewsFeed.Libs.HackerNews;
using Microsoft.Extensions.Caching.Memory;

namespace HackerNewsFeed.Libs.Services
{
    public class HackerNewsServices : IHackerNewsServices
    {
        private static IGetIdsByCategory _getIdsByCategory;
        private static IGetNewsItemsByIds _getNewsItemsByIds;
        private static IMemoryCache _cache;

        public HackerNewsServices(IGetIdsByCategory getIdsByCategory, IGetNewsItemsByIds getNewsItemById, IMemoryCache cache)
        {
            _getIdsByCategory = getIdsByCategory;
            _getNewsItemsByIds = getNewsItemById;
            _cache = cache;
        }

        public async Task<IEnumerable<int>> GetNewsItemIdsByCategory(string category)
        {
            return await _getIdsByCategory.ReturnIdsOfCategory(category);
        }

        public async Task<IEnumerable<NewsItemModel>> GetNewsItemsByIds(int[] ids)
        {
            return await _getNewsItemsByIds.ReturnItemDetailsByIds(ids, _cache);
        }
    }
}
