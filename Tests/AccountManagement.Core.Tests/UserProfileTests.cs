using System;

namespace AccountManagement.Core.Tests
{
    public class UserProfileTests
    {
        [Theory]
        [ClassData(typeof(UserProfileTestsData.Firstname))]
        public void Firstname_Property(string firstname, string expected)
        {
            var lastname = null as string;

            var userProfile = new UserProfile(firstname, lastname);

            Assert.Equal(userProfile.Firstname, expected);
            Assert.Equal(userProfile.Lastname, string.Empty);
        }

        [Theory]
        [ClassData(typeof(UserProfileTestsData.Lastname))]
        public void Lastname_Property(string lastname, string expected)
        {
            var firstname = null as string;

            var userProfile = new UserProfile(firstname, lastname);

            Assert.Equal(userProfile.Firstname, string.Empty);
            Assert.Equal(userProfile.Lastname, expected);
        }


        [Theory]
        [ClassData(typeof(UserProfileTestsData.Fullname))]
        public void Fullname_Property(string firstname, string lastname, string expectedFullname)
        {
            var userProfile = new UserProfile(firstname, lastname);

            Assert.Equal(userProfile.Fullname, expectedFullname);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", null)]
        [InlineData("", "")]
        public void FirstnameAndLastname_NullOrEmptyShouldThrowArgumentException(string firstname, string lastname)
        {
            Assert.Throws<ArgumentException>(() => new UserProfile(firstname, lastname));
        }
    }
}