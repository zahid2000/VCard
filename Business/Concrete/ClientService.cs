using System.Net;
using Newtonsoft.Json;
using VCard.Services.Abstract;
using Entities;

namespace VCard.Services.Concrete
{
    public class ClientService : IClientService
    {
        private readonly IVCardService _vCardService ;
       

        public ClientService(IVCardService vCardService)
        {
            _vCardService = vCardService;
          
        }

        public async Task<List<VCardModel>> GetAllVCardAsyncFromUrl(string url)
        {
            List<VCardModel> cards = new List<VCardModel>();
            var request = WebRequest.Create("https://randomuser.me/api?results=50");
            request.Method = "GET";

            using (var webResponse = await request.GetResponseAsync())
            {
                using (var webStream = webResponse.GetResponseStream())
                {
                    using (var reader = new StreamReader(webStream))
                    {
                        var data = await reader.ReadToEndAsync();
                        dynamic records = JsonConvert.DeserializeObject(data);
                        foreach (var result in records.results)
                        {
                            cards.Add(new VCardModel
                            {
                                FirstName = result.name.first,
                                Surname = result.name.last,
                                Email = result.email,
                                Phone = result.phone,
                                Country = result.location.country,
                                City = result.location.city
                            });
                        }
                        return cards;
                    }
                }
            }
        }

        public async Task GetAllVCardFromUrlAndSaveDB(string url)
        {
            List<VCardModel> result =await GetAllVCardAsyncFromUrl(url);
            foreach (VCardModel cardModel in result)
            {
                await _vCardService.AddAsync(cardModel);
            }
        }
    }
}
