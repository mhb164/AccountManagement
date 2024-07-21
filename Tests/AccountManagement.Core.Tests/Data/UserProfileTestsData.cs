namespace AccountManagement.Core.Tests
{
    public class UserProfileTestsData
    {
        public class Firstname : TheoryData<string, string>
        {
            //firstname, expected
            public Firstname()
            {
                Add("Name", "Name"); 
                Add("Name ", "Name");
                Add(" Name", "Name");
                Add(" Name ", "Name");

                Add("Prefix Name", "Prefix Name");
                Add(" Prefix  Name ", "Prefix Name");

                Add("پیشوند نام", "پیشوند نام");
                Add(" پیشوند  نام ", "پیشوند نام");
            }
        }

        public class Lastname : TheoryData<string, string>
        {
            //lastname, expected
            public Lastname()
            {
                Add("Family", "Family");
                Add("Family ", "Family");
                Add(" Family", "Family");
                Add(" Family ", "Family");

                Add("Family Suffix", "Family Suffix");
                Add(" Family  Suffix ", "Family Suffix");

                Add("فامیل پسوند ", "فامیل پسوند");
                Add(" فامیل  پسوند ", "فامیل پسوند");
            }
        }

        public class Fullname : TheoryData<string, string, string>
        {
            //firstname, lastname, expectedFullname
            public Fullname()
            {
                Add("Name", "Family", "Name Family");
                Add(" Name ", "  Family  ", "Name Family");

                Add("Prefix Name", "Family Suffix", "Prefix Name Family Suffix");
                Add(" Prefix  Name ", " Family  Suffix ", "Prefix Name Family Suffix");

                Add("پیشوند نام", "فامیل پسوند", "پیشوند نام فامیل پسوند");
                Add(" پیشوند  نام ", " فامیل  پسوند ", "پیشوند نام فامیل پسوند");
            }
        }
    }
}