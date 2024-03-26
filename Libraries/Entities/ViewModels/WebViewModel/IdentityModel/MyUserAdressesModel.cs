using Entities.Concrete;
using Entities.Concrete.AdressAggregate;
namespace Entities.ViewModels.WebViewModel.IdentityModel
{
    public class MyUserAdressesModel : BaseEntity
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public Address Address { get; set; }
        public MyUser MyUser { get; set; }
    }
}
