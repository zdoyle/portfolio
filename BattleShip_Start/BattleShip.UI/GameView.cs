using BattleShip.BLL.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class GameView
    {
        public void DisplayWelcome()
        {
            Console.Write("Welcome to BattleShip! Press any key to play!");
            Console.ReadKey();
            Console.Clear();
        }

        public void ClearRoomPrompt(Player currentPlayer, Player enemyPlayer)
        {
            Console.Clear();
            Console.WriteLine("Thank you, {0}! Please step away from the computer so that {1} can place his ships.\n", enemyPlayer.Name, currentPlayer.Name);
            Console.Write("{0}, once {1} is out of sight, press any key to continue...", currentPlayer.Name, enemyPlayer.Name);
            Console.ReadKey();
        }

        public void DisplayShipPlacement(Board board)
        {
            string[] letterArray = new string[] { "\n       A ", " B ", " C ", " D ", " E ", " F ", " G ", " H ", " I ", " J " };
            string[,] rowData = new string[10, 10] { { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                                                     { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                                                     { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                                                     { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                                                     { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                                                     { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                                                     { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                                                     { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                                                     { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
                                                     { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" } };

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Console.Write("\n  Your Game Board\n");


            for (int col = 0; col < 10; col++)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(letterArray[col]);
            }
            Console.Write("\n------------------------------------");

            for (int row = 1; row < 11; row++)
            {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(" \n {0} |  ", row.ToString().PadRight(2));
                    for (int i = 0; i < 10; i++)
                    {
                        Console.ResetColor();
                        Console.Write("{0}  ", rowData[row - 1, i]);
                    }
            }
        }

        public void DisplayBoardShotHistory(Board board)
        {
            string[] letterArray = new string[] { "\n      A ", " B ", " C ", " D ", " E ", " F ", " G ", " H ", " I ", " J " };

            


            for (int col = 0; col < 10; col++)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(letterArray[col]);
            }
            Console.Write("\n------------------------------------");

            for (int row = 1; row < 11; row++)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(" \n{0} |  ", row.ToString().PadRight(2));
                for (int i = 0; i < 10; i++)
                {
                    Console.ResetColor();
                    if (!board.ShotHistory.ContainsKey(new BLL.Requests.Coordinate(i + 1, row)))
                    {
                        Console.Write("{0}  ", "-");
                        continue;
                    }
                    switch (board.ShotHistory[new BLL.Requests.Coordinate(i + 1, row)])
                    {
                        case BLL.Responses.ShotHistory.Hit:
                            Console.Write("{0}  ", "H");
                            break;
                        case BLL.Responses.ShotHistory.Miss:
                            Console.Write("{0}  ", "M");
                            break;
                        case BLL.Responses.ShotHistory.Unknown:
                            Console.Write("{0}  ", "-");
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
