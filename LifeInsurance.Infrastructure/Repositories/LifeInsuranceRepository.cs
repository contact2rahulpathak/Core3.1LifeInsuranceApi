using LifeInsurance.Domain.Dtos;
using LifeInsurance.Infrastructure.DBContext;
using LifeInsurance.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifeInsurance.Infrastructure.Repositories
{
    public class LifeInsuranceRepository : ILifeInsuranceRepository<Contract>
    {
        readonly LifeInsuranceContext _lifeInsuranceContext;

        public LifeInsuranceRepository(LifeInsuranceContext lifeInsuranceContext)
        {
            _lifeInsuranceContext = lifeInsuranceContext;
        }
        public void Add(Contract contract)
        {
            _lifeInsuranceContext.Contracts.Add(contract);
            _lifeInsuranceContext.SaveChanges();
        }

        public void Delete(Contract contracts)
        {
            _lifeInsuranceContext.Contracts.Remove(contracts);
            _lifeInsuranceContext.SaveChanges();
        }

        public Contract Get(string contractId)
        {
            return _lifeInsuranceContext.Contracts
                  .FirstOrDefault(e => e.ContractId == contractId);
        }

        public IEnumerable<Contract> GetAll()
        {
            return _lifeInsuranceContext.Contracts.ToList();
        }

        public void Update(Contract contractToUpdate, Contract contract)
        {
            contractToUpdate.CustomerName = contract.CustomerName;
            contractToUpdate.CoveragePlan = contract.CoveragePlan;
            contractToUpdate.CustomerAddress = contract.CustomerAddress;
            contractToUpdate.CustomerCountry = contract.CustomerCountry;
            contractToUpdate.CustomerDateofbirth = contract.CustomerDateofbirth;
            contractToUpdate.CustomerGender = contract.CustomerGender;
            contractToUpdate.SaleDate = contract.SaleDate;
            contractToUpdate.NetPrice = contract.NetPrice;
            _lifeInsuranceContext.SaveChanges();
        }
    }
}
