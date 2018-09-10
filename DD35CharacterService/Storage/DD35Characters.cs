using System.Threading.Tasks;

namespace DD35CharacterService.Storage
{
    public interface DD35Characters
    {
        Task<CharacterTransferModel[]> Get();
        Task<CharacterTransferModel> Get(long id);
        Task<long> Add(CharacterTransferModel model);
        Task Update(long id, CharacterTransferModel model);
        Task Delete(long id);
    }
}