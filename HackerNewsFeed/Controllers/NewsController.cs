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

        [HttpGet]
        [Route("{category}")]
        public async Task<IActionResult> Get(string category)
        {
            var result = await _hackerNewsServices.GetNewsItemIdsByCategory(category);
            return Ok(result);
        }

        [HttpGet]
        [Route("items")]
        public async Task<IActionResult> Get([FromQuery(Name = "ids")] int[] ids)
        {
            var result = await _hackerNewsServices.GetNewsItemsByIds(ids);
            return Ok(result);
        }
    }
}
