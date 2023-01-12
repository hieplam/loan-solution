using System.Linq;
using loan_solution;
using loan_solution.Validators;
using NUnit.Framework;

namespace loan_solution_test
{
    public class PhoneNumberValidatorTest
    {
        private PhoneNumberValidator _phoneNumberValidator;
        
        [SetUp]
        public void Setup()
        {
            _phoneNumberValidator = new PhoneNumberValidator();
        }
        
        [Test]
        [TestCase("0451223810")]
        [TestCase("+61451223810")]
        public void PhoneNumberValidatorTest_GivenValidMobileNumber_ShouldSuccess(string phoneNumber)
        {
            Assert.IsTrue(_phoneNumberValidator.IsMobileNumber(phoneNumber));
        }
        
        [Test]
        [TestCase("0396173903")]
        [TestCase("0296173903")]
        [TestCase("0796173903")]
        [TestCase("0896173903")]
        public void PhoneNumberValidatorTest_GivenValidLandlineNumber_ShouldSuccess(string phoneNumber)
        {
            Assert.IsTrue(_phoneNumberValidator.IsLandlineNumber(phoneNumber));
        }
        
        
        [Test]
        [TestCase("0396173903")]
        [TestCase("0451223810")]
        [TestCase("+61451223810")]
        [TestCase("0796173903")]
        public void PhoneNumberValidatorTest_GivenMobileAndLandlineNumber_ShouldHaveNoFailedValidationResult(string phoneNumber)
        {
            var validationResult = _phoneNumberValidator.Validate(new LoanRequest{PhoneNumber = phoneNumber});
            Assert.IsFalse(validationResult.Any());
        }
    }
}