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
            // SAMPLE vvvvvvv
            Console.WriteLine(grabClient.Count("d00f0853-9699-4c37-98b0-cd403a9d117f").GetAwaiter().GetResult());            
            // SAMPLE ^^^^^^^

            return this.Ok(monstersRepository.All());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id) 
        {
            return this.Ok(monstersRepository.Get(id));
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