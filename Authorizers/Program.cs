using Authorizers.Lib;
using Autofac;
using Autofac.Features.Variance;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorizers
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterSource(new ContravariantRegistrationSource());

            builder.RegisterType<CompanyAuthorizer>()
                .AsImplementedInterfaces();
            
            builder.RegisterType<Authorizer>()
                .AsImplementedInterfaces();
            
            IContainer container = builder.Build();
            var authorizer = container.Resolve<IAuthorizer>();


            Console.WriteLine(authorizer.Grants<Company, Update>(1) == true);
            Console.WriteLine(authorizer.Grants<Company, Read>(1) == true);
            Console.WriteLine(authorizer.Grants<Company, Update>(2) == false);


            var ctx = new EContext();
            ctx.Users.Add(new EUser());
            ctx.SaveChanges();

            var userId = new UserId(1); // compatible to EF LINQ
            foreach (var user in from u in ctx.Users
                              where u.Id == userId
                              select u)
                Console.WriteLine(user.Id);
        }
    }

    public class CompanyAuthorizer : 
        IPermissionAuthorizer<Company, Update>, 
        IPermissionAuthorizer<Company, Read>
    {
        public bool Grants(int resourceId, UserId userId) => resourceId % 2 != 0;
    }

    public class Company
    {
    }

    class CompanyController
    {
        public CompanyController(IAuthorizer authorizer)
        {
            Authorizer = authorizer;
        }

        IAuthorizer Authorizer { get; }

        public void Delete(int id)
        {
            Authorizer.Authorize<Company, Delete>(id);
            // ...
        }
    }

    class EContext : DbContext
    {
        static EContext()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<EContext>());
        }

        public DbSet<EUser> Users { get; set; }
    }

    class EUser
    {
        public int Id { get; private set; }
    }
}
