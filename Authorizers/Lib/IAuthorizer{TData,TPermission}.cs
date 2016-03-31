namespace Authorizers.Lib
{
    public interface IPermissionAuthorizer
    {
    }

    public interface IPermissionAuthorizer<in TData, in TPermission> : IPermissionAuthorizer
    {
        bool Grants(int id, User user);
    }
}