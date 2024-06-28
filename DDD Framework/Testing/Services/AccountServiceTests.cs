using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Profiles;
using Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Testing.Services
{
    [TestClass]
    public class AccountServiceTests
    {
        private IAccountService _accountService;
        private Mock<IAccountRepository> _accountRepository;
        private Guid _id;
        private AccountDto _accountDto;
        private Account _account;
        private SimpleAccountDto _simpleAccountDto;
        private static IMapper _autoMapper;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AccountProfile());
            });

            _autoMapper = config.CreateMapper();
        }

        [TestInitialize]
        public void Init()
        {
            _accountRepository = new Mock<IAccountRepository>();
            _accountService = new AccountService(_accountRepository.Object, _autoMapper);

            _id = Guid.NewGuid();
            _accountDto = GetAccountDto();
            _account = GetAccount();
            _simpleAccountDto = GetSimpleAccountDto();
        }

        #region GetAccount

        [TestMethod]
        public void GetAccount_Success()
        {
            _accountRepository.Setup(x => x.GetAccount(It.IsAny<Guid>())).Returns(_account);
            AccountDto result = _accountService.GetAccount(_id);

            Assert.AreEqual(_accountDto.Name, result.Name);
            Assert.AreEqual(_accountDto.Surname, result.Surname);
        }

        #endregion

        #region CreateAccount

        [TestMethod]
        public void CreateAccount_Success()
        {
            _accountRepository.Setup(x => x.CreateAccount(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(_account);
            AccountDto result = _accountService.CreateAccount(_simpleAccountDto);

            Assert.AreEqual(_accountDto.Name, result.Name);
            Assert.AreEqual(_accountDto.Surname, result.Surname);
        }

        #endregion

        #region UpdateAccount

        [TestMethod]
        public void UpdateAccount_Success()
        {
            _accountRepository.Setup(x => x.UpdateAccount(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(_account);
            AccountDto result = _accountService.UpdateAccount(_id, _simpleAccountDto);

            Assert.AreEqual(_accountDto.Name, result.Name);
            Assert.AreEqual(_accountDto.Surname, result.Surname);
        }

        #endregion

        #region DeleteAccount

        [TestMethod]
        public void DeleteAccount_Success()
        {
            _accountRepository.Setup(x => x.DeleteAccount(It.IsAny<Guid>()));
            _accountService.DeleteAccount(_id);

            _accountRepository.Verify(x => x.DeleteAccount(It.IsAny<Guid>()), Times.Once());
        }

        #endregion

        #region ValidateUUID

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetAccount_ArgumentException()
        {
            AccountDto result = _accountService.GetAccount(Guid.Empty);
        }

        #endregion

        #region ValidateSimpleAccountDTO

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidateSimpleAccountDto_ArgumentException_Email()
        {
            _simpleAccountDto.Email = "";
            AccountDto result = _accountService.UpdateAccount(_id, _simpleAccountDto);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidateSimpleAccountDto_ArgumentException_Name()
        {
            _simpleAccountDto.Name = "";
            AccountDto result = _accountService.UpdateAccount(_id, _simpleAccountDto);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidateSimpleAccountDto_ArgumentException_Surname()
        {
            _simpleAccountDto.Surname = "";
            AccountDto result = _accountService.UpdateAccount(_id, _simpleAccountDto);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidateSimpleAccountDto_ArgumentException_Password()
        {
            _simpleAccountDto.Password = "";
            AccountDto result = _accountService.UpdateAccount(_id, _simpleAccountDto);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidateSimpleAccountDto_ArgumentException_Title()
        {
            _simpleAccountDto.Title = "MoreThan5Characters";
            AccountDto result = _accountService.UpdateAccount(_id, _simpleAccountDto);
        }

        #endregion

        #region Constructors

        private Account GetAccount()
        {
            return new Account("example@mail.com", "Password", "Name", "Surname", "Mr");
        }

        private AccountDto GetAccountDto()
        {
            return new AccountDto(_id, "example@mail.com", "Name", "Surname", "Mr");
        }

        private SimpleAccountDto GetSimpleAccountDto()
        {
            return new SimpleAccountDto("example@mail.com", "Password", "Name", "Surname", "Mr");
        }

        #endregion
    }
}
