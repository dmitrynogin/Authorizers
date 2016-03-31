using System;

namespace Authorizers.Lib
{
    public struct User : IEquatable<User>
    {
        public static readonly User Anonymous = 0;
        public static readonly User Authentificated = -1;
        public static readonly User Impersonator = -2;

        public static implicit operator User(int id) => new User(id);

        public User(int id)
            : this()
        {
            Id = id;
        }

        public int Id { get; }

        public bool Equals(User other) =>
            Id == other.Id;

        public override bool Equals(object obj) =>
            (obj is User) && Equals((User)obj);

        public override int GetHashCode() =>
            Id.GetHashCode();

        public static bool operator ==(User left, User right) =>
            left.Id == right.Id;

        public static bool operator !=(User left, User right) =>
            left.Id != right.Id;
    }
}