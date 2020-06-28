using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TheCodeCamp.Data;
using TheCodeCamp.Models;

namespace TheCodeCamp.Controllers
{

    [RoutePrefix("api/camps")]

    public class CampsController : ApiController
    {
        private readonly ICampRepository campRepository;
        private readonly IMapper mapper;

        public CampsController(ICampRepository campRepository, IMapper mapper)
        {
            this.campRepository = campRepository;
            this.mapper = mapper;
        }

        [Route()]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await campRepository.GetAllCampsAsync();

                //Maping
                var mapperResult = mapper.Map<IEnumerable<CampModel>>(result);

                return Ok(mapperResult);
            }
            catch(Exception ex)
            {
                // TODO Add Logging
                return InternalServerError(ex);
            }


        }

        [Route("{moniker}")]
        public async Task<IHttpActionResult> Get(string moniker)
        {
            try
            {
                var result = await campRepository.GetCampAsync(moniker);
                
                if(result == null)
                {
                    return NotFound();
                }

                return Ok(mapper.Map<CampModel> (result));
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            
            }
        
        }
    }
}