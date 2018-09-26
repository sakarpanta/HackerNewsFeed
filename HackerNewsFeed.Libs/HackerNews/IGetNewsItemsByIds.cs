using System;
using System.Collections.Generic;
using System.Text;
using HackerNewsFeed.Libs.Models;
using System.Threading.Tasks;

namespace HackerNewsFeed.Libs.HackerNews
{
    public interface IGetNewsItemsByIds
    {
        Task<IEnumerable<NewsItemModel>> ReturnItemDetailsByIds(int[] ids);
    }
}
