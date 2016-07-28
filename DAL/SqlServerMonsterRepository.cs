using System;
using System.Linq;
using System.Collections.Generic;
using StatlerWaldorfCorp.Grabbymon.Models;

namespace StatlerWaldorfCorp.Grabbymon.DAL 
{
    public class SqlServerMonsterRepository : IMonstersRepository
    {       
        public SqlServerMonsterRepository() {
        }   

        public Monster Update(Monster monster) {
            return Add(monster);
        }

        public Monster Add(Monster monster) {
            return monster;
        }

        public Monster Get(Guid id) {
            return null;
        }

        public Monster Delete(Guid id) {
            return null;
        }        

        public ICollection<Monster> All() {
            return new List<Monster>();
        }
    }
}