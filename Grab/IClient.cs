using System.Threading.Tasks;

namespace StatlerWaldorfCorp.Grabbymon.Grab 
{
    public interface IClient
    {
        Task<int> Count(string monsterId);
    } 
}