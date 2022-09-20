using Entities;
using VCard.Core.Repositories.Concrete;
using VCard.Repositories.Abstract;

namespace VCard.Repositories.Concrete
{
    public class EFVCardRepository:EFRepositoryBase<VCardModel, VCardContext>,IVCardRepository
    {
    }
}
