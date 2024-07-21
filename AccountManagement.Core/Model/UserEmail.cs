using SeedWork;
using System;

namespace AccountManagement.Core
{
    public sealed class UserEmail : IEquatable<UserEmail>
    {
        public UserEmail(string address, DateTime? validationTime = null)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException($"Email cannot be null or empty!", nameof(address));

            address = address.Trim();   
            if (!address.IsValidEmail())
                throw new ArgumentException($"Email ({address}) isn't valid!", nameof(address));

            Address = address.ToLower().Trim();
            ValidationTime = validationTime;
        }

        public string Address { get; private set; }
        public DateTime? ValidationTime { get; private set; }

        public void Validate(DateTime validationTime)
            => ValidationTime = validationTime;

        public override bool Equals(object obj)
            => Equals(obj as UserEmail);

        public bool Equals(UserEmail other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            return string.Equals(Address, other.Address);
        }

        public override int GetHashCode()
            => Address.GetHashCode();

        public static bool operator ==(UserEmail left, UserEmail right)
        {
            if (left is null)
            {
                if (right is null)
                    return true;

                return false;
            }

            return left.Equals(right);
        }

        public static bool operator !=(UserEmail left, UserEmail right)
            => !(left == right);
    }
}
