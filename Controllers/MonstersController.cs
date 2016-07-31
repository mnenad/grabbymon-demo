using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using StatlerWaldorfCorp.Grabbymon.DAL;
using StatlerWaldorfCorp.Grabbymon.Models;
using StatlerWaldorfCorp.Grabbymon.Grab;

namespace StatlerWaldorfCorp.Grabbymon.Controllers 
{
    [Route("api/[controller]")]
    public class MonstersController : Controller {
        private IMonstersRepository monstersRepository;
        private StatlerWaldorfCorp.Grabbymon.Grab.IClient grabClient;

        public MonstersController(IMonstersRepository monstersRepository, StatlerWaldorfCorp.Grabbymon.Grab.IClient grabClient) {
            this.monstersRepository = monstersRepository;
            this.grabClient = grabClient;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            return this.Ok(monstersRepository.All());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id) 
        {
            return this.Ok(monstersRepository.Get(id));
        }

        [HttpGet("{id}/grabs")]
        public async Task<IActionResult> GetGrabs(Guid id) 
        {
            Monster monster = monstersRepository.Get(id);
            
            return this.Ok(new {
                ID = monster.ID,
                Name = monster.Name,
                Grabs = new {
                    Count = await grabClient.CountAsync(monster.ID),
                    Last = await grabClient.GetLastAsync(monster.ID)
                }
            });
        }

        [HttpPost("{id}/grab")]
        public IActionResult Grab(Guid id) 
        {
            this.grabClient.GrabAsync(id);
            return this.Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody]Monster monster) 
        {
            monster.ID = Guid.NewGuid();
            monstersRepository.Add(monster);
            return this.Created($"/api/[controller]/{monster.ID}", monster);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Monster monster, Guid id) 
        {
            monster.ID = id;
            monstersRepository.Update(monster);

            if(monster == null) {
                return this.NotFound();
            } 
            else 
            {
                return this.Ok(monster.ID);   
            }            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) 
        {
            Monster monster = monstersRepository.Delete(id);

            if(monster == null) {
                return this.NotFound();
            } 
            else 
            {
                return this.Ok(monster.ID);
            }
        }        
    }
}