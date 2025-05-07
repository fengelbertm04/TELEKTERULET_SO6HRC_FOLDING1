using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TelekAPI.Data;
using TelekAPI.Models;

namespace TelekAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AreaController : ControllerBase
    {
        IAreaRepository _repo;

        public AreaController(IAreaRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public AreaOutput Result()
        {
            return _repo.Result();
        }

        [HttpPost]
        public void SetArea([FromBody] Area area)
        {
            _repo.SetArea(area);
        }
    }
}
