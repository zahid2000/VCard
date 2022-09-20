using Entities;
using System.Linq.Expressions;
using VCard.Repositories.Abstract;
using VCard.Services.Abstract;

namespace VCard.Services.Concrete
{
    public class VCardService : IVCardService
    {
        protected readonly IVCardRepository _cardRepository;
        protected readonly IQrService _qrService;

        public VCardService(IVCardRepository cardRepository, IQrService qrService)
        {
            _cardRepository = cardRepository;
            _qrService = qrService;
        }

        public async Task<IEnumerable<VCardModel>> GetAllAsync(Expression<Func<VCardModel, bool>> filter = null)
        {
            return await _cardRepository.GetAllAsync(filter);
        }

        public async Task<VCardModel> GetAsync(Expression<Func<VCardModel, bool>> filter)
        {
            return await _cardRepository.GetAsync(filter);
        }

        public async Task<VCardModel> AddAsync(VCardModel card)
        {
            card.SVGImg = await _qrService.GetQrCodeImg(card);
            if (await ExistsVcard(card))
            {
                return null;
            }
            return await _cardRepository.AddAsync(card);
        }

        public async Task<VCardModel> UpdateAsync(VCardModel card)
        {
            return await _cardRepository.UpdateAsync(card);
        }

        public async Task<VCardModel> DeleteAsync(VCardModel card)
        {
            return await _cardRepository.DeleteAsync(card);
        }

        public async Task<bool> ExistsVcard(VCardModel model)
        {
            var result =await _cardRepository.GetAsync(x => x.Phone == model.Phone);
            if (result==null)
            {
                return false;
            }
            return true;
        }

        public async Task<IEnumerable<VCardModel>> GetAllAsyncByCount(Expression<Func<VCardModel, bool>> filter = null, int count = 0)
        {
            return await _cardRepository.GetAllAsyncByCount(filter,count);
        }
    }
}
