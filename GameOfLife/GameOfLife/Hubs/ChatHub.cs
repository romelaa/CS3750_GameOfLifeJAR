using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Json.Net;

namespace GameOfLife.Hubs
{
    public class ChatHub : Hub
    {
        public static int[] cells;
        public static string[] hexVal;
        private static System.Timers.Timer aTimer;

        public async Task UpdateCells(int cell)
        {

            await Clients.All.SendAsync("UpdateCells", cells);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }


        public class myJasonDataIncoming
        {
            // [DataMember]
            public string active { get; set; }     //0 no 1 yes
            public string hex { get; set; }
        }

        public class myJSONList
        {
            public List<myJasonDataIncoming> Events { get; set; }
        }




        public static void Logic(Object source, ElapsedEventArgs e)
        {

            //needs to run input from the game prior to updating.
            jsonConversionToArray();
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
                else if (1 <= i && i <= 14)
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
                else if (241 <= i && i <= 254)
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
            jsonConversionToJS();

        }

        public static void jsonConversionToArray()
        {
            int i = 0;
            //romela, you need to create the code to generate the jsonValue variable below.
            dynamic stuff = JsonConvert.DeserializeObject<myJSONList>(jsonValue);
            int activeBit;


            foreach (var s in stuff)
            {
                bool isParsable = Int32.TryParse(s.active, out activeBit);
                if (isParsable)
                {
                    cells[i] = s.active;
                    hexVal[i] = s.hex;
                    i = i + 1;
                }
                else
                    Console.WriteLine("Could not be parsed.");


            }

        }

        static void jsonConversionToJS()
        {

            List<myJasonDataIncoming> jsonMsgs = new List<myJasonDataIncoming>();

            //I don't know how to make it so that this will populate through a for loop...
            myJasonDataIncoming o0 = new myJasonDataIncoming
            {
                active = cells[0].ToString(),
                hex = hexVal[0]
            };
            jsonMsgs.Add(o0);

            myJasonDataIncoming o1 = new myJasonDataIncoming
            {
                active = cells[1].ToString(),
                hex = hexVal[1]
            };
            jsonMsgs.Add(o1);

            myJasonDataIncoming o2 = new myJasonDataIncoming
            {
                active = cells[2].ToString(),
                hex = hexVal[2]
            };
            jsonMsgs.Add(o2);

            myJasonDataIncoming o3 = new myJasonDataIncoming
            {
                active = cells[3].ToString(),
                hex = hexVal[3]
            };
            jsonMsgs.Add(o3);

            myJasonDataIncoming o4 = new myJasonDataIncoming
            {
                active = cells[4].ToString(),
                hex = hexVal[4]
            };
            jsonMsgs.Add(o4);

            myJasonDataIncoming o5 = new myJasonDataIncoming
            {
                active = cells[5].ToString(),
                hex = hexVal[5]
            };
            jsonMsgs.Add(o5);

            myJasonDataIncoming o6 = new myJasonDataIncoming
            {
                active = cells[6].ToString(),
                hex = hexVal[6]
            };
            jsonMsgs.Add(o6);

            myJasonDataIncoming o7 = new myJasonDataIncoming
            {
                active = cells[7].ToString(),
                hex = hexVal[7]
            };
            jsonMsgs.Add(o7);

            myJasonDataIncoming o8 = new myJasonDataIncoming
            {
                active = cells[8].ToString(),
                hex = hexVal[8]
            };
            jsonMsgs.Add(o8);

            myJasonDataIncoming o9 = new myJasonDataIncoming
            {
                active = cells[9].ToString(),
                hex = hexVal[9]
            };
            jsonMsgs.Add(o9);

            myJasonDataIncoming o10 = new myJasonDataIncoming
            {
                active = cells[10].ToString(),
                hex = hexVal[10]
            };
            jsonMsgs.Add(o10);

            myJasonDataIncoming o11 = new myJasonDataIncoming
            {
                active = cells[11].ToString(),
                hex = hexVal[11]
            };
            jsonMsgs.Add(o11);

            myJasonDataIncoming o12 = new myJasonDataIncoming
            {
                active = cells[12].ToString(),
                hex = hexVal[12]
            };
            jsonMsgs.Add(o12);

            myJasonDataIncoming o13 = new myJasonDataIncoming
            {
                active = cells[13].ToString(),
                hex = hexVal[13]
            };
            jsonMsgs.Add(o13);

            myJasonDataIncoming o14 = new myJasonDataIncoming
            {
                active = cells[14].ToString(),
                hex = hexVal[14]
            };
            jsonMsgs.Add(o14);

            myJasonDataIncoming o15 = new myJasonDataIncoming
            {
                active = cells[15].ToString(),
                hex = hexVal[15]
            };
            jsonMsgs.Add(o15);

            myJasonDataIncoming o16 = new myJasonDataIncoming
            {
                active = cells[16].ToString(),
                hex = hexVal[16]
            };
            jsonMsgs.Add(o16);

            myJasonDataIncoming o17 = new myJasonDataIncoming
            {
                active = cells[17].ToString(),
                hex = hexVal[17]
            };
            jsonMsgs.Add(o17);

            myJasonDataIncoming o18 = new myJasonDataIncoming
            {
                active = cells[18].ToString(),
                hex = hexVal[18]
            };
            jsonMsgs.Add(o18);

            myJasonDataIncoming o19 = new myJasonDataIncoming
            {
                active = cells[19].ToString(),
                hex = hexVal[19]
            };
            jsonMsgs.Add(o19);

            myJasonDataIncoming o20 = new myJasonDataIncoming
            {
                active = cells[20].ToString(),
                hex = hexVal[20]
            };
            jsonMsgs.Add(o20);

            myJasonDataIncoming o21 = new myJasonDataIncoming
            {
                active = cells[21].ToString(),
                hex = hexVal[21]
            };
            jsonMsgs.Add(o21);

            myJasonDataIncoming o22 = new myJasonDataIncoming
            {
                active = cells[22].ToString(),
                hex = hexVal[22]
            };
            jsonMsgs.Add(o22);

            myJasonDataIncoming o23 = new myJasonDataIncoming
            {
                active = cells[23].ToString(),
                hex = hexVal[23]
            };
            jsonMsgs.Add(o23);

            myJasonDataIncoming o24 = new myJasonDataIncoming
            {
                active = cells[24].ToString(),
                hex = hexVal[24]
            };
            jsonMsgs.Add(o24);

            myJasonDataIncoming o25 = new myJasonDataIncoming
            {
                active = cells[25].ToString(),
                hex = hexVal[25]
            };
            jsonMsgs.Add(o25);

            myJasonDataIncoming o26 = new myJasonDataIncoming
            {
                active = cells[26].ToString(),
                hex = hexVal[26]
            };
            jsonMsgs.Add(o26);

            myJasonDataIncoming o27 = new myJasonDataIncoming
            {
                active = cells[27].ToString(),
                hex = hexVal[27]
            };
            jsonMsgs.Add(o27);

            myJasonDataIncoming o28 = new myJasonDataIncoming
            {
                active = cells[28].ToString(),
                hex = hexVal[28]
            };
            jsonMsgs.Add(o28);

            myJasonDataIncoming o29 = new myJasonDataIncoming
            {
                active = cells[29].ToString(),
                hex = hexVal[29]
            };
            jsonMsgs.Add(o29);

            myJasonDataIncoming o30 = new myJasonDataIncoming
            {
                active = cells[30].ToString(),
                hex = hexVal[30]
            };
            jsonMsgs.Add(o30);

            myJasonDataIncoming o31 = new myJasonDataIncoming
            {
                active = cells[31].ToString(),
                hex = hexVal[31]
            };
            jsonMsgs.Add(o31);

            myJasonDataIncoming o32 = new myJasonDataIncoming
            {
                active = cells[32].ToString(),
                hex = hexVal[32]
            };
            jsonMsgs.Add(o32);

            myJasonDataIncoming o33 = new myJasonDataIncoming
            {
                active = cells[33].ToString(),
                hex = hexVal[33]
            };
            jsonMsgs.Add(o33);

            myJasonDataIncoming o34 = new myJasonDataIncoming
            {
                active = cells[34].ToString(),
                hex = hexVal[34]
            };
            jsonMsgs.Add(o34);

            myJasonDataIncoming o35 = new myJasonDataIncoming
            {
                active = cells[35].ToString(),
                hex = hexVal[35]
            };
            jsonMsgs.Add(o35);

            myJasonDataIncoming o36 = new myJasonDataIncoming
            {
                active = cells[36].ToString(),
                hex = hexVal[36]
            };
            jsonMsgs.Add(o36);

            myJasonDataIncoming o37 = new myJasonDataIncoming
            {
                active = cells[37].ToString(),
                hex = hexVal[37]
            };
            jsonMsgs.Add(o37);

            myJasonDataIncoming o38 = new myJasonDataIncoming
            {
                active = cells[38].ToString(),
                hex = hexVal[38]
            };
            jsonMsgs.Add(o38);

            myJasonDataIncoming o39 = new myJasonDataIncoming
            {
                active = cells[39].ToString(),
                hex = hexVal[39]
            };
            jsonMsgs.Add(o39);

            myJasonDataIncoming o40 = new myJasonDataIncoming
            {
                active = cells[40].ToString(),
                hex = hexVal[40]
            };
            jsonMsgs.Add(o40);

            myJasonDataIncoming o41 = new myJasonDataIncoming
            {
                active = cells[41].ToString(),
                hex = hexVal[41]
            };
            jsonMsgs.Add(o41);

            myJasonDataIncoming o42 = new myJasonDataIncoming
            {
                active = cells[42].ToString(),
                hex = hexVal[42]
            };
            jsonMsgs.Add(o42);

            myJasonDataIncoming o43 = new myJasonDataIncoming
            {
                active = cells[43].ToString(),
                hex = hexVal[43]
            };
            jsonMsgs.Add(o43);

            myJasonDataIncoming o44 = new myJasonDataIncoming
            {
                active = cells[44].ToString(),
                hex = hexVal[44]
            };
            jsonMsgs.Add(o44);

            myJasonDataIncoming o45 = new myJasonDataIncoming
            {
                active = cells[45].ToString(),
                hex = hexVal[45]
            };
            jsonMsgs.Add(o45);

            myJasonDataIncoming o46 = new myJasonDataIncoming
            {
                active = cells[46].ToString(),
                hex = hexVal[46]
            };
            jsonMsgs.Add(o46);

            myJasonDataIncoming o47 = new myJasonDataIncoming
            {
                active = cells[47].ToString(),
                hex = hexVal[47]
            };
            jsonMsgs.Add(o47);

            myJasonDataIncoming o48 = new myJasonDataIncoming
            {
                active = cells[48].ToString(),
                hex = hexVal[48]
            };
            jsonMsgs.Add(o48);

            myJasonDataIncoming o49 = new myJasonDataIncoming
            {
                active = cells[49].ToString(),
                hex = hexVal[49]
            };
            jsonMsgs.Add(o49);

            myJasonDataIncoming o50 = new myJasonDataIncoming
            {
                active = cells[50].ToString(),
                hex = hexVal[50]
            };
            jsonMsgs.Add(o50);

            myJasonDataIncoming o51 = new myJasonDataIncoming
            {
                active = cells[51].ToString(),
                hex = hexVal[51]
            };
            jsonMsgs.Add(o51);

            myJasonDataIncoming o52 = new myJasonDataIncoming
            {
                active = cells[52].ToString(),
                hex = hexVal[52]
            };
            jsonMsgs.Add(o52);

            myJasonDataIncoming o53 = new myJasonDataIncoming
            {
                active = cells[53].ToString(),
                hex = hexVal[53]
            };
            jsonMsgs.Add(o53);

            myJasonDataIncoming o54 = new myJasonDataIncoming
            {
                active = cells[54].ToString(),
                hex = hexVal[54]
            };
            jsonMsgs.Add(o54);

            myJasonDataIncoming o55 = new myJasonDataIncoming
            {
                active = cells[55].ToString(),
                hex = hexVal[55]
            };
            jsonMsgs.Add(o55);

            myJasonDataIncoming o56 = new myJasonDataIncoming
            {
                active = cells[56].ToString(),
                hex = hexVal[56]
            };
            jsonMsgs.Add(o56);

            myJasonDataIncoming o57 = new myJasonDataIncoming
            {
                active = cells[57].ToString(),
                hex = hexVal[57]
            };
            jsonMsgs.Add(o57);

            myJasonDataIncoming o58 = new myJasonDataIncoming
            {
                active = cells[58].ToString(),
                hex = hexVal[58]
            };
            jsonMsgs.Add(o58);

            myJasonDataIncoming o59 = new myJasonDataIncoming
            {
                active = cells[59].ToString(),
                hex = hexVal[59]
            };
            jsonMsgs.Add(o59);

            myJasonDataIncoming o60 = new myJasonDataIncoming
            {
                active = cells[60].ToString(),
                hex = hexVal[60]
            };
            jsonMsgs.Add(o60);

            myJasonDataIncoming o61 = new myJasonDataIncoming
            {
                active = cells[61].ToString(),
                hex = hexVal[61]
            };
            jsonMsgs.Add(o61);

            myJasonDataIncoming o62 = new myJasonDataIncoming
            {
                active = cells[62].ToString(),
                hex = hexVal[62]
            };
            jsonMsgs.Add(o62);

            myJasonDataIncoming o63 = new myJasonDataIncoming
            {
                active = cells[63].ToString(),
                hex = hexVal[63]
            };
            jsonMsgs.Add(o63);

            myJasonDataIncoming o64 = new myJasonDataIncoming
            {
                active = cells[64].ToString(),
                hex = hexVal[64]
            };
            jsonMsgs.Add(o64);

            myJasonDataIncoming o65 = new myJasonDataIncoming
            {
                active = cells[65].ToString(),
                hex = hexVal[65]
            };
            jsonMsgs.Add(o65);

            myJasonDataIncoming o66 = new myJasonDataIncoming
            {
                active = cells[66].ToString(),
                hex = hexVal[66]
            };
            jsonMsgs.Add(o66);

            myJasonDataIncoming o67 = new myJasonDataIncoming
            {
                active = cells[67].ToString(),
                hex = hexVal[67]
            };
            jsonMsgs.Add(o67);

            myJasonDataIncoming o68 = new myJasonDataIncoming
            {
                active = cells[68].ToString(),
                hex = hexVal[68]
            };
            jsonMsgs.Add(o68);

            myJasonDataIncoming o69 = new myJasonDataIncoming
            {
                active = cells[69].ToString(),
                hex = hexVal[69]
            };
            jsonMsgs.Add(o69);

            myJasonDataIncoming o70 = new myJasonDataIncoming
            {
                active = cells[70].ToString(),
                hex = hexVal[70]
            };
            jsonMsgs.Add(o70);

            myJasonDataIncoming o71 = new myJasonDataIncoming
            {
                active = cells[71].ToString(),
                hex = hexVal[71]
            };
            jsonMsgs.Add(o71);

            myJasonDataIncoming o72 = new myJasonDataIncoming
            {
                active = cells[72].ToString(),
                hex = hexVal[72]
            };
            jsonMsgs.Add(o72);

            myJasonDataIncoming o73 = new myJasonDataIncoming
            {
                active = cells[73].ToString(),
                hex = hexVal[73]
            };
            jsonMsgs.Add(o73);

            myJasonDataIncoming o74 = new myJasonDataIncoming
            {
                active = cells[74].ToString(),
                hex = hexVal[74]
            };
            jsonMsgs.Add(o74);

            myJasonDataIncoming o75 = new myJasonDataIncoming
            {
                active = cells[75].ToString(),
                hex = hexVal[75]
            };
            jsonMsgs.Add(o75);

            myJasonDataIncoming o76 = new myJasonDataIncoming
            {
                active = cells[76].ToString(),
                hex = hexVal[76]
            };
            jsonMsgs.Add(o76);

            myJasonDataIncoming o77 = new myJasonDataIncoming
            {
                active = cells[77].ToString(),
                hex = hexVal[77]
            };
            jsonMsgs.Add(o77);

            myJasonDataIncoming o78 = new myJasonDataIncoming
            {
                active = cells[78].ToString(),
                hex = hexVal[78]
            };
            jsonMsgs.Add(o78);

            myJasonDataIncoming o79 = new myJasonDataIncoming
            {
                active = cells[79].ToString(),
                hex = hexVal[79]
            };
            jsonMsgs.Add(o79);

            myJasonDataIncoming o80 = new myJasonDataIncoming
            {
                active = cells[80].ToString(),
                hex = hexVal[80]
            };
            jsonMsgs.Add(o80);

            myJasonDataIncoming o81 = new myJasonDataIncoming
            {
                active = cells[81].ToString(),
                hex = hexVal[81]
            };
            jsonMsgs.Add(o81);

            myJasonDataIncoming o82 = new myJasonDataIncoming
            {
                active = cells[82].ToString(),
                hex = hexVal[82]
            };
            jsonMsgs.Add(o82);

            myJasonDataIncoming o83 = new myJasonDataIncoming
            {
                active = cells[83].ToString(),
                hex = hexVal[83]
            };
            jsonMsgs.Add(o83);

            myJasonDataIncoming o84 = new myJasonDataIncoming
            {
                active = cells[84].ToString(),
                hex = hexVal[84]
            };
            jsonMsgs.Add(o84);

            myJasonDataIncoming o85 = new myJasonDataIncoming
            {
                active = cells[85].ToString(),
                hex = hexVal[85]
            };
            jsonMsgs.Add(o85);

            myJasonDataIncoming o86 = new myJasonDataIncoming
            {
                active = cells[86].ToString(),
                hex = hexVal[86]
            };
            jsonMsgs.Add(o86);

            myJasonDataIncoming o87 = new myJasonDataIncoming
            {
                active = cells[87].ToString(),
                hex = hexVal[87]
            };
            jsonMsgs.Add(o87);

            myJasonDataIncoming o88 = new myJasonDataIncoming
            {
                active = cells[88].ToString(),
                hex = hexVal[88]
            };
            jsonMsgs.Add(o88);

            myJasonDataIncoming o89 = new myJasonDataIncoming
            {
                active = cells[89].ToString(),
                hex = hexVal[89]
            };
            jsonMsgs.Add(o89);

            myJasonDataIncoming o90 = new myJasonDataIncoming
            {
                active = cells[90].ToString(),
                hex = hexVal[90]
            };
            jsonMsgs.Add(o90);

            myJasonDataIncoming o91 = new myJasonDataIncoming
            {
                active = cells[91].ToString(),
                hex = hexVal[91]
            };
            jsonMsgs.Add(o91);

            myJasonDataIncoming o92 = new myJasonDataIncoming
            {
                active = cells[92].ToString(),
                hex = hexVal[92]
            };
            jsonMsgs.Add(o92);

            myJasonDataIncoming o93 = new myJasonDataIncoming
            {
                active = cells[93].ToString(),
                hex = hexVal[93]
            };
            jsonMsgs.Add(o93);

            myJasonDataIncoming o94 = new myJasonDataIncoming
            {
                active = cells[94].ToString(),
                hex = hexVal[94]
            };
            jsonMsgs.Add(o94);

            myJasonDataIncoming o95 = new myJasonDataIncoming
            {
                active = cells[95].ToString(),
                hex = hexVal[95]
            };
            jsonMsgs.Add(o95);

            myJasonDataIncoming o96 = new myJasonDataIncoming
            {
                active = cells[96].ToString(),
                hex = hexVal[96]
            };
            jsonMsgs.Add(o96);

            myJasonDataIncoming o97 = new myJasonDataIncoming
            {
                active = cells[97].ToString(),
                hex = hexVal[97]
            };
            jsonMsgs.Add(o97);

            myJasonDataIncoming o98 = new myJasonDataIncoming
            {
                active = cells[98].ToString(),
                hex = hexVal[98]
            };
            jsonMsgs.Add(o98);

            myJasonDataIncoming o99 = new myJasonDataIncoming
            {
                active = cells[99].ToString(),
                hex = hexVal[99]
            };
            jsonMsgs.Add(o99);

            myJasonDataIncoming o100 = new myJasonDataIncoming
            {
                active = cells[100].ToString(),
                hex = hexVal[100]
            };
            jsonMsgs.Add(o100);

            myJasonDataIncoming o101 = new myJasonDataIncoming
            {
                active = cells[101].ToString(),
                hex = hexVal[101]
            };
            jsonMsgs.Add(o101);

            myJasonDataIncoming o102 = new myJasonDataIncoming
            {
                active = cells[102].ToString(),
                hex = hexVal[102]
            };
            jsonMsgs.Add(o102);

            myJasonDataIncoming o103 = new myJasonDataIncoming
            {
                active = cells[103].ToString(),
                hex = hexVal[103]
            };
            jsonMsgs.Add(o103);

            myJasonDataIncoming o104 = new myJasonDataIncoming
            {
                active = cells[104].ToString(),
                hex = hexVal[104]
            };
            jsonMsgs.Add(o104);

            myJasonDataIncoming o105 = new myJasonDataIncoming
            {
                active = cells[105].ToString(),
                hex = hexVal[105]
            };
            jsonMsgs.Add(o105);

            myJasonDataIncoming o106 = new myJasonDataIncoming
            {
                active = cells[106].ToString(),
                hex = hexVal[106]
            };
            jsonMsgs.Add(o106);

            myJasonDataIncoming o107 = new myJasonDataIncoming
            {
                active = cells[107].ToString(),
                hex = hexVal[107]
            };
            jsonMsgs.Add(o107);

            myJasonDataIncoming o108 = new myJasonDataIncoming
            {
                active = cells[108].ToString(),
                hex = hexVal[108]
            };
            jsonMsgs.Add(o108);

            myJasonDataIncoming o109 = new myJasonDataIncoming
            {
                active = cells[109].ToString(),
                hex = hexVal[109]
            };
            jsonMsgs.Add(o109);

            myJasonDataIncoming o110 = new myJasonDataIncoming
            {
                active = cells[110].ToString(),
                hex = hexVal[110]
            };
            jsonMsgs.Add(o110);

            myJasonDataIncoming o111 = new myJasonDataIncoming
            {
                active = cells[111].ToString(),
                hex = hexVal[111]
            };
            jsonMsgs.Add(o111);

            myJasonDataIncoming o112 = new myJasonDataIncoming
            {
                active = cells[112].ToString(),
                hex = hexVal[112]
            };
            jsonMsgs.Add(o112);

            myJasonDataIncoming o113 = new myJasonDataIncoming
            {
                active = cells[113].ToString(),
                hex = hexVal[113]
            };
            jsonMsgs.Add(o113);

            myJasonDataIncoming o114 = new myJasonDataIncoming
            {
                active = cells[114].ToString(),
                hex = hexVal[114]
            };
            jsonMsgs.Add(o114);

            myJasonDataIncoming o115 = new myJasonDataIncoming
            {
                active = cells[115].ToString(),
                hex = hexVal[115]
            };
            jsonMsgs.Add(o115);

            myJasonDataIncoming o116 = new myJasonDataIncoming
            {
                active = cells[116].ToString(),
                hex = hexVal[116]
            };
            jsonMsgs.Add(o116);

            myJasonDataIncoming o117 = new myJasonDataIncoming
            {
                active = cells[117].ToString(),
                hex = hexVal[117]
            };
            jsonMsgs.Add(o117);

            myJasonDataIncoming o118 = new myJasonDataIncoming
            {
                active = cells[118].ToString(),
                hex = hexVal[118]
            };
            jsonMsgs.Add(o118);

            myJasonDataIncoming o119 = new myJasonDataIncoming
            {
                active = cells[119].ToString(),
                hex = hexVal[119]
            };
            jsonMsgs.Add(o119);

            myJasonDataIncoming o120 = new myJasonDataIncoming
            {
                active = cells[120].ToString(),
                hex = hexVal[120]
            };
            jsonMsgs.Add(o120);

            myJasonDataIncoming o121 = new myJasonDataIncoming
            {
                active = cells[121].ToString(),
                hex = hexVal[121]
            };
            jsonMsgs.Add(o121);

            myJasonDataIncoming o122 = new myJasonDataIncoming
            {
                active = cells[122].ToString(),
                hex = hexVal[122]
            };
            jsonMsgs.Add(o122);

            myJasonDataIncoming o123 = new myJasonDataIncoming
            {
                active = cells[123].ToString(),
                hex = hexVal[123]
            };
            jsonMsgs.Add(o123);

            myJasonDataIncoming o124 = new myJasonDataIncoming
            {
                active = cells[124].ToString(),
                hex = hexVal[124]
            };
            jsonMsgs.Add(o124);

            myJasonDataIncoming o125 = new myJasonDataIncoming
            {
                active = cells[125].ToString(),
                hex = hexVal[125]
            };
            jsonMsgs.Add(o125);

            myJasonDataIncoming o126 = new myJasonDataIncoming
            {
                active = cells[126].ToString(),
                hex = hexVal[126]
            };
            jsonMsgs.Add(o126);

            myJasonDataIncoming o127 = new myJasonDataIncoming
            {
                active = cells[127].ToString(),
                hex = hexVal[127]
            };
            jsonMsgs.Add(o127);

            myJasonDataIncoming o128 = new myJasonDataIncoming
            {
                active = cells[128].ToString(),
                hex = hexVal[128]
            };
            jsonMsgs.Add(o128);

            myJasonDataIncoming o129 = new myJasonDataIncoming
            {
                active = cells[129].ToString(),
                hex = hexVal[129]
            };
            jsonMsgs.Add(o129);

            myJasonDataIncoming o130 = new myJasonDataIncoming
            {
                active = cells[130].ToString(),
                hex = hexVal[130]
            };
            jsonMsgs.Add(o130);

            myJasonDataIncoming o131 = new myJasonDataIncoming
            {
                active = cells[131].ToString(),
                hex = hexVal[131]
            };
            jsonMsgs.Add(o131);

            myJasonDataIncoming o132 = new myJasonDataIncoming
            {
                active = cells[132].ToString(),
                hex = hexVal[132]
            };
            jsonMsgs.Add(o132);

            myJasonDataIncoming o133 = new myJasonDataIncoming
            {
                active = cells[133].ToString(),
                hex = hexVal[133]
            };
            jsonMsgs.Add(o133);

            myJasonDataIncoming o134 = new myJasonDataIncoming
            {
                active = cells[134].ToString(),
                hex = hexVal[134]
            };
            jsonMsgs.Add(o134);

            myJasonDataIncoming o135 = new myJasonDataIncoming
            {
                active = cells[135].ToString(),
                hex = hexVal[135]
            };
            jsonMsgs.Add(o135);

            myJasonDataIncoming o136 = new myJasonDataIncoming
            {
                active = cells[136].ToString(),
                hex = hexVal[136]
            };
            jsonMsgs.Add(o136);

            myJasonDataIncoming o137 = new myJasonDataIncoming
            {
                active = cells[137].ToString(),
                hex = hexVal[137]
            };
            jsonMsgs.Add(o137);

            myJasonDataIncoming o138 = new myJasonDataIncoming
            {
                active = cells[138].ToString(),
                hex = hexVal[138]
            };
            jsonMsgs.Add(o138);

            myJasonDataIncoming o139 = new myJasonDataIncoming
            {
                active = cells[139].ToString(),
                hex = hexVal[139]
            };
            jsonMsgs.Add(o139);

            myJasonDataIncoming o140 = new myJasonDataIncoming
            {
                active = cells[140].ToString(),
                hex = hexVal[140]
            };
            jsonMsgs.Add(o140);

            myJasonDataIncoming o141 = new myJasonDataIncoming
            {
                active = cells[141].ToString(),
                hex = hexVal[141]
            };
            jsonMsgs.Add(o141);

            myJasonDataIncoming o142 = new myJasonDataIncoming
            {
                active = cells[142].ToString(),
                hex = hexVal[142]
            };
            jsonMsgs.Add(o142);

            myJasonDataIncoming o143 = new myJasonDataIncoming
            {
                active = cells[143].ToString(),
                hex = hexVal[143]
            };
            jsonMsgs.Add(o143);

            myJasonDataIncoming o144 = new myJasonDataIncoming
            {
                active = cells[144].ToString(),
                hex = hexVal[144]
            };
            jsonMsgs.Add(o144);

            myJasonDataIncoming o145 = new myJasonDataIncoming
            {
                active = cells[145].ToString(),
                hex = hexVal[145]
            };
            jsonMsgs.Add(o145);

            myJasonDataIncoming o146 = new myJasonDataIncoming
            {
                active = cells[146].ToString(),
                hex = hexVal[146]
            };
            jsonMsgs.Add(o146);

            myJasonDataIncoming o147 = new myJasonDataIncoming
            {
                active = cells[147].ToString(),
                hex = hexVal[147]
            };
            jsonMsgs.Add(o147);

            myJasonDataIncoming o148 = new myJasonDataIncoming
            {
                active = cells[148].ToString(),
                hex = hexVal[148]
            };
            jsonMsgs.Add(o148);

            myJasonDataIncoming o149 = new myJasonDataIncoming
            {
                active = cells[149].ToString(),
                hex = hexVal[149]
            };
            jsonMsgs.Add(o149);

            myJasonDataIncoming o150 = new myJasonDataIncoming
            {
                active = cells[150].ToString(),
                hex = hexVal[150]
            };
            jsonMsgs.Add(o150);

            myJasonDataIncoming o151 = new myJasonDataIncoming
            {
                active = cells[151].ToString(),
                hex = hexVal[151]
            };
            jsonMsgs.Add(o151);

            myJasonDataIncoming o152 = new myJasonDataIncoming
            {
                active = cells[152].ToString(),
                hex = hexVal[152]
            };
            jsonMsgs.Add(o152);

            myJasonDataIncoming o153 = new myJasonDataIncoming
            {
                active = cells[153].ToString(),
                hex = hexVal[153]
            };
            jsonMsgs.Add(o153);

            myJasonDataIncoming o154 = new myJasonDataIncoming
            {
                active = cells[154].ToString(),
                hex = hexVal[154]
            };
            jsonMsgs.Add(o154);

            myJasonDataIncoming o155 = new myJasonDataIncoming
            {
                active = cells[155].ToString(),
                hex = hexVal[155]
            };
            jsonMsgs.Add(o155);

            myJasonDataIncoming o156 = new myJasonDataIncoming
            {
                active = cells[156].ToString(),
                hex = hexVal[156]
            };
            jsonMsgs.Add(o156);

            myJasonDataIncoming o157 = new myJasonDataIncoming
            {
                active = cells[157].ToString(),
                hex = hexVal[157]
            };
            jsonMsgs.Add(o157);

            myJasonDataIncoming o158 = new myJasonDataIncoming
            {
                active = cells[158].ToString(),
                hex = hexVal[158]
            };
            jsonMsgs.Add(o158);

            myJasonDataIncoming o159 = new myJasonDataIncoming
            {
                active = cells[159].ToString(),
                hex = hexVal[159]
            };
            jsonMsgs.Add(o159);

            myJasonDataIncoming o160 = new myJasonDataIncoming
            {
                active = cells[160].ToString(),
                hex = hexVal[160]
            };
            jsonMsgs.Add(o160);

            myJasonDataIncoming o161 = new myJasonDataIncoming
            {
                active = cells[161].ToString(),
                hex = hexVal[161]
            };
            jsonMsgs.Add(o161);

            myJasonDataIncoming o162 = new myJasonDataIncoming
            {
                active = cells[162].ToString(),
                hex = hexVal[162]
            };
            jsonMsgs.Add(o162);

            myJasonDataIncoming o163 = new myJasonDataIncoming
            {
                active = cells[163].ToString(),
                hex = hexVal[163]
            };
            jsonMsgs.Add(o163);

            myJasonDataIncoming o164 = new myJasonDataIncoming
            {
                active = cells[164].ToString(),
                hex = hexVal[164]
            };
            jsonMsgs.Add(o164);

            myJasonDataIncoming o165 = new myJasonDataIncoming
            {
                active = cells[165].ToString(),
                hex = hexVal[165]
            };
            jsonMsgs.Add(o165);

            myJasonDataIncoming o166 = new myJasonDataIncoming
            {
                active = cells[166].ToString(),
                hex = hexVal[166]
            };
            jsonMsgs.Add(o166);

            myJasonDataIncoming o167 = new myJasonDataIncoming
            {
                active = cells[167].ToString(),
                hex = hexVal[167]
            };
            jsonMsgs.Add(o167);

            myJasonDataIncoming o168 = new myJasonDataIncoming
            {
                active = cells[168].ToString(),
                hex = hexVal[168]
            };
            jsonMsgs.Add(o168);

            myJasonDataIncoming o169 = new myJasonDataIncoming
            {
                active = cells[169].ToString(),
                hex = hexVal[169]
            };
            jsonMsgs.Add(o169);

            myJasonDataIncoming o170 = new myJasonDataIncoming
            {
                active = cells[170].ToString(),
                hex = hexVal[170]
            };
            jsonMsgs.Add(o170);

            myJasonDataIncoming o171 = new myJasonDataIncoming
            {
                active = cells[171].ToString(),
                hex = hexVal[171]
            };
            jsonMsgs.Add(o171);

            myJasonDataIncoming o172 = new myJasonDataIncoming
            {
                active = cells[172].ToString(),
                hex = hexVal[172]
            };
            jsonMsgs.Add(o172);

            myJasonDataIncoming o173 = new myJasonDataIncoming
            {
                active = cells[173].ToString(),
                hex = hexVal[173]
            };
            jsonMsgs.Add(o173);

            myJasonDataIncoming o174 = new myJasonDataIncoming
            {
                active = cells[174].ToString(),
                hex = hexVal[174]
            };
            jsonMsgs.Add(o174);

            myJasonDataIncoming o175 = new myJasonDataIncoming
            {
                active = cells[175].ToString(),
                hex = hexVal[175]
            };
            jsonMsgs.Add(o175);

            myJasonDataIncoming o176 = new myJasonDataIncoming
            {
                active = cells[176].ToString(),
                hex = hexVal[176]
            };
            jsonMsgs.Add(o176);

            myJasonDataIncoming o177 = new myJasonDataIncoming
            {
                active = cells[177].ToString(),
                hex = hexVal[177]
            };
            jsonMsgs.Add(o177);

            myJasonDataIncoming o178 = new myJasonDataIncoming
            {
                active = cells[178].ToString(),
                hex = hexVal[178]
            };
            jsonMsgs.Add(o178);

            myJasonDataIncoming o179 = new myJasonDataIncoming
            {
                active = cells[179].ToString(),
                hex = hexVal[179]
            };
            jsonMsgs.Add(o179);

            myJasonDataIncoming o180 = new myJasonDataIncoming
            {
                active = cells[180].ToString(),
                hex = hexVal[180]
            };
            jsonMsgs.Add(o180);

            myJasonDataIncoming o181 = new myJasonDataIncoming
            {
                active = cells[181].ToString(),
                hex = hexVal[181]
            };
            jsonMsgs.Add(o181);

            myJasonDataIncoming o182 = new myJasonDataIncoming
            {
                active = cells[182].ToString(),
                hex = hexVal[182]
            };
            jsonMsgs.Add(o182);

            myJasonDataIncoming o183 = new myJasonDataIncoming
            {
                active = cells[183].ToString(),
                hex = hexVal[183]
            };
            jsonMsgs.Add(o183);

            myJasonDataIncoming o184 = new myJasonDataIncoming
            {
                active = cells[184].ToString(),
                hex = hexVal[184]
            };
            jsonMsgs.Add(o184);

            myJasonDataIncoming o185 = new myJasonDataIncoming
            {
                active = cells[185].ToString(),
                hex = hexVal[185]
            };
            jsonMsgs.Add(o185);

            myJasonDataIncoming o186 = new myJasonDataIncoming
            {
                active = cells[186].ToString(),
                hex = hexVal[186]
            };
            jsonMsgs.Add(o186);

            myJasonDataIncoming o187 = new myJasonDataIncoming
            {
                active = cells[187].ToString(),
                hex = hexVal[187]
            };
            jsonMsgs.Add(o187);

            myJasonDataIncoming o188 = new myJasonDataIncoming
            {
                active = cells[188].ToString(),
                hex = hexVal[188]
            };
            jsonMsgs.Add(o188);

            myJasonDataIncoming o189 = new myJasonDataIncoming
            {
                active = cells[189].ToString(),
                hex = hexVal[189]
            };
            jsonMsgs.Add(o189);

            myJasonDataIncoming o190 = new myJasonDataIncoming
            {
                active = cells[190].ToString(),
                hex = hexVal[190]
            };
            jsonMsgs.Add(o190);

            myJasonDataIncoming o191 = new myJasonDataIncoming
            {
                active = cells[191].ToString(),
                hex = hexVal[191]
            };
            jsonMsgs.Add(o191);

            myJasonDataIncoming o192 = new myJasonDataIncoming
            {
                active = cells[192].ToString(),
                hex = hexVal[192]
            };
            jsonMsgs.Add(o192);

            myJasonDataIncoming o193 = new myJasonDataIncoming
            {
                active = cells[193].ToString(),
                hex = hexVal[193]
            };
            jsonMsgs.Add(o193);

            myJasonDataIncoming o194 = new myJasonDataIncoming
            {
                active = cells[194].ToString(),
                hex = hexVal[194]
            };
            jsonMsgs.Add(o194);

            myJasonDataIncoming o195 = new myJasonDataIncoming
            {
                active = cells[195].ToString(),
                hex = hexVal[195]
            };
            jsonMsgs.Add(o195);

            myJasonDataIncoming o196 = new myJasonDataIncoming
            {
                active = cells[196].ToString(),
                hex = hexVal[196]
            };
            jsonMsgs.Add(o196);

            myJasonDataIncoming o197 = new myJasonDataIncoming
            {
                active = cells[197].ToString(),
                hex = hexVal[197]
            };
            jsonMsgs.Add(o197);

            myJasonDataIncoming o198 = new myJasonDataIncoming
            {
                active = cells[198].ToString(),
                hex = hexVal[198]
            };
            jsonMsgs.Add(o198);

            myJasonDataIncoming o199 = new myJasonDataIncoming
            {
                active = cells[199].ToString(),
                hex = hexVal[199]
            };
            jsonMsgs.Add(o199);

            myJasonDataIncoming o200 = new myJasonDataIncoming
            {
                active = cells[200].ToString(),
                hex = hexVal[200]
            };
            jsonMsgs.Add(o200);

            myJasonDataIncoming o201 = new myJasonDataIncoming
            {
                active = cells[201].ToString(),
                hex = hexVal[201]
            };
            jsonMsgs.Add(o201);

            myJasonDataIncoming o202 = new myJasonDataIncoming
            {
                active = cells[202].ToString(),
                hex = hexVal[202]
            };
            jsonMsgs.Add(o202);

            myJasonDataIncoming o203 = new myJasonDataIncoming
            {
                active = cells[203].ToString(),
                hex = hexVal[203]
            };
            jsonMsgs.Add(o203);

            myJasonDataIncoming o204 = new myJasonDataIncoming
            {
                active = cells[204].ToString(),
                hex = hexVal[204]
            };
            jsonMsgs.Add(o204);

            myJasonDataIncoming o205 = new myJasonDataIncoming
            {
                active = cells[205].ToString(),
                hex = hexVal[205]
            };
            jsonMsgs.Add(o205);

            myJasonDataIncoming o206 = new myJasonDataIncoming
            {
                active = cells[206].ToString(),
                hex = hexVal[206]
            };
            jsonMsgs.Add(o206);

            myJasonDataIncoming o207 = new myJasonDataIncoming
            {
                active = cells[207].ToString(),
                hex = hexVal[207]
            };
            jsonMsgs.Add(o207);

            myJasonDataIncoming o208 = new myJasonDataIncoming
            {
                active = cells[208].ToString(),
                hex = hexVal[208]
            };
            jsonMsgs.Add(o208);

            myJasonDataIncoming o209 = new myJasonDataIncoming
            {
                active = cells[209].ToString(),
                hex = hexVal[209]
            };
            jsonMsgs.Add(o209);

            myJasonDataIncoming o210 = new myJasonDataIncoming
            {
                active = cells[210].ToString(),
                hex = hexVal[210]
            };
            jsonMsgs.Add(o210);

            myJasonDataIncoming o211 = new myJasonDataIncoming
            {
                active = cells[211].ToString(),
                hex = hexVal[211]
            };
            jsonMsgs.Add(o211);

            myJasonDataIncoming o212 = new myJasonDataIncoming
            {
                active = cells[212].ToString(),
                hex = hexVal[212]
            };
            jsonMsgs.Add(o212);

            myJasonDataIncoming o213 = new myJasonDataIncoming
            {
                active = cells[213].ToString(),
                hex = hexVal[213]
            };
            jsonMsgs.Add(o213);

            myJasonDataIncoming o214 = new myJasonDataIncoming
            {
                active = cells[214].ToString(),
                hex = hexVal[214]
            };
            jsonMsgs.Add(o214);

            myJasonDataIncoming o215 = new myJasonDataIncoming
            {
                active = cells[215].ToString(),
                hex = hexVal[215]
            };
            jsonMsgs.Add(o215);

            myJasonDataIncoming o216 = new myJasonDataIncoming
            {
                active = cells[216].ToString(),
                hex = hexVal[216]
            };
            jsonMsgs.Add(o216);

            myJasonDataIncoming o217 = new myJasonDataIncoming
            {
                active = cells[217].ToString(),
                hex = hexVal[217]
            };
            jsonMsgs.Add(o217);

            myJasonDataIncoming o218 = new myJasonDataIncoming
            {
                active = cells[218].ToString(),
                hex = hexVal[218]
            };
            jsonMsgs.Add(o218);

            myJasonDataIncoming o219 = new myJasonDataIncoming
            {
                active = cells[219].ToString(),
                hex = hexVal[219]
            };
            jsonMsgs.Add(o219);

            myJasonDataIncoming o220 = new myJasonDataIncoming
            {
                active = cells[220].ToString(),
                hex = hexVal[220]
            };
            jsonMsgs.Add(o220);

            myJasonDataIncoming o221 = new myJasonDataIncoming
            {
                active = cells[221].ToString(),
                hex = hexVal[221]
            };
            jsonMsgs.Add(o221);

            myJasonDataIncoming o222 = new myJasonDataIncoming
            {
                active = cells[222].ToString(),
                hex = hexVal[222]
            };
            jsonMsgs.Add(o222);

            myJasonDataIncoming o223 = new myJasonDataIncoming
            {
                active = cells[223].ToString(),
                hex = hexVal[223]
            };
            jsonMsgs.Add(o223);

            myJasonDataIncoming o224 = new myJasonDataIncoming
            {
                active = cells[224].ToString(),
                hex = hexVal[224]
            };
            jsonMsgs.Add(o224);

            myJasonDataIncoming o225 = new myJasonDataIncoming
            {
                active = cells[225].ToString(),
                hex = hexVal[225]
            };
            jsonMsgs.Add(o225);

            myJasonDataIncoming o226 = new myJasonDataIncoming
            {
                active = cells[226].ToString(),
                hex = hexVal[226]
            };
            jsonMsgs.Add(o226);

            myJasonDataIncoming o227 = new myJasonDataIncoming
            {
                active = cells[227].ToString(),
                hex = hexVal[227]
            };
            jsonMsgs.Add(o227);

            myJasonDataIncoming o228 = new myJasonDataIncoming
            {
                active = cells[228].ToString(),
                hex = hexVal[228]
            };
            jsonMsgs.Add(o228);

            myJasonDataIncoming o229 = new myJasonDataIncoming
            {
                active = cells[229].ToString(),
                hex = hexVal[229]
            };
            jsonMsgs.Add(o229);

            myJasonDataIncoming o230 = new myJasonDataIncoming
            {
                active = cells[230].ToString(),
                hex = hexVal[230]
            };
            jsonMsgs.Add(o230);

            myJasonDataIncoming o231 = new myJasonDataIncoming
            {
                active = cells[231].ToString(),
                hex = hexVal[231]
            };
            jsonMsgs.Add(o231);

            myJasonDataIncoming o232 = new myJasonDataIncoming
            {
                active = cells[232].ToString(),
                hex = hexVal[232]
            };
            jsonMsgs.Add(o232);

            myJasonDataIncoming o233 = new myJasonDataIncoming
            {
                active = cells[233].ToString(),
                hex = hexVal[233]
            };
            jsonMsgs.Add(o233);

            myJasonDataIncoming o234 = new myJasonDataIncoming
            {
                active = cells[234].ToString(),
                hex = hexVal[234]
            };
            jsonMsgs.Add(o234);

            myJasonDataIncoming o235 = new myJasonDataIncoming
            {
                active = cells[235].ToString(),
                hex = hexVal[235]
            };
            jsonMsgs.Add(o235);

            myJasonDataIncoming o236 = new myJasonDataIncoming
            {
                active = cells[236].ToString(),
                hex = hexVal[236]
            };
            jsonMsgs.Add(o236);

            myJasonDataIncoming o237 = new myJasonDataIncoming
            {
                active = cells[237].ToString(),
                hex = hexVal[237]
            };
            jsonMsgs.Add(o237);

            myJasonDataIncoming o238 = new myJasonDataIncoming
            {
                active = cells[238].ToString(),
                hex = hexVal[238]
            };
            jsonMsgs.Add(o238);

            myJasonDataIncoming o239 = new myJasonDataIncoming
            {
                active = cells[239].ToString(),
                hex = hexVal[239]
            };
            jsonMsgs.Add(o239);

            myJasonDataIncoming o240 = new myJasonDataIncoming
            {
                active = cells[240].ToString(),
                hex = hexVal[240]
            };
            jsonMsgs.Add(o240);

            myJasonDataIncoming o241 = new myJasonDataIncoming
            {
                active = cells[241].ToString(),
                hex = hexVal[241]
            };
            jsonMsgs.Add(o241);

            myJasonDataIncoming o242 = new myJasonDataIncoming
            {
                active = cells[242].ToString(),
                hex = hexVal[242]
            };
            jsonMsgs.Add(o242);

            myJasonDataIncoming o243 = new myJasonDataIncoming
            {
                active = cells[243].ToString(),
                hex = hexVal[243]
            };
            jsonMsgs.Add(o243);

            myJasonDataIncoming o244 = new myJasonDataIncoming
            {
                active = cells[244].ToString(),
                hex = hexVal[244]
            };
            jsonMsgs.Add(o244);

            myJasonDataIncoming o245 = new myJasonDataIncoming
            {
                active = cells[245].ToString(),
                hex = hexVal[245]
            };
            jsonMsgs.Add(o245);

            myJasonDataIncoming o246 = new myJasonDataIncoming
            {
                active = cells[246].ToString(),
                hex = hexVal[246]
            };
            jsonMsgs.Add(o246);

            myJasonDataIncoming o247 = new myJasonDataIncoming
            {
                active = cells[247].ToString(),
                hex = hexVal[247]
            };
            jsonMsgs.Add(o247);

            myJasonDataIncoming o248 = new myJasonDataIncoming
            {
                active = cells[248].ToString(),
                hex = hexVal[248]
            };
            jsonMsgs.Add(o248);

            myJasonDataIncoming o249 = new myJasonDataIncoming
            {
                active = cells[249].ToString(),
                hex = hexVal[249]
            };
            jsonMsgs.Add(o249);

            myJasonDataIncoming o250 = new myJasonDataIncoming
            {
                active = cells[250].ToString(),
                hex = hexVal[250]
            };
            jsonMsgs.Add(o250);

            myJasonDataIncoming o251 = new myJasonDataIncoming
            {
                active = cells[251].ToString(),
                hex = hexVal[251]
            };
            jsonMsgs.Add(o251);

            myJasonDataIncoming o252 = new myJasonDataIncoming
            {
                active = cells[252].ToString(),
                hex = hexVal[252]
            };
            jsonMsgs.Add(o252);

            myJasonDataIncoming o253 = new myJasonDataIncoming
            {
                active = cells[253].ToString(),
                hex = hexVal[253]
            };
            jsonMsgs.Add(o253);

            myJasonDataIncoming o254 = new myJasonDataIncoming
            {
                active = cells[254].ToString(),
                hex = hexVal[254]
            };
            jsonMsgs.Add(o254);

            myJasonDataIncoming o255 = new myJasonDataIncoming
            {
                active = cells[255].ToString(),
                hex = hexVal[255]
            };
            jsonMsgs.Add(o255);



            string json = JsonConvert.SerializeObject(jsonMsgs, Formatting.Indented);
        }



        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(2000);
            //updates the alive array - below needs to be updated with the method name for calling the update.
            aTimer.Elapsed += Logic;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;



        }

        private static void startButton()
        {
            // sets timer to start the game and the logic once the start button is pressed.
            SetTimer();


        }

        private static void stopButton()
        {
            aTimer.Stop();
        }

        private static void reset()
        {
            aTimer.Stop();
            for (int i = 0; i < 256; i++)
            {
                cells[i] = 0;
            }

            for (int j = 0; j < 256; j++)
            {
                hexVal[j] = "ffffff";
            }

            jsonConversionToJS();
        }

    }
}
