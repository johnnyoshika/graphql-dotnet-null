using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLNull.GraphQL
{
    public class Widget
    {
        public int Id { get; set; }
    }

    public class WidgetType : ObjectGraphType<Widget>
    {
        public WidgetType()
        {
            Field(t => t.Id);
        }
    }
}
