using System;
using System.Linq;
using System.Collections.Generic;
using StatlerWaldorfCorp.Grabbymon.Models;
using Microsoft.EntityFrameworkCore;

namespace StatlerWaldorfCorp.Grabbymon.DAL 
{
    public class SqlServerMonsterRepository : IMonstersRepository
    {       
        ApplicationDbContext context;

        public SqlServerMonsterRepository(ApplicationDbContext context) {
            this.context = context;
        }   

        public Monster Update(Monster monster) {
            // TODO: implement
            return monster;
        }

        public Monster Add(Monster monster) {
            // TODO: implement            
            return monster;
        }

        public Monster Get(Guid id) {
            // TODO: implement
            return this.context.Monsters.Single(monster => monster.ID == id);
        }

        public Monster Delete(Guid id) {
            // TODO: implement            
            return null;
        }        

        public ICollection<Monster> All() {
            ICollection<Monster> monsters = new List<Monster>();

            try {
                monsters = this.context.Monsters.AsEnumerable<Monster>().ToList();
            } catch (Exception ex) {
                System.Console.WriteLine(ex.Message);
            }

            return monsters;
        }
    }
}