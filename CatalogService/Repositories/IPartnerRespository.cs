using System.Collections.Generic;
using System.Threading.Tasks;
using CatalogService.Models;


namespace CatalogService.Repositories
{
    public interface IPartnerRespository
    {
        bool SaveChanges();
        
        IEnumerable<Partner> GetAllPartners();

        Partner GetPartnerById(string id);

        void CreatePartner(Partner partner);
    }
}
