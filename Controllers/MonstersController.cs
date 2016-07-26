using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace StatlerWaldorfCorp.Grabbymon.Controllers {
    public class MonstersController : Controller {
        public MonsterController() {
        }

        [Route("/")]
        public virtual IActionResult Get() {
            return this.Ok("Hello, world!");
        }
    }
}