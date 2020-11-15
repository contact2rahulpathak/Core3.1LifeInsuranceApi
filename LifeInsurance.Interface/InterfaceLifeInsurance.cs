using LifeInsurance.Domain.Dtos;
using LifeInsurance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeInsurance.Interface
{
   public interface InterfaceLifeInsurance
    {
        public Contract CreateContract(ContractDetails contractDetails);
        public Contract GetContract(string contractId);
        public string UpdateContract(string contractId, ContractDetails contractDetails);
        public string DeleteContract(Contract contract);
    }
}
