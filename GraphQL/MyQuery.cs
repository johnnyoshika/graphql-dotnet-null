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
                "exception",
                resolve: context =>
                {
                    throw new ExecutionError("Something went wrong!");
                }
            );

            Field<WidgetType>(
                "exceptionAndNullable",
                resolve: context =>
                {
                    throw new ExecutionError("Something went wrong!");
                }
            );

            Field<NonNullGraphType<WidgetType>>(
                "null",
                resolve: context =>
                {
                    return null;
                }
            );

            Field<NonNullGraphType<WidgetType>>(
                "errorAndNull",
                resolve: context =>
                {
                    context.Errors.Add(new ExecutionError("Something went wrong!"));
                    return null;
                }
            );

            Field<WidgetType>(
                "errorAndNullable",
                resolve: context =>
                {
                    context.Errors.Add(new ExecutionError("Something went wrong!"));
                    return null;
                }
            );

            Field<NonNullGraphType<WidgetType>>(
                "errorAndValue",
                resolve: context =>
                {
                    context.Errors.Add(new ExecutionError("Something went wrong!"));
                    return new Widget { Id = 1 };
                }
            );
        }
    }
}
