
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace VCard.Services.Abstract
{
    public interface IClientService
    {
        Task<List<VCardModel>> GetAllVCardAsyncFromUrl(string url);
        Task GetAllVCardFromUrlAndSaveDB(string url);
    }
}
