namespace Authorizers.Lib
{
    public interface IResourceAuthorizer
    {
    }

    public interface IResourceAuthorizer<out TResource, in TAccess> : IResourceAuthorizer 
        where TAccess : Access
    {
        bool Grants(int resourceId, UserId userId);
    }
}