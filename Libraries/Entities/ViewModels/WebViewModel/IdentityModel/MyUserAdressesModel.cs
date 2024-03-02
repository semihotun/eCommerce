using Core.Library;
using Entities.Concrete;
using Entities.Concrete.AdressAggregate;
namespace Entities.ViewModels.WebViewModel.IdentityModel
{
    public class MyUserAdressesModel : BaseEntity
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public virtual Address Address { get; set; }
        public virtual MyUser MyUser { get; set; }
    }
}
