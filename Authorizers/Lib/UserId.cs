using Authorizers.Lib.Converters;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace Authorizers.Lib
{
    [TypeConverter(typeof(UserIdTypeConverter))]
    [JsonConverter(typeof(UserIdJsonConverter))]
    public struct UserId : IEquatable<UserId>
    {
        public static IAuthenticator Authenticator { get; set; }

        public static readonly UserId Anonymous = new UserId(0);
        public static readonly UserId Current = new UserId(() => Authenticator?.CurrentUserId ?? 0);
        public static readonly UserId Interactive = new UserId(() => Authenticator?.InteractiveUserId ?? 0);

        public UserId(int value)
            : this(() => value)
        {
        }
        
        UserId(Func<int> getValue)
            : this()
        {
            GetValue = getValue;
        }

        public bool Authenticated => this == Current && this != Anonymous;
        public bool Impersonated => this == Current && Current != Interactive;
        public bool Impersonating => this == Interactive && Current != Interactive;

        Func<int> GetValue { get; }
        int Value => GetValue?.Invoke() ?? 0;

        public static implicit operator int(UserId id) => id.Value;

        public bool Equals(UserId other) =>
            Value == other.Value;

        public override bool Equals(object obj) =>
            (obj is UserId) && Equals((UserId)obj);

        public override int GetHashCode() =>
            ((int)this).GetHashCode();

        public static bool operator ==(UserId left, UserId right) =>
            left.Value == right.Value;

        public static bool operator !=(UserId left, UserId right) =>
            left.Value != right.Value;
    }
}