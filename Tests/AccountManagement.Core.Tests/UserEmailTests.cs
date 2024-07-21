using System;

namespace AccountManagement.Core.Tests
{
    public class UserEmailTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Address_NullOrEmptyShouldThrowArgumentException(string address)
        {
            Assert.Throws<ArgumentException>(() => new UserEmail(address));
        }
        
        [Theory]
        [ClassData(typeof(EmailAddressTestsData.InvalidAddresses))]
        public void Address_InvalidShouldThrowArgumentException(string address)
        {
            Assert.Throws<ArgumentException>(() => new UserEmail(address));
        }

        [Theory]
        [ClassData(typeof(EmailAddressTestsData.ValidAddresses))]
        public void Address_Valid(string address)
        {
            var userEmail = new UserEmail(address);

            Assert.Equal(userEmail.Address, address.Trim());
        }

    }
}