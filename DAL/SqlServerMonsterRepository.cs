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