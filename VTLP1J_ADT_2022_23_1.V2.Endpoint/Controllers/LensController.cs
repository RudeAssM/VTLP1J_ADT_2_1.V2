using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using VTLP1J_ADT_2022_23_1.V2.Endpoint.Services;
using VTLP1J_ADT_2022_23_1.V2.Logic;
using VTLP1J_ADT_2022_23_1.V2.Models;

namespace VTLP1J_ADT_2022_23_1.V2.Endpoint.Controllers
{
    public class LensController
    {
        [Route("[controller]")]
        [ApiController]
        public class LensControllers : ControllerBase
        {
            private ILensLogic IL;
            IHubContext<SignalR> hubContext;
            
            public LensControllers(ILensLogic IL, IHubContext<SignalR> hubContext)
            {
                this.IL = IL;
                this.hubContext = hubContext;
            }

            [HttpGet]
            public IEnumerable<ILens> Get()
            {
                return IL.GetAllLenses()
                    ;
            }
            [HttpGet("{id}")]
            public ILens Get(int id)
            {
                return IL.GetLens(id);

            }
            
            [HttpPost]
            public void Post([FromBody] ILens lens)
            {
                IL.AddNewLens(lens);
                this.hubContext.Clients.All.SendAsync("Lens Added", lens);
            }
            
            [HttpPut]
            public void Put([FromBody] int Id, ICollection<LensMount> LenM)
            {
                IL.UpdateLensMount(Id, LenM);
                this.hubContext.Clients.All.SendAsync("Lens Updated", Id, LenM);
            }
            
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
                IL.deleteLens(id);
                this.hubContext.Clients.All.SendAsync("Lens Deleted", id);
            }
        }
    }
}