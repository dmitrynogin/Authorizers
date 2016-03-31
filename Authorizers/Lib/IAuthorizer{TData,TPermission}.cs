namespace Authorizers.Lib
{
    public interface IPermissionAuthorizer
    {
    }

    public interface IPermissionAuthorizer<in TResource, in TPermission> : IPermissionAuthorizer 
        where TPermission : Permission
    {
        bool Grants(int resourceId, UserId userId);
    }
}