using System;
using Urho;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UrhoFormsSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UrhoPage : ContentPage
    {
        private bool _shouldResume;

        private Urho.Application _app;

        public UrhoPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (_shouldResume)
            {
                Urho.Forms.UrhoSurface.OnResume();
                _shouldResume = false;
                return;
            }
            var options = new ApplicationOptions(null)
            {
                Orientation = ApplicationOptions.OrientationType.Landscape
            };
            _app = await UrhoSurface.Show<HugeObjectCount>(options);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (_shouldResume)
            {
                Urho.Forms.UrhoSurface.OnPause();
                return;
            }
            Urho.Forms.UrhoSurface.OnDestroy();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            _shouldResume = true;
            Navigation.PushAsync(new DetailPage());
        }
    }
}