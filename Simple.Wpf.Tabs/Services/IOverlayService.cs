namespace Simple.Wpf.Tabs.Services
{
    using System;
    using ViewModels;

    public interface IOverlayService : IService
    {
        IObservable<OverlayViewModel> Show { get; }

        void Post(string header, BaseViewModel viewModel, IDisposable lifetime);
    }
}