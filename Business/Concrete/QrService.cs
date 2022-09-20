using Entities;
using System.Net.Http.Json;
using VCard.Services.Abstract;

namespace VCard.Services.Concrete
{
    public class QrService:IQrService
    {
        public async Task<string> GetQrCodeImg(VCardModel model)
        {
            QrCodeRequestModel qrCodeRequestModel = CreateQrRequestModel(model);
            HttpClient client = new HttpClient();
            var result = await client.PostAsJsonAsync("https://api.qr-code-generator.com/v1/create?access-token=0uyHByxRTsv6VlXdVASdylPmMprh2ecqCKlTQmAyB7zAY7QubcKyzF-CE4YcBNl7", qrCodeRequestModel);
            return await result.Content.ReadAsStringAsync();
        }

        public string GetVCardText(VCardModel card)
        {
            return $"Begin:VCARD \n" +
                   $"N:{card.FirstName};{card.Surname};\n" +
                   $"EMAIL:{card.Email}\n" +
                   $"TEL;TYPE=work,VOICE:{card.Phone}\n" +
                   $"ADR;TYPE=WORK, :;; {card.Country} , {card.City}\n" +
                   $"END:VCARD";

        }
        private QrCodeRequestModel CreateQrRequestModel(VCardModel vCardModel)
        {
          return  new QrCodeRequestModel
            {
                frame_name = "no-frame",
                qr_code_logo = "scan-me-square",
                image_format = "SVG",
                qr_code_text = GetVCardText(vCardModel),
            };
        }
    }
}
