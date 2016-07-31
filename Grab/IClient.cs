using System;
using System.Threading.Tasks;

namespace StatlerWaldorfCorp.Grabbymon.Grab 
{
    public interface IClient
    {
        Task<int> CountAsync(Guid monsterId);
        Task<long> GetLastAsync(Guid monsterId);
        void GrabAsync(Guid monsterId);
    } 
}