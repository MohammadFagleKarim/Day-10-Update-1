using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerDetailsInformation.Model;
using CustomerDetailsInformation.Repository;

namespace CustomerDetailsInformation.BLL
{
    public class CustomerManager
    {
        CustomerRepository _CustomerRepository = new CustomerRepository();

        public List<Customers> Search(Customers customers)
        {
            return _CustomerRepository.Search(customers);
        }

        public bool Save(Customers customers)
        {
            return _CustomerRepository.Save(customers);
        }

        public bool IsCodeExists(Customers customers)
        {
            return _CustomerRepository.IsCodeExists(customers);
        }

        public bool IsContactExists(Customers customers)
        {
            return _CustomerRepository.IsContactExists(customers);
        }

        public List<District> DistrictComboBox()
        {
            return _CustomerRepository.DistrictComboBox();
        }
    }
}
