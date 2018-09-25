using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HackerNewsFeed.Libs.Models;

namespace HackerNewsFeed.Libs.HackerNews
{
    public interface IGetIdsByCategory
    {
        Task<IEnumerable<int>> ReturnIdsOfCategory(string category);
    }
}
