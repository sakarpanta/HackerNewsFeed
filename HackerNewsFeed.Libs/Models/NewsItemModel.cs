using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HackerNewsFeed.Libs.Models
{
    public class NewsItemModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public IEnumerable<int> Kids { private get; set; }
    }
}
