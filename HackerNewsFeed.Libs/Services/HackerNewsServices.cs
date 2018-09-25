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
        private static IGetNewsItemById _getNewsItemById;

        public HackerNewsServices(IGetIdsByCategory getIdsByCategory, IGetNewsItemById getNewsItemById)
        {
            _getIdsByCategory = getIdsByCategory;
            _getNewsItemById = getNewsItemById;
        }

        public async Task<IEnumerable<int>> GetNewsItemIdsByCategory(string category)
        {
            return await _getIdsByCategory.ReturnIdsOfCategory(category);
        }

        public async Task<NewsItemModel> GetNewsItemById(int id)
        {
            return await _getNewsItemById.ReturnItemDetailById(id);
        }
    }
}
