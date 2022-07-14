using CompaniesRegister.Data;
using CompaniesRegister.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


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

        // GET api/company
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> Get()
        {
            return await _repository.GetAll();
        }

        // GET api/company/5
        [HttpGet("{rnc}")]
        public async Task<ActionResult<Company>> Get(string rnc)
        {
            var response = await _repository.GetByRNC(rnc);
            if (response == null) { return NotFound(); }
            return response;
        }

        // POST api/company
        [HttpPost]
        public async Task Post([FromBody] Company company)
        {   
            await _repository.Insert(company);
        }
        
        // PUT api/company/5
        [HttpPut("{rnc}")]
        public async void Put(string rnc, [FromBody] Company company)
        {
            await _repository.UpdateByRNC(rnc, company);
        }

        // DELETE api/company/5
        [HttpDelete("{rnc}")]
        public async Task Delete(string rnc)
        {
            await _repository.DeleteByRNC(rnc);
        }
    }        

}
