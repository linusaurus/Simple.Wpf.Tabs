namespace Simple.Wpf.Tabs.Extensions
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reactive.Linq;

    public static class NotifyPropertyChangedExtensions
    {
        private sealed class SourceAndNames<T>
        {
            public T Source { get; private set; }

            public string[] Names { get; private set; }

            public SourceAndNames(T source, string[] names)
            {
                Source = source;
                Names = names;
            }
        }

        public static IObservable<PropertyChangedEventArgs> ObservePropertyChanged<TSource, TValue>(this TSource source,
            params Expression<Func<TSource, TValue>>[] properties)
            where TSource : INotifyPropertyChanged
        {
            var names = properties.Select(x => x.Body)
                .OfType<MemberExpression>()
                .Select(x => x.Member.Name)
                .ToArray();

            return Observable.Return(new SourceAndNames<TSource>(source, names))
                .SelectMany(x => x.Source.ObservePropertyChanged().Where(y => x.Names.Contains(y.PropertyName)), (x, y) => y);
        }

        public static IObservable<PropertyChangedEventArgs> ObservePropertyChanged(this INotifyPropertyChanged source)
        {
            return Observable.Return(source)
                .SelectMany(x => Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                h => x.PropertyChanged += h,
                h => x.PropertyChanged -= h),
                (x, y) => y)
                .Select(x => x.EventArgs);
        }
    }
}