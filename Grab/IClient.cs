using System;
using System.Threading.Tasks;

namespace StatlerWaldorfCorp.Grabbymon.Grab 
{
    public interface IClient
    {
        int Count(Guid monsterId);
        void Grab(Guid monsterId);
    } 
}