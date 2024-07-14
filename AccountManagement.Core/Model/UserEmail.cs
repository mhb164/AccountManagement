using SeedWork;
using System;

namespace AccountManagement.Core
{
    public sealed class UserEmail : IEquatable<UserEmail>
    {
        public UserEmail(string value, DateTime? validationTime = null)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"Email cannot be null ot empty!", nameof(value));

            if (!value.IsValidEmail())
                throw new ArgumentException($"Email ({value}) isn't valid!", nameof(value));

            Value = value.ToLower().Trim();
            ValidationTime = validationTime;
        }

        public string Value { get; private set; }
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

            return string.Equals(Value, other.Value);
        }

        public override int GetHashCode()
            => Value.GetHashCode();

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
