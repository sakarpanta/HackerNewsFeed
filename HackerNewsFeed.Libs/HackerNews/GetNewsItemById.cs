using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HackerNewsFeed.Libs.Models;

namespace HackerNewsFeed.Libs.HackerNews
{
    public class GetNewsItemById : IGetNewsItemById
    {
        public Task<NewsItemModel> ReturnItemDetailById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
