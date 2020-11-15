//using LifeInsurance.API.Interfaces;
using LifeInsurance.Domain.Dtos;
using LifeInsurance.Domain.Models;
using LifeInsurance.Infrastructure.Interfaces;
using LifeInsurance.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LifeInsurance.API.Controllers
{
    [Route("api/LifeInsurance")]
    [ApiController]
    public class LifeInsuranceController : ControllerBase
    {
        private readonly ILifeInsuranceRepository<Contract> _lifeInsuranceRepository;
        private readonly InterfaceLifeInsurance _lifeInsuranceService;
        public LifeInsuranceController(ILifeInsuranceRepository<Contract> lifeInsuranceRepository, InterfaceLifeInsurance lifeInsuranceService)
        {
            _lifeInsuranceRepository = lifeInsuranceRepository;
            _lifeInsuranceService = lifeInsuranceService;
        }
        

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Contract> contracts = _lifeInsuranceRepository.GetAll();

            if(contracts.Count()==0)
            {
                return NotFound("The Contracts couldn't be found.");
            }

            return Ok(contracts);
        }

        // POST: api/LifeInsurance
        [HttpPost]
        public IActionResult Post([FromBody] ContractDetails contractDetails)
        {
            if (contractDetails == null)
            {
                return BadRequest("Contract is null.");
            }

            Contract contract = _lifeInsuranceService.CreateContract(contractDetails);

            return Ok("Contract created successfully, CotractId: " + contract.ContractId);
        }

        // PUT: api/LifeInsurance
        [HttpPut("{ContractId}")]
        public IActionResult Put(string ContractId, [FromBody] ContractDetails contractDetails)
        {
            if (contractDetails == null)
            {
                return BadRequest("Contract is null.");
            }

            string response = _lifeInsuranceService.UpdateContract(ContractId, contractDetails);

            return Ok(response);
        }


        // DELETE: api/LifeInsurance/Contractid
        [HttpDelete("{ContractId}")]
        public IActionResult Delete(string ContractId)
        {
            Contract Contract = _lifeInsuranceService.GetContract(ContractId);

            if (Contract == null)
            {
                return NotFound("The Contract record couldn't be found.");
            }

            _lifeInsuranceService.DeleteContract(Contract);

            return NoContent();
        }
    }
}
