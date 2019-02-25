using System;
using CaseTest.ViewModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CaseTest.View
{
    public partial class DetailsPage : ContentPage
    {
        private SpeakerViewModel _speakerViewModel;

        public DetailsPage()
        {
            InitializeComponent();

            //ButtonSpeak.Clicked += ButtonSpeak_Clicked;
            //ButtonWebsite.Clicked += ButtonWebsite_Clicked;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (_speakerViewModel == null)
            {
                _speakerViewModel = BindingContext as SpeakerViewModel;
            }
        }

        private async void ButtonSpeak_Clicked(object sender, EventArgs e)
        {
            await TextToSpeech.SpeakAsync(_speakerViewModel.Description);
        }

        private void ButtonWebsite_Clicked(object sender, EventArgs e)
        {
            if (_speakerViewModel.Website.StartsWith("http", StringComparison.InvariantCulture))
                Device.OpenUri(new Uri(_speakerViewModel.Website));
        }
    }
}
