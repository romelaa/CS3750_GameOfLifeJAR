﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace GameOfLife.Hubs
{
    public class ChatHub : Hub
    {
        public static int[] cells;
        private static System.Timers.Timer aTimer;

        public async Task UpdateCells(int cell) {

            await Clients.All.SendAsync("UpdateCells", cells);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public static void Logic()
        {

            //needs to run input from the game prior to updating.
            //jsonConverterToArray();
            for (int i = 0; i < 256; i++)
            {
                int countOfAlive = 0;
                int countOfDead = 0;
                int left = i % 16; //want to be zero
                int right = 15 + left; //want to be 15.

                if (i == 0)
                {
                    if (cells[i + 1] == 1)
                    {
                        countOfAlive++;

                    }
                    else
                        countOfDead++;

                    if (cells[i + 16] == 1)
                    {
                        countOfAlive++;
                    }
                    else
                        countOfDead++;

                    if (cells[i + 17] == 1)
                    {
                        countOfAlive++;
                    }
                    else
                        countOfDead++;
                }
                else if (i == 15)
                {
                    if (cells[i - 1] == 1)
                    {
                        countOfAlive++;

                    }
                    else
                        countOfDead++;

                    if (cells[i + 16] == 1)
                    {
                        countOfAlive++;
                    }
                    else
                        countOfDead++;

                    if (cells[i + 15] == 1)
                    {
                        countOfAlive++;
                    }
                    else
                        countOfDead++;

                }
                else if (i == 255)
                {
                    if (cells[i - 1] == 1)
                    {
                        countOfAlive++;

                    }
                    else
                        countOfDead++;

                    if (cells[i - 16] == 1)
                    {
                        countOfAlive++;
                    }
                    else
                        countOfDead++;

                    if (cells[i - 17] == 1)
                    {
                        countOfAlive++;
                    }
                    else
                        countOfDead++;

                }
                else if (i == 240)
                {
                    if (cells[i + 1] == 1)
                    {
                        countOfAlive++;

                    }
                    else
                        countOfDead++;

                    if (cells[i - 16] == 1)
                    {
                        countOfAlive++;
                    }
                    else
                        countOfDead++;

                    if (cells[i - 15] == 1)
                    {
                        countOfAlive++;
                    }
                    else
                        countOfDead++;

                }
                else if (1 <= i <= 14)
                {
                    if (cells[i - 1] == 1)
                    {
                        countOfAlive++;

                    }
                    else
                        countOfDead++;
                    if (cells[i + 1] == 1)
                    {
                        countOfAlive++;

                    }
                    else
                        countOfDead++;

                    if (cells[i + 16] == 1)
                    {
                        countOfAlive++;
                    }
                    else
                        countOfDead++;

                    if (cells[i + 15] == 1)
                    {
                        countOfAlive++;
                    }
                    else
                        countOfDead++;

                    if (cells[i + 17] == 1)
                    {
                        countOfAlive++;
                    }
                    else
                        countOfDead++;
                }
                else if (241 <= i <= 254)
                {
                    if (cells[i - 1] == 1)
                    {
                        countOfAlive++;

                    }
                    else
                        countOfDead++;
                    if (cells[i + 1] == 1)
                    {
                        countOfAlive++;

                    }
                    else
                        countOfDead++;

                    if (cells[i - 16] == 1)
                    {
                        countOfAlive++;
                    }
                    else
                        countOfDead++;

                    if (cells[i - 15] == 1)
                    {
                        countOfAlive++;
                    }
                    else
                        countOfDead++;

                    if (cells[i - 17] == 1)
                    {
                        countOfAlive++;
                    }
                    else
                        countOfDead++;
                }
                else if (left == 0 && i != 0 && i != 240)
                {
                    if (cells[i - 16] == 1)
                    {
                        countOfAlive++;

                    }
                    else
                        countOfDead++;
                    if (cells[i - 15] == 1)
                    {
                        countOfAlive++;

                    }
                    else
                        countOfDead++;

                    if (cells[i + 1] == 1)
                    {
                        countOfAlive++;
                    }
                    else
                        countOfDead++;

                    if (cells[i + 16] == 1)
                    {
                        countOfAlive++;
                    }
                    else
                        countOfDead++;

                    if (cells[i + 17] == 1)
                    {
                        countOfAlive++;
                    }
                    else
                        countOfDead++;
                }

                else if (right == 15 && i != 15 && i != 255)
                {
                    if (cells[i - 16] == 1)
                    {
                        countOfAlive++;

                    }
                    else
                        countOfDead++;
                    if (cells[i - 17] == 1)
                    {
                        countOfAlive++;

                    }
                    else
                        countOfDead++;

                    if (cells[i - 1] == 1)
                    {
                        countOfAlive++;
                    }
                    else
                        countOfDead++;

                    if (cells[i + 16] == 1)
                    {
                        countOfAlive++;
                    }
                    else
                        countOfDead++;

                    if (cells[i + 15] == 1)
                    {
                        countOfAlive++;
                    }
                    else
                        countOfDead++;
                }
                else
                {
                    if (cells[i - 15] == 1)
                    {
                        countOfAlive++;

                    }
                    else
                        countOfDead++;
                    if (cells[i - 16] == 1)
                    {
                        countOfAlive++;

                    }
                    else
                        countOfDead++;
                    if (cells[i - 17] == 1)
                    {
                        countOfAlive++;

                    }
                    else
                        countOfDead++;

                    if (cells[i - 1] == 1)
                    {
                        countOfAlive++;
                    }
                    else
                        countOfDead++;

                    if (cells[i + 1] == 1)
                    {
                        countOfAlive++;
                    }
                    else
                        countOfDead++;

                    if (cells[i + 16] == 1)
                    {
                        countOfAlive++;
                    }
                    else
                        countOfDead++;

                    if (cells[i + 15] == 1)
                    {
                        countOfAlive++;
                    }
                    else
                        countOfDead++;

                    if (cells[i + 17] == 1)
                    {
                        countOfAlive++;
                    }
                    else
                        countOfDead++;
                }

                if (cells[i] == 0 && countOfAlive >= 3)
                {
                    cells[i] = 1;
                }
                else if (cells[i] == 1)
                {
                    if (countOfAlive > 3)
                    {
                        cells[i] = 0;
                    }
                    else if (countOfAlive < 2)
                    {
                        cells[i] = 0;
                    }
                }

            }
            //need to call update json method to update the board
            //jsonConversionToJS();

        }

        static void jsonConversionToArray()
        {

            for (int i = 0; i < 256; i++)
            {
                cells[i] = jsonfileiposition;
            }
        }

        static void jsonConversionToJS()
        {

            for (int i = 0; i < 256; i++)
            {
                jsonfileiposition = cells[i];
            }
        }



        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(2000);
            //updates the alive array - below needs to be updated with the method name for calling the update.
            // aTimer.Elapsed = updateMethod();
            aTimer.AutoReset = true;
            aTimer.Enabled = true;



        }

        private static void startButton()
        {
            //run json populating method jsonConversion();
            SetTimer();


        }

        private static void stopButton()
        {
            aTimer.Stop();
        }

        private static void reset()
        {
            for (int i = 0; i < 256; i++)
            {
                cells[i] = 0;
            }

            //jsonConversionToJS();
        }

    } 
}