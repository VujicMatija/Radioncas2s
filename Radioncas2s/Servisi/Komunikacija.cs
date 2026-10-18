using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Radioncas2s.Models;

namespace Radioncas2s.Servisi
{
    public class Komunikacija : IAsyncDisposable
    {
        private HubConnection hubConnection;

        public Igrac? prijaveljniIgrac = null;
        public Soba? trenutnaSoba = null;



        public event Action? SobaSpremnaEvent;
        public event Action? PokreniIgruEvent;

        public Komunikacija(NavigationManager navManager)
        {
            hubConnection = new HubConnectionBuilder().WithUrl(navManager.ToAbsoluteUri("/gamehub")).WithAutomaticReconnect().Build();

            hubConnection.On<Soba>("SobaSpremna", (soba) =>
            {
                trenutnaSoba = soba;
                SobaSpremnaEvent?.Invoke();
            });

            hubConnection.On("PokreniIgru", () =>
            {
                PokreniIgruEvent?.Invoke();
            });



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

        

        internal async Task<Soba> KreirajSobu()
        {
            return await hubConnection.InvokeAsync<Soba>("KreirajSobu", prijaveljniIgrac);
        }

        internal async Task<Soba?> PridruziSeSobi(string kod)
        {
            trenutnaSoba = await hubConnection.InvokeAsync<Soba?>("PridruziSeSobi", kod, prijaveljniIgrac);
            return trenutnaSoba;
        }

        internal async Task PokreniIgru()
        {
            await hubConnection.InvokeAsync("PokreniIgru", trenutnaSoba!.Kod);
        }
    }
}
