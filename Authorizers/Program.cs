using Authorizers.Lib;
using Autofac;
using Autofac.Features.Variance;
using System;
using System.Collections.Generic;
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
            Console.WriteLine(authorizer.Grants<Company, Update>(2) == false);
        }
    }

    public class CompanyAuthorizer : IPermissionAuthorizer<Company, Update>
    {
        public bool Grants(int id, User user) => id % 2 != 0;
    }

    public class Company
    {
    }
}
