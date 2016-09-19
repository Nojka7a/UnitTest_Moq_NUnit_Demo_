using InversionOfControlExample;
using InversionOfControlExample.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.Tests
{
    [TestFixture]
    public class CustomerTests
    {

        [Test]
        public void Constructor_ShouldThrowArgumentOutOfRangeException_WhenCallWithNegativeIDFromCreateCustomerMethod()
        {
            //Arrange
            var repositoryMock = new Mock<ICustomerRepository>();
            var service = new CustomerService(repositoryMock.Object);

            //Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => service.CreateCustomer("Pesho", -1));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenCallWithNullOrEmptyNameFromCreateCustomerMethod()
        {
             //Arrange
            var repositoryMock = new Mock<ICustomerRepository>();
            var service = new CustomerService(repositoryMock.Object);

            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => service.CreateCustomer("", 15));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentOutOfRangeException_WhenCallWithNegativeID()
        {
            //Arrange and Act and Assert
            //Assert.Throws<ArgumentOutOfRangeException>(() => new Customer("Pesho", -1));
            
            var customerMock = new Mock<ICustomer>().SetupProperty(x => x.ID, -1);
            Assert.Throws<ArgumentOutOfRangeException>(() => new Customer(customerMock.Object.Name, customerMock.Object.ID));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenCallWithNullOrEmptyName()
        {
            //Arrange and Act and Assert
            Assert.Throws<ArgumentNullException>(() => new Customer("", 15));
        }



    }
}
