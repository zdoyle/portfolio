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
    public class GameManager
    {
        private GameView _gameView = new GameView();
        private GameInput _gameInput = new GameInput();
        //private string _p1Name;
        //private string _p2Name;
        Player p1 = new Player();
        Player p2 = new Player();
        public GameManager(GameView gv, GameInput gi)
        {
            _gameView = gv;
            _gameInput = gi;
        }

        public void PlayGame()
        {
            // display welcome screen
            _gameView.DisplayWelcome();

            // prompt for player names
            _gameInput.PromptForPlayerNames(p1, p2);


            // place ships
            _gameView.ClearRoomPrompt(p1, p2);
            PlaceShip(p1.PlayerBoard, p1.Name);
            _gameView.ClearRoomPrompt(p2, p1);
            PlaceShip(p2.PlayerBoard, p2.Name);

            // start taking turns
            HandlePlayerTurn();

            // play agian?
            PlayAgainPrompt();
        }

        public void HandlePlayerTurn()
        {
            ShotStatus status = ShotStatus.Invalid;

            while (status != ShotStatus.Victory)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (i == 0)
                    {
                        status = TakeTurn(p1, p2);
                    }
                    else
                    {
                        status = TakeTurn(p2, p1);
                    }

                    if (status == ShotStatus.Victory)
                    {
                        break;
                    }
                }
            }
        }

        public void PlaceShip(Board board, string currentPlayerName)
        {

            
            

            int shipType = 0;
            

            do
            {
                int moveOn = 0;

                _gameView.DisplayShipPlacement(board);

                Coordinate coord = _gameInput.PromptForCoordinate(string.Format("\n\n{0}, select a coordinate to place your {1} (e.g. A2): ", currentPlayerName, (ShipType)shipType));

                do
                {
                    Console.WriteLine("\nUsing a numeric value, which direction would you like to point your {1}, {0}?", currentPlayerName, (ShipType)shipType);
                    Console.Write("1 = Up, 2 = Down, 3 = Left, 4 = Right: ");
                    string shipDirectionString = Console.ReadLine();
                    if (shipDirectionString == "1" || shipDirectionString == "2" || shipDirectionString == "3" || shipDirectionString == "4")
                    {
                        int shipDirection = Convert.ToInt32(shipDirectionString);
                        moveOn++;

                        if (coord.XCoordinate >= 1 && coord.XCoordinate <= 10 && coord.YCoordinate >= 1 && coord.YCoordinate <= 10)
                        {
                            PlaceShipRequest placementRequest = new PlaceShipRequest();
                            placementRequest.ShipType = (ShipType)shipType;
                            placementRequest.Coordinate = coord;
                            placementRequest.Direction = (ShipDirection)shipDirection - 1;

                            ShipPlacement shipPlacement = board.PlaceShip(placementRequest);

                            switch (shipPlacement)
                            {
                                case ShipPlacement.NotEnoughSpace:
                                    Console.Write("There is not enough space on the board for you {0}.  Press any key to give a new coordinate.", (ShipType)shipType);
                                    Console.ReadKey();
                                    break;
                                case ShipPlacement.Overlap:
                                    Console.Write("Your {0} overlaps with an already placed ship.  Press any key to give a new coordinate.", (ShipType)shipType);
                                    Console.ReadKey();
                                    break;
                                case ShipPlacement.Ok:
                                    shipType++;
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            Console.Write("\nThe coordinate you gave was invalid.  Press any key to give a new coordinate.", (ShipType)shipType);
                            Console.ReadKey();
                        }

                        Console.Clear();
                    }
                    else
                    {
                        Console.Write("\nThat was not a valid ship direction. Please give a new ship direction.\n");
                    } 
                } while (moveOn == 0);
            } while (shipType < 5);


        }

        public ShotStatus TakeTurn(Player currentPlayer, Player enemyPlayer)
        {
            FireShotResponse response;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n  {0}'s Hits/Misses on {1}'s Board",currentPlayer.Name, enemyPlayer.Name);
                _gameView.DisplayBoardShotHistory(enemyPlayer.PlayerBoard);

                Coordinate coord = _gameInput.PromptForCoordinate(string.Format("\n\n{0}, please enter a coordinate to fire a shot: ", currentPlayer.Name));
                response = enemyPlayer.PlayerBoard.FireShot(coord);
                if ((int)response.ShotStatus > 1)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n  {0}'s Hits/Misses on {1}'s Board", currentPlayer.Name, enemyPlayer.Name);
                    _gameView.DisplayBoardShotHistory(enemyPlayer.PlayerBoard);
                    break;
                }
            }

            switch (response.ShotStatus)
            {
                case ShotStatus.Miss:
                    Console.WriteLine("\n\nSorry, {0}! Your shot missed {1} ships!\n", currentPlayer.Name, enemyPlayer.Name);
                    break;
                case ShotStatus.Hit:
                    Console.WriteLine("\n\nCongratulations, {0}! You hit one of {1}'s ships!\n", currentPlayer.Name, enemyPlayer.Name);
                    break;
                case ShotStatus.HitAndSunk:
                    Console.WriteLine("\n\nCongratulations, {0}! You hit and sank {1}'s {2}!\n", currentPlayer.Name, enemyPlayer.Name, response.ShipImpacted);
                    break;
                case ShotStatus.Victory:
                    Console.WriteLine("\n\nCongratulations, {0}! You hit and sank {1}'s {2} and won the game!\n", currentPlayer.Name, enemyPlayer.Name, response.ShipImpacted);
                    break;
            }
            Console.Write("Press any key to continue... ");
            Console.ReadKey();
            Console.Clear();
            return response.ShotStatus;
        }

        public void PlayAgainPrompt() //did I do this right??
        {
            Console.Clear();
            Console.Write("Game over! Thanks for playing! Do you want to play again (Y/N)?: ");
            string playAgain = Console.ReadLine().ToUpper();

            if (playAgain == "Y")
            {
                PlayGame();
            }
        }
    }
}
