using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
            return (ColumnAttribute)Attribute.GetCustomAttribute(t, typeof(ColumnAttribute));
        }
    }
}