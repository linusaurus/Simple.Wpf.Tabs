namespace Simple.Wpf.Tabs.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    public static class CollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> enumerable)
        {
            var array = enumerable.ToArray();
            // ReSharper disable once ForCanBeConvertedToForeach
            for (var i = 0; i < array.Length; i++)
            {
                collection.Add(array[i]);
            }
        }
    }
}