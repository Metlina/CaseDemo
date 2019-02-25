using System;
using CaseTest.Model;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CaseTest.ViewModel
{
    public class SpeakerViewModel : BaseViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string Title { get; set; }
        public string Avatar { get; set; }

        public Command SpeakCommand { get; }
        public Command OpenWebsiteCommand { get; }

        public SpeakerViewModel(Speaker speaker)
        {
            if (speaker == null)
                throw new ArgumentNullException(nameof(speaker));

            Id = speaker.Id;
            Name = speaker.Name;
            Description = speaker.Description;
            Website = speaker.Website;
            Title = speaker.Title;
            Avatar = speaker.Avatar;

            SpeakCommand = new Command(ExecudeSpeak);
            OpenWebsiteCommand = new Command(ExecudeOpenWebsite);
        }

        private async void ExecudeSpeak()
        {
            await TextToSpeech.SpeakAsync(Description);
        }

        private void ExecudeOpenWebsite()
        {
            if (Website.StartsWith("http", StringComparison.InvariantCulture))
                Device.OpenUri(new Uri(Website));
        }
    }
}
