using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace Utilities
{
    public static class DataAccessExtensions
    {
        public static TableAttribute GetTableAttribute(this Type t)
        {
            return (TableAttribute) Attribute.GetCustomAttribute(t, typeof (TableAttribute));
        }

        public static ColumnAttribute GetColumnAttribute(this Type t)
        {
            var propertyWithKey = (from property in t.GetProperties()
                                    let attributes = property.GetCustomAttributes(true)
                                    from attribute in attributes
                                    where attribute is KeyAttribute
                                    select property).First();
            return propertyWithKey.GetCustomAttribute<ColumnAttribute>();
        }
    }
}