using System;
using NUnit.Framework;
using InversionOfControlExample;
using InversionOfControlExample.Repository;
using InversionOfControlExample.Exceptions;
using Moq;

namespace IOC.Tests
{
    [TestFixture]
    public class CustomerServiceTests
    {
        //Тест при извивкване на класа CustomerService метода CreateCustomer() че се вика 1 път repository.Add();
        //Не тестваме repository-то, приемаме че си работи (от fake implementation)
        #region Testing_With_FakeImplementations
        //[Test]
        //public void CreateCustomer_ShouldCallCustomerRepositoryAddMethodOnce_When()
        //{
        //    //Arrange
        //    //we dont have to work with the real classes, because they can acces DB or other and we must ensure that everything other is working
        //    //var repository = new CustomerRepository();
        //    var repository = new FakeCustomerRepository();
        //    var service = new CustomerService(repository);
            
        //    //act
        //    service.CreateCustomer("Pesho", 1);

        //    //assert
        //    Assert.AreEqual(1, repository.MethodInvocationCounter, "Add() method of CustomerRepository is not calling once when CreateCustomer() is called!", null);

        //}

        //[Test]
        //public void CreateCustomer_ShouldCallCustomerRepositoryAddMethod_When()
        //{
        //    //Arrange
        //    var repository = new FakeCustomerRepository();
        //    var service = new CustomerService(repository);

        //    //Act
        //    service.CreateCustomer("Dimi", 2);

        //    //Assert
        //    Assert.IsTrue(repository.IsAddMethodCalled);
        //}

        #endregion

        #region Testing_With_MOQ_Framework

        [Test]
        public void CreateCustomer_ShouldCallCustomerRepositoryAddMethodOnce_When()
        {
            //Arrange
            //make empty body of methods when is Loose behaviour and not throw exception when is not implement
            var mockRepository = new Mock<ICustomerRepository>();
            var service = new CustomerService(mockRepository.Object);

            //act
            service.CreateCustomer("Pesho", 1);

            //assert
            mockRepository.Verify(
                x => x.Add(It.IsAny<ICustomer>()), 
                Times.Once, 
                "Add() of class CustomerRepository is not called once!");
        }

        [Test]
        public void CreateCustomer_ShouldThrowCreateCustomerException_WhenRepositoryThrowsAddCustomerExceptions()
        {
            //Arrange
            var repositoryMock = new Mock<ICustomerRepository>();
            repositoryMock
                .Setup(x => x.Add(It.IsAny<ICustomer>()))
                .Throws<AddCustomerException>();

            var service = new CustomerService(repositoryMock.Object);

            //Act Assert 
            //When AddCustomerException is throwned, will CreateCustomerException be thrown
            //repositoryMock is not good enough for verifying exceptions => use Assert
            var exception = Assert.Throws<CreateCustomerException>(() => service.CreateCustomer("Dido", 1));

            Assert.IsInstanceOf<AddCustomerException>(exception.InnerException);
        }

        [Test]
        public void CreateCustomer_ShouldCallExactNTimesAddMethod_WhenCallCreateCustomer()
        {
            var repositoryMock = new Mock<ICustomerRepository>();
            repositoryMock
                .Setup(x => x.Add(It.IsAny<ICustomer>()));

            int timesCallingMethod = 5; 
            var service = new CustomerService(repositoryMock.Object);
            for (int i = 0; i < timesCallingMethod; i++)
            {
                service.CreateCustomer("Pesho" + i.ToString(), i);
            }

            repositoryMock.Verify(x => 
                x.Add(It.IsAny<ICustomer>()),
                Times.Exactly(timesCallingMethod));
        }

        #endregion

    }


}
