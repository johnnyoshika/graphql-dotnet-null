using GraphQL;
using GraphQL.Types;
using GraphQL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLNull.GraphQL
{
    public class MySchema : Schema
    {
        public MySchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<MyQuery>();
        }
    }
}
