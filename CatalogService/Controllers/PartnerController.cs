using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System;
using CatalogService.Repositories;
using CatalogService.Dtos;
using System.Collections.Generic;
using CatalogService.SyncDataServices;
using CatalogService.SyncDataServices.Http;
using System.Threading.Tasks;

namespace CatalogService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerRespository _repo;

        public IMapper _mapper { get; }

        private readonly IGiftcardDataClient _giftcardDataClient;

        public PartnerController(IPartnerRespository repo, IMapper mapper, IGiftcardDataClient giftcardClient)
        {
            _repo = repo;
            _mapper = mapper;
            _giftcardDataClient = giftcardClient;
        }

        [HttpGet("id")]
        public async Task<ActionResult<PartnerDto>> GetById(string id)
        {
            
            try
            {
                
                Console.WriteLine("--> Get Partner");
                var part = _mapper.Map<PartnerDto>(_repo.GetPartnerById(id));
                Console.WriteLine("--> Try to connecto to giftcard Service");
                await _giftcardDataClient.SendPartnerToGidtcard(part);


                return Ok();
            }
            catch
            {
                return BadRequest(new { result = "Error", message = "Internal error" });
            }
            
        }

        [HttpGet]
        public async Task<ActionResult<PartnerDto>> GetAll()
        {
            try
            {
                Console.WriteLine("--> Try to connecto to giftcard Service");
                var part = new PartnerDto();
                await _giftcardDataClient.SendPartnerToGidtcard(part);

                return Ok(_mapper.Map<IEnumerable<PartnerDto>>(_repo.GetAllPartners()));
            }
            catch
            {
                return BadRequest(new { result = "Error", message = "Internal error" });
            }

        }
    }
}
