using System.Threading.Tasks;
using Inmemo.Translate.Models;

namespace Inmemo.Translate.Services
{
    public interface IDictionary
    {
        Task<LookupOutput> LookupAsync(LookupInput input);
    }
}
