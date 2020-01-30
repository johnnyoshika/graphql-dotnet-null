using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLNull.GraphQL
{
    public class MyQuery : ObjectGraphType
    {
        public MyQuery()
        {
            Field<NonNullGraphType<WidgetType>>(
                "widget",
                resolve: context =>
                {
                    throw new ExecutionError("Something went wrong!");
                }
            );
        }
    }
}
