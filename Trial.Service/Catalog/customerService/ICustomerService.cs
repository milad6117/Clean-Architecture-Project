using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial.Core.Domain;
using Trial.Data.Repositories;
using Trial.Service.DTOs.Customer;

namespace Trial.Service.Catalog.customerService
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerListItemDTO>> SearchAllCustomer();

        Task<CustomerListItemDTO> GetbyId(int Id);

        Task<CustomerDTO> Register(CustomerDTO customerDTO);

        Task Remove(int Id);

        bool IsExists(int Id);

        Task<CustomerDTO> Update(CustomerDTO customerDTO);

        string GetCustomerName(int CustomerID);
    }
}
