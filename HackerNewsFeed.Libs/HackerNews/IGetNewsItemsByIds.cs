using System;
using System.Collections.Generic;
using System.Text;
using HackerNewsFeed.Libs.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace HackerNewsFeed.Libs.HackerNews
{
    public interface IGetNewsItemsByIds
    {
        Task<IEnumerable<NewsItemModel>> ReturnItemDetailsByIds(int[] ids, IMemoryCache cache);
    }
}
