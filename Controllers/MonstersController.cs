using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using StatlerWaldorfCorp.Grabbymon.DAL;
using StatlerWaldorfCorp.Grabbymon.Models;

namespace StatlerWaldorfCorp.Grabbymon.Controllers 
{
    [Route("api/[controller]")]
    public class MonstersController : Controller {
        private IMonstersRepository monstersRepository;

        public MonstersController(IMonstersRepository monstersRepository) {
            this.monstersRepository = monstersRepository;
        }

        [HttpGet]
        public virtual IActionResult Get() 
        {
            return this.Ok(monstersRepository.All());
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(Guid id) 
        {
            return this.Ok(monstersRepository.Get(id));
        }

        [HttpPost]
        public virtual IActionResult Post([FromBody]Monster monster) 
        {
            monster.ID = Guid.NewGuid();
            monstersRepository.Add(monster);
            return this.Created($"/api/[controller]/{monster.ID}", monster);
        }

    }
}