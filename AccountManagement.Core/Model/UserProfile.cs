using SeedWork;
using System;

namespace AccountManagement.Core
{
    public sealed class UserProfile : IEquatable<UserProfile>
    {
        public UserProfile(string firstname, string lastname)
        {
            var firstnameIsEmpty = string.IsNullOrWhiteSpace(firstname);
            var lastnameIsEmpty = string.IsNullOrWhiteSpace(lastname);

            if (firstnameIsEmpty && lastnameIsEmpty)
                throw new ArgumentException($"At least '{nameof(firstname)}' or '{nameof(lastname)}' must have a value!");

            Firstname = firstname.Rectify();
            Lastname = lastname.Rectify();
        }

        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Fullname => $"{Firstname} {Lastname}".Trim();

        public override bool Equals(object obj)
            => Equals(obj as UserProfile);

        public bool Equals(UserProfile other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            return (Firstname == other.Firstname) && (Lastname == other.Lastname);
        }

        public override int GetHashCode()
            => (Firstname, Lastname).GetHashCode();

        public static bool operator ==(UserProfile left, UserProfile right)
        {
            if (left is null)
            {
                if (right is null)
                    return true;

                return false;
            }

            return left.Equals(right);
        }

        public static bool operator !=(UserProfile left, UserProfile right)
            => !(left == right);
    }
}
