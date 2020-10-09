using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FanOutPutLibrary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleRESTService.Controllers
{
    [Route("fanoutput")]
    [ApiController]
    public class FanOutPutController : ControllerBase
    {
        private static int nextId = 5;
        private static readonly List<FanOutPut> fanOutPuts = new List<FanOutPut>()
        {
            new FanOutPut(1,"RoomOne", 20, 75),
            new FanOutPut(2,"roomTwo",24,60),
            new FanOutPut(3,"roomThree",23,50),
            new FanOutPut(4,"roomFour",21,70)
        };

        // GET: api/<FanOutPutController>
        [HttpGet]
        public IEnumerable<FanOutPut> Get()
        {
            return fanOutPuts;
        }

        // GET api/<FanOutPutController>/5
        [HttpGet("{id}")]
        public FanOutPut Get(int id)
        {
            return fanOutPuts.Find(i => i.Id == id);
        }

        // POST api/<FanOutPutController>
        [HttpPost]
        public void Post([FromBody] FanOutPut value)
        {
            value.Id = nextId++;
            fanOutPuts.Add(value);
        }

        // PUT api/<FanOutPutController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] FanOutPut value)
        {
            FanOutPut fanOutPut = Get(id);
            if (fanOutPut != null)
            {
                fanOutPut.Name = value.Name;
                fanOutPut.Temp = value.Temp;
                fanOutPut.Moisture = value.Moisture;
            }
        }

        // DELETE api/<FanOutPutController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            FanOutPut fanOutPut = Get(id);
            fanOutPuts.Remove(fanOutPut);
        }
    }
}
