using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TheCodeCamp.Data;
using TheCodeCamp.Models;

namespace TheCodeCamp.Controllers
{

    public class CampsController : ApiController
    {
        private readonly ICampRepository campRepository;
        private readonly IMapper mapper;

        public CampsController(ICampRepository campRepository, IMapper mapper)
        {
            this.campRepository = campRepository;
            this.mapper = mapper;
        }

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
    }
}