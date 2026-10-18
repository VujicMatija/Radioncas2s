using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Radioncas2s.Models;

namespace Radioncas2s.Servisi
{
    public class Komunikacija : IAsyncDisposable
    {
        private HubConnection hubConnection;

        Igrac? prijaveljniIgrac = null;

        public Komunikacija(NavigationManager navManager)
        {
            hubConnection = new HubConnectionBuilder().WithUrl(navManager.ToAbsoluteUri("/gamehub")).WithAutomaticReconnect().Build();





            hubConnection.StartAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await hubConnection.DisposeAsync();
        }

        internal async Task<Igrac?> RegistracijaIgraca(Igrac i)
        {
            return await hubConnection.InvokeAsync<Igrac?>("RegistrujIgrac", i);
        }

        public async Task<Igrac?> PrijaviIgraca(Igrac i)
        {
            prijaveljniIgrac =  await hubConnection.InvokeAsync<Igrac?>("PrijaviIgraca", i);
            if(prijaveljniIgrac != null)
            {
                prijaveljniIgrac.ConnectionID = hubConnection.ConnectionId;
            }
            return prijaveljniIgrac;
        }
    }
}
