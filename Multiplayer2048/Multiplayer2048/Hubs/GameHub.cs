using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalR2048.Hubs
{
    public class GameHub : Hub
    {
        Random rnd = new Random();

        /*public void Restart()
        {
            Clients.All.restartBroadcast();
        }*/

        public void Restart()
        {
            SignalR2048.Controllers.SessionRef.InSession = true;

            //Random rnd = new Random();
            int startVal1 = rnd.NextDouble() < .9 ? 2 : 4;
            int startVal2 = rnd.NextDouble() < .9 ? 2 : 4;

            int cell1x = (int)Math.Floor(rnd.NextDouble() * 4);
            int cell1y = (int)Math.Floor(rnd.NextDouble() * 4);

            int cell2x = (int)Math.Floor(rnd.NextDouble() * 4);
            int cell2y = (int)Math.Floor(rnd.NextDouble() * 4);

            while((cell1x == cell2x) && (cell1y == cell2y) )
            {
                cell2x = (int)Math.Floor(rnd.NextDouble() * 4);
                cell2y = (int)Math.Floor(rnd.NextDouble() * 4);
            }

            Clients.All.restartBroadcast(cell1x, cell1y, cell2x, cell2y, startVal1, startVal2);
        }

        public void Move(int direction, int availableCellsLength)
        {
            int value = rnd.NextDouble() < .9 ? 2 : 4;
            int index = (int)Math.Floor(rnd.NextDouble() * availableCellsLength);
            Clients.All.moveBroadcast(direction, index, value);
        }

        public void AddRandomTile(int availableCellsLength)
        {
            //Random rnd = new Random();
            int value = rnd.NextDouble() < .9 ? 2 : 4;
            int index = (int)Math.Floor(rnd.NextDouble() * availableCellsLength);

 
            Clients.All.addRandomTileBroadcast(index, value);
        }

        public void endgame()
        {
            SignalR2048.Controllers.SessionRef.InSession = false;
        }
    }
}