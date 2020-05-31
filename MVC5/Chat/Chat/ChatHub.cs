using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Chat
{
    [HubName("ChatHub")]
    public class ChatHub : Hub
    {
        public static int liczbaUczestnikow;

        [HubMethodName("wyslijBezNicka")]
        public void Wyslij(string tresc)
        {
            Clients.All.wyswietlWiadomosc(tresc);
        }

        // ma być drugi widok, o nazwi dyskusjaZNickiem
        // nick []: tresc

        [HubMethodName("wyslijZNickiem")]
        public void Wyslij(string tresc, string nick)
        {
            Clients.All.wyswietlWiadomosc(tresc, nick);
        }

        public override Task OnConnected()
        {
            Clients.All.online(++liczbaUczestnikow);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Clients.All.online(--liczbaUczestnikow);
            return base.OnDisconnected(stopCalled);
        }
    }
}