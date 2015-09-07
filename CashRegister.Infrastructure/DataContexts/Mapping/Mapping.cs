using System;
using System.Linq;
using System.Reflection;

namespace CashRegister.Infrastructure.DataContexts.Mapping
{
    public static class Mapping
    {
        public static void MapObject(this object objectToHydrate, object objectWithData)
        {
            var emptyProperties = objectToHydrate.GetType().GetProperties();
            var dataProperties = objectWithData.GetType().GetProperties();

            var matchedProperties =
                (from data in dataProperties
                join empty in emptyProperties on data.Name equals empty.Name
                select Tuple.Create(empty, data)).ToList();

            foreach (var match in matchedProperties)
            {
                var empty = match.Item1;
                var data = match.Item2;

                var value = data.GetValue(objectWithData, null);
                empty.SetValue(objectToHydrate, value, null);
            }
        }
        
    }
}
