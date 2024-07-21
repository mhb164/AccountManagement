namespace AccountManagement.Core.Tests
{
    public class EmailAddressTestsData
    {
        public class ValidAddresses : TheoryData<string>
        {
            public ValidAddresses()
            {
                Add(" email@example.com ");
                Add(" firstname.lastname@example.com ");
                Add(" email@subdomain.example.com ");
                Add(" email@example ");
            }
        }

        public class InvalidAddresses : TheoryData< string>
        {
            public InvalidAddresses()
            {
                Add("email.example.com");
                Add("firstname@lastname@example.net");
                Add("@example.com");
                Add("Joe Smith <email@example.com>");
                Add("firstname@.example.co.uk");
            }
        }
    }
}