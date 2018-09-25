using System;
using System.Collections.Generic;
using System.Text;
using HackerNewsFeed.Libs.Models;
using System.Threading.Tasks;

namespace HackerNewsFeed.Libs.HackerNews
{
    public interface IGetNewsItemById
    {
        Task<NewsItemModel> ReturnItemDetailById(int id);
    }
}
