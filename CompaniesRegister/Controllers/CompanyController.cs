using CompaniesRegister.Data;
using CompaniesRegister.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CompaniesRegister.Controllers
{
    [ApiController]
    [Route("api/company")]
    public class CompanyController: ControllerBase
    {
        private readonly CompaniesRepository _repository;

        public CompanyController(CompaniesRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> Get()
        {
            return await _repository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{rnc}")]
        public async Task<ActionResult<Company>> Get(string rnc)
        {
            var response = await _repository.GetById(rnc);
            if (response == null) { return NotFound(); }
            return response;
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] string company)
        {   
            await _repository.Insert(company);
        }
        
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.DeleteById(id);
        }
    }        

}
