using System.Linq.Expressions;
using Entities;

namespace VCard.Services.Abstract
{
    public interface IVCardService
    {
        Task<IEnumerable<VCardModel>> GetAllAsync(Expression<Func<VCardModel, bool>> filter = null);
        Task<IEnumerable<VCardModel>> GetAllAsyncByCount(Expression<Func<VCardModel, bool>> filter = null,int count=0);
        Task<VCardModel> GetAsync(Expression<Func<VCardModel, bool>> filter);
        Task<VCardModel> AddAsync(VCardModel card);
        Task<VCardModel> UpdateAsync(VCardModel card);
        Task<VCardModel> DeleteAsync(VCardModel card);
        Task<bool> ExistsVcard(VCardModel model);
    }
}
