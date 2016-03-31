namespace Authorizers.Lib
{
    public interface IAuthorizer<out TData, out TPermission>
    {
        bool Grants(int id, User user);
    }
}