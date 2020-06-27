using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TheCodeCamp.Data;

namespace TheCodeCamp.Controllers
{

    public class CampsController : ApiController
    {
        private readonly ICampRepository campRepository;

        public CampsController(ICampRepository campRepository)
        {
            this.campRepository = campRepository;
        }

        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await campRepository.GetAllCampsAsync();

                return Ok(result);
            }
            catch(Exception ex)
            {
                // TODO Add Logging
                return InternalServerError(ex);
            }


        }
    }
}