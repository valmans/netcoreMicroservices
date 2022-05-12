using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogService.Models
{
    public class Partner
    {
        [Key]
        public string Id { get; set; }
        [NotMapped]
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
    
    public class PartnerConf
    {
        [NotMapped]
        public List<BannerElement> banner { get; set; }

        public Logo Logo { get; set; }
        public Colors Colors { get; set; }

    }

    public class BannerElement
    {
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string CallBack { get; set; }
    }
   
    public class GiftMarketConf
    {
        public string TBD { get; set; }
    }
    public class LayOutInterno
    {
        public string TBD { get; set; }
    }
    public class PartnerSocial
    {
        public string instagram { get; set; }
        public string facebook { get; set; }

        public string twitter { get; set; }

        public string youtube { get; set; }
    }
    public class Logo
    {
        public string Image { get; set; }

        public string Width { get; set; }
    }

    public class Colors
    {
        public string DiscountTag { get; set; }
        public string DiscountMsg { get; set; }

        public string FixedAmount { get; set; }

        public string Button { get; set; }

        public string LinkHoover { get; set; }

        public string FooterBack { get; set; }
    }
}

