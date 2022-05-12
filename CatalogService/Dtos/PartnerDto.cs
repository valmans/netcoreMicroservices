using System.Collections.Generic;

namespace CatalogService.Dtos
{
    public class PartnerDto
    {
        public string Id { get; set; }
        public List<string> Domains { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Whatsapp { get; set; }
        public string terms { get; set; }
        public string privacy { get; set; }
        public string copyright { get; set; }
        // public PartnerSocial social { get; set; }
        public string SetupDate { get; set; }
        // public PartnerConf Configuration { get; set; }
        // public GiftMarketConf GiftMarketConf { get; set; }
        // public LayOutInterno Layout { get; set; }
        // public Catalog Catalog { get; set; }

    }
}
