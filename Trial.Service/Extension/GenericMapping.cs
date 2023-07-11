using Mapster;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial.Core.Domain;
using Trial.Core.Entities;
using Trial.Core.Extension;
using Trial.Service.Bases;
using Trial.Service.DTOs.Customer;

namespace Trial.Service.Extension
{
    public static class GenericMapping
    {
        //public static TDTO ToDTO<TDTO>(this Entity entity)
        //{
        //    if (typeof(TDTO).GetInterface("IDateDTO") != null && entity.GetType().GetInterface("IDateEntity") != null)
        //    {
        //        Mapster.TypeAdapterConfig<IDateEntity, TDTO>.NewConfig().Map("LocalCreate", p => p.CreateON.ToPersian()).Map("LocalUpdate", p => p.UpdateON.ToPersian());
        //    }

        //    var dto = entity.Adapt<TDTO>();

        //    return dto;
        //}

        //public static TEntity ToEntity<TEntity>(this BaseEntityDTO baseEntityDTO) 
        //{
        //    if (typeof(TEntity).GetInterface("IDateEntity") != null)
        //    {
        //        Mapster.TypeAdapterConfig<CustomerDTO, Customer>.NewConfig().Ignore("CreateON", "UpdateON", "LocalCreate", "LocalUpdate");
        //    }

        //    var entity = baseEntityDTO.Adapt<TEntity>();

        //    return entity;
        //}



        public static List<CustomerListItemDTO> MapToDTO(this List<Customer> customer)
        {
            var dto = new List<CustomerListItemDTO>();
            foreach (var item in customer)
            {
                dto.Add(new CustomerListItemDTO()
                {
                    Address = item.Address,
                    BirthCertificate = item.BirthCertificate,
                    CustomerNumber = item.CustomerNumber,
                    LastName = item.LastName,
                    Name = item.Name,
                    NationalCode = item.NationalCode,
                    PhoneNumber = item.PhoneNumber,
                    FathersName = item.FathersName,
                    ID = item.ID,
                    CreateON = item.CreateON.ToPersian(),
                    UpdateON = item.UpdateON?.ToPersian(),
                    DateOfBirth = item.DateOfBirth,
                    LocalCreate = item.CreateON,
                    LocalUpdate = item.UpdateON
                });

            }
            return dto;
        }


        public static CustomerListItemDTO MapToDTO(this Customer customer)
        {

            return new CustomerListItemDTO()
            {
                Address = customer.Address,
                BirthCertificate = customer.BirthCertificate,
                CustomerNumber = customer.CustomerNumber,
                LastName = customer.LastName,
                Name = customer.Name,
                NationalCode = customer.NationalCode,
                PhoneNumber = customer.PhoneNumber,
                FathersName = customer.FathersName,
                ID = customer.ID,
                CreateON = customer.CreateON.ToPersian(),
                UpdateON = customer.UpdateON?.ToPersian(),
                DateOfBirth = customer.DateOfBirth,
                LocalCreate = customer.CreateON,
                LocalUpdate = customer.UpdateON
            };

        }



        public static Customer DTOToMap(this CustomerDTO customerDTO)
        {

            return new Customer()
            {
                Address = customerDTO.Address,
                BirthCertificate = customerDTO.BirthCertificate,
                CustomerNumber = customerDTO.CustomerNumber,
                LastName = customerDTO.LastName,
                Name = customerDTO.Name,
                NationalCode = customerDTO.NationalCode,
                PhoneNumber = customerDTO.PhoneNumber,
                FathersName = customerDTO.FathersName,
                ID = customerDTO.ID,
                DateOfBirth = customerDTO.DateOfBirth,
            };

        }
    }
}
