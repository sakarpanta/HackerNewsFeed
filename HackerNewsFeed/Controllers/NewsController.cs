using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HackerNewsFeed.Libs.Services;

namespace HackerNewsFeed.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        private readonly IHackerNewsServices _hackerNewsServices;

        public NewsController(IHackerNewsServices hackerNewsServices)
        {
            _hackerNewsServices = hackerNewsServices;
        }

        [HttpGet("{category}")]
        public async Task<IActionResult> Get(string category)
        {
            var result = await _hackerNewsServices.GetNewsItemIdsByCategory(category);
            return Ok(result);
        }



    }
}
