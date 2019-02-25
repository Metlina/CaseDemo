using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using CaseTest.Model;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace CaseTest.ViewModel
{
    public class SpeakersViewModel : BaseViewModel
    {
        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();

                GetSpeakersCommand.ChangeCanExecute();
            }
        }

        public ObservableCollection<SpeakerViewModel> Speakers { get; set; } = new ObservableCollection<SpeakerViewModel>();

        public Command GetSpeakersCommand { get; }

        public SpeakersViewModel()
        {
            GetSpeakersCommand = new Command(async () => await GetSpeakers(), () => !IsBusy);
        }

        private async Task GetSpeakers()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                using (var client = new HttpClient())
                {
                    //grab json from server
                    var json = await client.GetStringAsync("https://demo8598876.mockable.io/speakers");

                    //Deserialize json
                    var items = JsonConvert.DeserializeObject<List<Speaker>>(json);

                    //Load speakers into list
                    Speakers.Clear();
                    foreach (var item in items)
                    {
                        Speakers.Add(new SpeakerViewModel(item));
                    }
                }
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error!", e.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
