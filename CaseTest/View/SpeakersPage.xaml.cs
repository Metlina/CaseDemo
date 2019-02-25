using CaseTest.ViewModel;
using Xamarin.Forms;

namespace CaseTest.View
{
    public partial class SpeakersPage : ContentPage
    {
        readonly SpeakersViewModel vm;

        public SpeakersPage()
        {
            InitializeComponent();

            vm = new SpeakersViewModel();
            BindingContext = vm;

            //ListViewSpeakers.ItemSelected += ListViewSpeakers_ItemSelected;
        }

        //private async void ListViewSpeakers_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var speaker = e.SelectedItem as Speakers;
        //    if (speaker == null)
        //        return;

        //    await Navigation.PushAsync(new DetailsPage(speaker));

        //    ListViewSpeakers.SelectedItem = null;
        //}

        private async void ListViewSpeakers_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var speakerViewModel = e.Item as SpeakerViewModel;
            if (speakerViewModel == null)
                return;

            await Navigation.PushAsync(new DetailsPage
            {
                BindingContext = speakerViewModel
            });

            ListViewSpeakers.SelectedItem = null;
        }
    }
}
