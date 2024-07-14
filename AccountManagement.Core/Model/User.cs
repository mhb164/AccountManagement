using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManagement.Core
{
    public class User
    {
        private readonly HashSet<UserEmail> _emails = new HashSet<UserEmail>();
        private readonly HashSet<UserMobileNumber> _mobileNumbers = new HashSet<UserMobileNumber>();

        public Guid Id { get; private set; }
        public bool Activation { get; private set; }
        public string Name { get; private set; }
        public string Password { get; private set; }
        public UserProfile Profile { get; private set; }
        public IEnumerable<UserEmail> Emails => _emails;
        public IEnumerable<UserMobileNumber> MobileNumbers => _mobileNumbers;
    }
}
