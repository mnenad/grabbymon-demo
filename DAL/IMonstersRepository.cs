using System;
using System.Collections.Generic;
using StatlerWaldorfCorp.Grabbymon.Models;

namespace StatlerWaldorfCorp.Grabbymon.DAL 
{
    public interface IMonstersRepository
    {        
        Monster Add(Monster monster);
        Monster Update(Monster monster);
        Monster Get(Guid id);
        Monster Delete(Guid id);
        ICollection<Monster> All();
    }
}