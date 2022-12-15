using System.Threading.Tasks;
using WordAlgorithm.Utilities;

namespace WordAlgorithm.Interfaces
{
    public interface ILoadConfig
    {
        Task<GridConfig>  Load(string filename);
    }
}