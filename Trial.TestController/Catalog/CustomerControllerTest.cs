using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial.Service.Catalog.customerService;
using Trial.Service.DTOs.Customer;
using Trial.Web.Controllers;

namespace Trial.TestController.Catalog
{
    [TestClass]
    public class CustomerControllerTest
    {
        CustomerController _customerController = null;
        private Mock<ICustomerService> _mockService;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockService = new Mock<ICustomerService>();

            var _listcustomer = Task.Run<IEnumerable<CustomerListItemDTO>>(() =>
            {
                var listcustomers = new List<CustomerListItemDTO>();

                listcustomers.Add(new CustomerListItemDTO()
                {
                    ID = 1,
                    Name = "alimajidi",
                    NationalCode = "5756"
                });

                return listcustomers;

            });

            _mockService.Setup(p => p.SearchAllCustomer()).Returns(_listcustomer);
            _customerController = new CustomerController(_mockService.Object, null);
        }

        [TestMethod]
        public void GetAllCustomerTest()
        {
            var result = _customerController.Get().Result;
            if (result is ObjectResult)
            {
                var list = result as ObjectResult;
                var list2 = list.Value as IEnumerable<CustomerListItemDTO>;

                //Assert.IsInstanceOfType(list2,typeof(IEnumerable<ProductListItemDTO>));
                Assert.IsTrue(list2.Count() > 0);
            }
            else
            {

                Assert.Fail();

            }
        }

    }
}
