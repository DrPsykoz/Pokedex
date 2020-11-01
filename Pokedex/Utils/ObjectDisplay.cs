using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Pokedex.Utils
{
    public static class ObjectDisplay<T>
    {

        public static void displayObject(T item)
        {
            PropertyInfo[] listProperties = typeof(T).GetProperties();
            foreach (PropertyInfo property in listProperties)
            {
                if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition().Equals(typeof(List<>)))
                {
                    ColorConsole.WriteLine($"   {property.Name}", ConsoleColor.White);

                    PropertyInfo[] listKeys = property.PropertyType.GetGenericArguments()[0].GetProperties();
                    System.Collections.IList listValues = (System.Collections.IList)property.GetValue(item, null);

                    foreach (var listValue in listValues)
                        foreach (PropertyInfo key in listKeys)
                            ColorConsole.WriteLine($"     {key.Name} ", $"{key.GetValue(listValue)}", ConsoleColor.White, ConsoleColor.Cyan);
                }
                else
                {
                    ColorConsole.WriteLine($"   {property.Name} ", $"{property.GetValue(item)}", ConsoleColor.White, ConsoleColor.Cyan);
                }
            }
        }
    }
}
