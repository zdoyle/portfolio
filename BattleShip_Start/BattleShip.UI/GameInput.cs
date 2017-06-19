using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class GameInput
    {
        //GameView _gameView = new GameView();
        //GameInput _gameInput = new GameInput();
        //GameManager gm = new GameManager();

        public void PromptForPlayerNames(Player p1, Player p2)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Thank you for playing!\n");
                Console.Write("Player 1, please enter your name: ");
                p1.Name = Console.ReadLine();
                if (string.IsNullOrEmpty(p1.Name))
                {
                    continue;
                }
                //p1.Name = _p1Name;
                break;
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome, {0}!\n", p1.Name);
                Console.Write("Player 2, please enter your name: ");
                p2.Name = Console.ReadLine();
                if (string.IsNullOrEmpty(p2.Name))
                {
                    continue;
                }

                break;
            }
        }

        

        public Coordinate PromptForCoordinate(string message)
        {
            Console.Write(message);
            string shipCoord = Console.ReadLine();

            char charX = Char.ToUpper(shipCoord[0]);
            //Convert x to number:
            CoordinateConversion coordinateConversion = new CoordinateConversion();
            int x = coordinateConversion.translateLetterToNumber(charX);

            if (shipCoord.Length != 1)
            {
                int y = Convert.ToInt32(shipCoord.Substring(1));
                Coordinate coord = new Coordinate(x, y);
                return coord;
            }
            else
            {
                int y = -1;
                Coordinate coord = new Coordinate(x, y);
                return coord;
            }
            
            
        }
        

        

        

        
    }
}
