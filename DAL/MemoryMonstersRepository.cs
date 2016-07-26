using System;
using System.Linq;
using System.Collections.Generic;
using StatlerWaldorfCorp.Grabbymon.Models;

namespace StatlerWaldorfCorp.Grabbymon.DAL 
{
    public class MemoryMonstersRepository : IMonstersRepository
    {       
        private static ICollection<Monster> monsters;        

        public MemoryMonstersRepository() {
            if(monsters == null) {
                monsters = new List<Monster>();
            }
        }

        public Monster Add(Monster monster) {
            monsters.Add(monster);
            return monster;
        }

        public Monster Get(Guid id) {
            return monsters.Where(m => m.ID == id).FirstOrDefault();
        }        

        public ICollection<Monster> All() {
            return monsters;
        }
    }
}