using System;
using System.Collections.Generic;
using StatlerWaldorfCorp.Grabbymon.Models;

namespace StatlerWaldorfCorp.Grabbymon.DAL 
{
    public interface IMonstersRepository
    {        
        Monster Add(Monster monster);
        Monster Get(Guid id);
        ICollection<Monster> All();
    }
}