using VCard.Core.Entities;

namespace Entities
{
    public class VCardModel : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string SVGImg { get; set; }


    }
}
