using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HackerNewsFeed.Libs.Models;
using HackerNewsFeed.Libs.HackerNews;

namespace HackerNewsFeed.Libs.Services
{
    public class HackerNewsServices : IHackerNewsServices
    {
        private static IGetIdsByCategory _getIdsByCategory;
        private static IGetNewsItemsByIds _getNewsItemsByIds;

        public HackerNewsServices(IGetIdsByCategory getIdsByCategory, IGetNewsItemsByIds getNewsItemById)
        {
            _getIdsByCategory = getIdsByCategory;
            _getNewsItemsByIds = getNewsItemById;
        }

        public async Task<IEnumerable<int>> GetNewsItemIdsByCategory(string category)
        {
            return await _getIdsByCategory.ReturnIdsOfCategory(category);
        }

        public async Task<IEnumerable<NewsItemModel>> GetNewsItemsByIds(int[] ids)
        {
            return await _getNewsItemsByIds.ReturnItemDetailsByIds(ids);
        }
    }
}
