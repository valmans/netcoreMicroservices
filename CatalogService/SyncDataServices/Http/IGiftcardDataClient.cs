using CatalogService.Dtos;
using System.Threading.Tasks;

namespace CatalogService.SyncDataServices.Http
{
    public interface IGiftcardDataClient
    {
        Task SendPartnerToGidtcard(PartnerDto part);
    }
}
