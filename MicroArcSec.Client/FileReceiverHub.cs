using Microsoft.AspNetCore.SignalR;

namespace MicroArcSec.Client
{
    public class FileReceiverHub : Hub
    {
        public async Task SendFile(string fileName)
        {
            await Clients.All.SendAsync("ReceiveFile", fileName);
        }
    }
}
