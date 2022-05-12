using CatalogService.Data;
using CatalogService.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace CatalogService.Repositories
{
    public class PartnerRepository : IPartnerRespository
    {
        private readonly InMemDataContext _context;

        public PartnerRepository(InMemDataContext context)
        {
            _context = context;
        
        }
        public void CreatePartner(Partner partner)
        {
            if (partner == null)
            {
                throw new ArgumentNullException(nameof(partner));
            }
            
            _context.Partners.Add(partner); 

        }

        public IEnumerable<Partner> GetAllPartners()
        {
            return _context.Partners.ToList();
        }

        public Partner GetPartnerById(string id)
        {
            return _context.Partners.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);

        }
    }
}
