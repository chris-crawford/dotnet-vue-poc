using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace dotnetvuepoc.kendo
{
    [Route("api/[controller]")]
    [ApiController]
    public class KendoController : ControllerBase
    {
        private IList<KendoMetadata> _mockedDataStore;

        public KendoController()
        {
            // init dependencies
            _mockedDataStore = GenerateData();
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            return new JsonResult(JsonConvert.SerializeObject(_mockedDataStore));
        }

        [HttpGet("{lastName}", Name = "GetKendoMetaById")]
        public JsonResult GetById(string lastName)
        {
            var result = _mockedDataStore.Where(x => string.Compare(lastName, x.LastName, true) == 0);
            return new JsonResult(JsonConvert.SerializeObject(result));
        }

        // mock data generator
        private IList<KendoMetadata> GenerateData()
        {
            return new List<KendoMetadata>
            {
                new KendoMetadata
                {
                    Address = "123 Euclid Avenue",
                    FirstName = "Jim",
                    LastName = "Johnson",
                    Gender = "M"
                },
                new KendoMetadata
                {
                    Address = "123 Prospect Avenue",
                    FirstName = "Bob",
                    LastName = "Billingsly",
                    Gender = "M"
                },
                new KendoMetadata
                {
                    Address = "123 St. Claire Avenue",
                    FirstName = "Terry",
                    LastName = "Tate",
                    Gender = "M"
                }
            };
        }
    }
}