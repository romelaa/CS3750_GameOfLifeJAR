using System;
using System.Timers;
using System.Drawing;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace GameOfLife.Hubs
{
    public class GameHub : Hub
    {
        private static readonly int NUM_CELLS = 30;
        private static readonly string DEAD = "#FFFFFF";
        private static string[,] cells;
        private static Timer timer;
        private static ElapsedEventHandler elhandler;

        public async Task Play()
        {

        }

        public async Task Pause() { 
        
        }

        public async Task Reset() { 
            
        }
            
    }
}
