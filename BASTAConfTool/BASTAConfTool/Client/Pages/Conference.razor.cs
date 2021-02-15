using System;
using System.Threading.Tasks;
using BASTAConfTool.Client.Services;
using BASTAConfTool.Shared.DTO;
using Microsoft.AspNetCore.Components;

namespace BASTAConfTool.Client.Pages
{
    public partial class Conference : ComponentBase
    {
        [Parameter]
        public Guid Id { get; set; }
        [Parameter]
        public string Mode { get; set; }

        private bool _isShow { get; set;  }

        [Inject]
        private ConferencesClientService _conferencesClient { get; set; }

        private ConferenceDetails _conferenceDetails;

        public Conference()
        {
            _conferenceDetails = new ConferenceDetails();
            _conferenceDetails.DateFrom = DateTime.UtcNow;
            _conferenceDetails.DateTo = DateTime.UtcNow;
        }

        protected override async Task OnInitializedAsync()
        {
            _isShow = Mode == ConferenceDetailsModes.Show;

            switch (Mode)
            {
                case ConferenceDetailsModes.Show:
                    var result = await _conferencesClient.GetConferenceDetailsAsync(Id);
                    _conferenceDetails = result;
                    break;
            }
        }

        private async Task SaveConference()
        {
            await _conferencesClient.AddConferenceAsync(_conferenceDetails);

            Console.WriteLine("NEW Conference added...");
        }

    }
}
