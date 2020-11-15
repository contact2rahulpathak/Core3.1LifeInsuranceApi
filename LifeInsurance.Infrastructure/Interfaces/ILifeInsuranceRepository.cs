using LifeInsurance.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifeInsurance.Infrastructure.Interfaces
{
    public interface ILifeInsuranceRepository<Contract>
    {
        IEnumerable<Contract> GetAll();
        Contract Get(string id);
        void Add(Contract contract);
        void Update(Contract dbEntity, Contract entity);
        void Delete(Contract entity);
    }
}
