using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infustracture.GraphQl.Carts
{
    public class CartType : ObjectType<IEnumerable<HostingPackages>>
    {
        protected override void Configure(IObjectTypeDescriptor<IEnumerable<HostingPackages>> descriptor)
        {
            descriptor.Field(c => c.First().Id).Type<NonNullType<IdType>>();
            descriptor.Field(c => c.First().ArabicName).Type<StringType>();
            descriptor.Field(c => c.First().ArabicDescription).Type<StringType>();
            descriptor.Field(c => c.First().EnglishName).Type<StringType>();
            descriptor.Field(c => c.First().EnglishDescription).Type<StringType>();
            // Add more fields as necessary
        }
    }
}
