namespace Simple.Wpf.Tabs.Extensions
{
    using System;
    using System.ComponentModel;
    using Services;

    public static class SettingsExtensions
    {
        public static T Get<T>(this ISettings settings, string name)
        {
            var value = settings[name];
            if (value == null)
            {
                return default(T);
            }

            var converter = TypeDescriptor.GetConverter(typeof(T));

            if (converter.CanConvertFrom(value.GetType()))
            {
                return (T)converter.ConvertFrom(value);
            }

            try
            {
                var convertedValue = Convert.ChangeType(value, typeof(T));
                return (T)convertedValue;
            }
            catch (Exception)
            {
            }

            return (T)value;
        }
    }
}