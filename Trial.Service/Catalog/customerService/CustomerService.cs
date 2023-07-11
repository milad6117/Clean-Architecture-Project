using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial.Core.Domain;
using Trial.Core.Extension;
using Trial.Data.Repositories;
using Trial.Service.DTOs.Customer;
using Trial.Service.Extension;

namespace Trial.Service.Catalog.customerService
{
    public class CustomerService:ICustomerService
    {
        #region Field
        private readonly IRepository<Customer> _repository;
        public CustomerService(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Services
        public async Task<IEnumerable<CustomerListItemDTO>> SearchAllCustomer()
        {
            var list = await _repository.Table.ToListAsync();
            
            return list.MapToDTO();
        }

        public async Task<CustomerListItemDTO> GetbyId(int Id)
        {
            var customer = await _repository.FindByIdAsync(Id);
            var customerDTO = customer.MapToDTO();
            return customerDTO;
        }

        public async Task<CustomerDTO> Register(CustomerDTO customerDTO)
        {
            var customer = customerDTO.DTOToMap();
            await _repository.AddAsync(customer);
            customerDTO.ID = customer.ID;
            return customerDTO;
        }

        public async Task Remove(int Id)
        {
            var customer = await _repository.FindByIdAsync(Id);
            await _repository.DeleteAsync(customer);
        }

        public bool IsExists(int Id)
        {
            var customer = _repository.FindByIdAsNoTracking(Id);
            return (customer == null) ? false : true;
        }

        public async Task<CustomerDTO> Update(CustomerDTO customerDTO)
        {
            var customer = await _repository.FindByIdAsync(customerDTO.ID);
            customer.CustomerNumber = customerDTO.CustomerNumber.ToString();
            customer.Name = customerDTO.Name;
            customer.LastName = customerDTO.LastName;
            customer.FathersName = customerDTO.FathersName;
            customer.BirthCertificate = customerDTO.BirthCertificate;
            customer.NationalCode = customerDTO.NationalCode;
            customer.DateOfBirth = customerDTO.DateOfBirth;
            customer.PhoneNumber = customerDTO.PhoneNumber;
            customer.Address = customerDTO.Address;
            customer.UpdateON = DateTime.Now;
            await _repository.UpdateAsync(customer);
            return customerDTO;
        }
        #endregion

        #region Test
        public string GetCustomerName(int CustomerID)
        {
            string CustomerName;
            if (CustomerID == 1)
            {
                CustomerName = "Ali";
            }
            else if (CustomerID == 2)
            {
                CustomerName = "mohammad";
            }
            else if (CustomerID == 3)
            {
                CustomerName = "Amin";
            }
            else
            {
                CustomerName = "NotFound";
            }

            return CustomerName;

        }
        #endregion
    }
}
