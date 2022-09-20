using Entities;

namespace VCard.Services.Abstract
{
    public interface IQrService
    {

        string GetVCardText(VCardModel card);
        Task<string> GetQrCodeImg(VCardModel model);
    }
}
