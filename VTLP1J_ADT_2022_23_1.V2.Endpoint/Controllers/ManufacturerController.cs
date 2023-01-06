using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using VTLP1J_ADT_2022_23_1.V2.Endpoint.Services;
using VTLP1J_ADT_2022_23_1.V2.Logic;
using VTLP1J_ADT_2022_23_1.V2.Models;

namespace VTLP1J_ADT_2022_23_1.V2.Endpoint.Controllers
{
    public class ManufacturerController
    {
        [Route("[controller]")]
        [ApiController]
        public class ManufacturerControllers : ControllerBase
        {
            IManufacturerLogic ML;
            private IHubContext<SignalR> hub;
       
            public ManufacturerControllers(IManufacturerLogic ML, IHubContext<SignalR> hub)
            {
                this.ML = ML;
                this.hub = hub; 
            }

            [HttpGet]
            public IEnumerable<Manufacturer> Get()
            {
                return ML.GetAllManufacturers();
            }
       
            [HttpGet("{id}")]
            public Manufacturer Get(int id)
            {
                return ML.Get(id);
            }
        
            [HttpPost]
            public void Post([FromBody] Manufacturer manufacturer)
            {
                ML.AddNewManufacturer(manufacturer);
                this.hub.Clients.All.SendAsync("Manufacturer added", manufacturer);
            }
        
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
                ML.deleteManufacturer(id);
                this.hub.Clients.All.SendAsync("Manufacturer deleted", this.ML.Get(id));
            }

        }
        
    }
}