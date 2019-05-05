using BLL.Interface.Interfaces;
using DependencyResolver;
using Moq;
using Ninject;
using NUnit.Framework;

namespace BLL.Tests
{
    [TestFixture]
    public class Tests
    {
        private IKernel resolver;
        
        [TestCase]
        public void BankSystemTest1()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolver();
            IAccountService service = resolver.Get<IAccountService>();

            var anObject = service.GetAllAccounts();

            Assert.IsNotNull(anObject);
            Assert.IsEmpty(anObject);
        }

        [TestCase]
        public void BankSystemTest2()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolver();
            IAccountGenerateID service = resolver.Get<IAccountGenerateID>();

            var anObject = service.GenerateID();

            Assert.IsNotNull(anObject);
            Assert.IsNotEmpty(anObject);
        }

        [TestCase]
        public void BankSystemTest3()
        {
            Mock<IAccountService> mock = new Mock<IAccountService>();
            mock.Setup(m => m.AccountReplenishment("XXX", 10));

            mock.Verify(m => m.AccountWriteOff(It.IsAny<string>(), It.IsAny<int>()), Times.Never());
        }
    }
}