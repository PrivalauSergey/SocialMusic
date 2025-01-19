using Microsoft.AspNetCore.Mvc;

namespace SM.Home.API.Endpoints.Channel
{
    public class EndpointsDefinition : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPut]
        public IActionResult Update()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return View();
        }
    }
}
