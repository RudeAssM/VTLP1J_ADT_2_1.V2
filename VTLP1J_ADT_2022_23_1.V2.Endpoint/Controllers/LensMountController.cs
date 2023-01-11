using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using VTLP1J_ADT_2022_23_1.V2.Endpoint.Services;
using VTLP1J_ADT_2022_23_1.V2.Logic;
using VTLP1J_ADT_2022_23_1.V2.Models;

namespace VTLP1J_ADT_2022_23_1.V2.Endpoint.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class LensMountController : ControllerBase
        {
            private ILensMountLogic LML;
            private IHubContext<SignalHub> hub;
            
            public LensMountController(ILensMountLogic LML, IHubContext<SignalHub> hub)
            {
                this.LML = LML;
                this.hub = hub;
            }

            [HttpGet]
            public IEnumerable<LensMount> Get()
            {
                return LML.GetAllLensMounts();
            }
            
            [HttpGet("{id}")]
            public LensMount Get(int id)
            {
                return LML.GetLensMount(id);
            }
            
            [HttpPost]
            public void Post([FromBody] LensMount lensMount)
            {
                LML.AddLensMount(lensMount);
                this.hub.Clients.All.SendAsync("LensMountAdded", lensMount);
            }
            
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
                LML.deleteLensMount(id);
                this.hub.Clients.All.SendAsync("LensMountDeleted", LML.GetLensMount(id));
            }
        }
    }