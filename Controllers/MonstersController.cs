using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace StatlerWaldorfCorp.Grabbymon.Controllers {
    [Route("api/[controller]")]
    public class MonsterController : Controller {
        public MonsterController() {
        }

        public async virtual Task<IActionResult> Get() {
            return this.Ok("Test");
        }
    }
}