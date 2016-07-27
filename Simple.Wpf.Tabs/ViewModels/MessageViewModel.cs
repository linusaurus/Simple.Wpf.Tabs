namespace Simple.Wpf.Tabs.ViewModels
{
    using System;

    public sealed class MessageViewModel : OverlayViewModel<ICloseableViewModel>
    {
        public MessageViewModel(string header, ICloseableViewModel viewModel, IDisposable lifetime)
            : base(header, viewModel, lifetime)
        {
        }
    }
}