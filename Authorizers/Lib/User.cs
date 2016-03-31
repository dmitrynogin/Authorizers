using System;

namespace Authorizers.Lib
{
    public struct User : IEquatable<User>
    {
        public static IAuthenticator Authenticator { get; set; }

        public static readonly User Anonymous = new User(0);
        public static readonly User Authentificated = new User(() => Authenticator?.UserId ?? 0);
        public static readonly User Impersonator = new User(() => Authenticator?.ImpersonatorId ?? 0);

        public static bool IsAuthentificated => Authentificated != Anonymous;
        public static bool IsImpersonated => IsAuthentificated && Authentificated != Impersonator;

        public User(int id)
            : this(() => id)
        {
        }
        
        User(Func<int> lookup)
            : this()
        {
            Lookup = lookup;
        }

        public int Id => Lookup?.Invoke() ?? 0;
        Func<int> Lookup { get; }

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