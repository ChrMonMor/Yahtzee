using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //-- TK (gonna make this into a game setting constructor and give it differnt values, depending on the game you are playing)
            string[] typeOfGame = NormalYahtzee();
            int numberOfPlayers = 1;
            int numberOfDiceRolls = 3;
            int numberOfDices = 5;
            int bonus = 50;

            //-- TK^^


            string[,] gameBoard = GameBoard(numberOfPlayers, typeOfGame);


            Console.Clear();
            GameBoardPrinter(gameBoard);
            string playerCommand = "";
            //-- Loop for the rounds 
            for (int round = 1; round < typeOfGame.Length; round++)
            {
                //-- the loop for a players turn, so we know whoes turn it is
                for (int turn = 1; turn <= numberOfPlayers; turn++)
                {
                    int[] playersDices = DiceRolledArray(numberOfDices);
                    //-- might change this to be a standalone method instead of a part of AddResultToGameboardFields, so that Sum is sperate  and skips the two rounds of "sum" and "bonus"
                    if (gameBoard[round, 0] == "Sum")
                    {
                        gameBoard[round, turn] = AddUpperSectionTogether(gameBoard, turn).ToString();
                        gameBoard[round + 1, turn] = CheckIfSumIsGoodForBonus(gameBoard, numberOfDices, bonus).ToString();
                        continue;
                    }
                    //-- might need to be change since it doesn't do anything but skip the players being in "bonus"-round
                    if (gameBoard[round, 0] == "Bonus")
                    {
                        continue;
                    }
                    if (gameBoard[round, 0] == "Total")
                    {
                        gameBoard[round, turn] = PlayersTotalScore(gameBoard, turn, round).ToString();
                        continue;
                    }

                    //-- loop for the number for rolls the player has
                    for (int timesRolled = 0; timesRolled < numberOfDiceRolls; timesRolled++)
                    {
                        Console.Clear();
                        GameBoardPrinter(gameBoard);
                        playersDices = playersDices.OrderBy(i => i).ToArray();
                        DiceArrayPrinter(playersDices);
                        //-- 
                        if (playerCommand == "stop" || timesRolled >= numberOfDiceRolls - 1)
                        {
                            gameBoard = AddResultToGameboardFields(playersDices, gameBoard, round, turn);
                            continue;
                        }
                        playerCommand = Console.ReadLine();
                        playersDices = DiceReRoller(playersDices, playerCommand);
                    }
                }
            }
            Console.Clear();
            GameBoardPrinter(gameBoard);
            Console.WriteLine("Game is Done");
            Console.ReadLine();
        }

        //-- TK
        public static string[,] AddResultToGameboardFields(int[] playersDices, string[,] gameBoard, int round, int turn)
        {
            switch (gameBoard[round,0])
            {
                case "Ene'ere":
                    gameBoard[round,turn] = SingleUpperSectionCalculator(playersDices, 1).ToString();
                    break;
                case "To'ere":
                    gameBoard[round, turn] = SingleUpperSectionCalculator(playersDices, 2).ToString();
                    break;
                case "Tre'ere":
                    gameBoard[round, turn] = SingleUpperSectionCalculator(playersDices, 3).ToString();
                    break;
                case "Fire'ere":
                    gameBoard[round, turn] = SingleUpperSectionCalculator(playersDices, 4).ToString();
                    break;
                case "Fem'ere":
                    gameBoard[round, turn] = SingleUpperSectionCalculator(playersDices, 5).ToString();
                    break;
                case "Seks'ere":
                    gameBoard[round, turn] = SingleUpperSectionCalculator(playersDices, 6).ToString();
                    break;
                case "Et Par":
                    gameBoard[round, turn] = DiceOfKindsLowerSectionCalculator(playersDices, 2, 1, false).ToString();
                    break;
                case "To Par":
                    gameBoard[round, turn] = DiceOfKindsLowerSectionCalculator(playersDices, 2, 2, false).ToString();
                    break;
                case "Tre Par":
                    gameBoard[round, turn] = DiceOfKindsLowerSectionCalculator(playersDices, 2, 3, false).ToString();
                    break;
                case "Tre enes":
                    gameBoard[round, turn] = DiceOfKindsLowerSectionCalculator(playersDices, 3, 1, false).ToString();
                    break;
                //-- Not too happy about this one, maybe there is a way to make this be a combo of both "Tre enes" & "To Par" 
                case "To Par Tre enes":
                    gameBoard[round, turn] = DiceOfKindsLowerSectionCalculator(playersDices, 3, 2, false).ToString();
                    break;
                case "Fire enes":
                    gameBoard[round, turn] = DiceOfKindsLowerSectionCalculator(playersDices, 4, 1, false).ToString();
                    break;
                case "Fem enes":
                    gameBoard[round, turn] = DiceOfKindsLowerSectionCalculator(playersDices, 5, 1, false).ToString();
                    break;
                case "Den Lille":
                    gameBoard[round, turn] = DiceInARowLowerSectionCalculator(playersDices, 1, 5).ToString();
                    break;
                case "Den Store":
                    gameBoard[round, turn] = DiceInARowLowerSectionCalculator(playersDices, 2, 5).ToString();
                    break;
                case "Cameron":
                    gameBoard[round, turn] = DiceInARowLowerSectionCalculator(playersDices, 1, 6).ToString();
                    break;
                case "Fuld Hus":
                    gameBoard[round, turn] = DiceOfKindsLowerSectionCalculator(playersDices, 5, 1, true).ToString();
                    break;
                case "Changen":
                    gameBoard[round, turn] = playersDices.Sum().ToString();
                    break;
                case "Yathzee":
                    gameBoard[round, turn] = DiceOfKindsLowerSectionCalculator(playersDices, playersDices.Length, 1, false).ToString();
                    break;
                default:
                    break;
            }
            return gameBoard;
        }

        public static int PlayersTotalScore(string[,] gameBoard, int turn, int round)
        {
            int score = 0;
            //-- here we find out where we are starting the score-count from
            for (int i = 0; i < round; i++)
            {
                if(gameBoard[i, 0] == "Sum")
                {
                    continue;
                }
                score += Convert.ToInt32(gameBoard[i, turn]);
            }

            return score;
        }

        //-- Counts up the dice the user has in a row, it starts looking for the "smallest" and ends if it got all the way up to the biggest and returns a value 
        public static int DiceInARowLowerSectionCalculator(int[] playersDices, int smallest, int biggest)
        {
            int sum = 0;
            if (biggest == 6)
            {
                sum = 9;
            }
            playersDices = playersDices.OrderBy(i => i).ToArray();
            for (int i = 0; i < biggest; i++)
            {
                if(!Array.Exists(playersDices, x => x == smallest))
                {
                    return 0;
                }
                sum += smallest;
                smallest++;
            }
            return sum;
        }

        //-- TK^^

        //-- an Calculator for a single section in the Upper-Section
        public static int SingleUpperSectionCalculator(int[] playersDices, int sectorNumber)
        {
            int sum = 0;
            foreach (var dice in playersDices)
            {
                if (dice == sectorNumber) sum += dice;
            }
            return sum;
        }
        //-- gets the total sum of a players Upper-Section and returns a int
        public static int AddUpperSectionTogether(string[,] gameBoard, int turn)
        {
            //-- might change the hardcoded number here
            int[] vs = new int[6];
            for (int i = 0; i < vs.Length; i++)
            {
                vs[i] = Convert.ToInt32(gameBoard[i+1, turn]);
            }
            return vs.Sum();
        }

        //-- Checks if you have enought int the Upper Section to get the Bonus 
        public static int CheckIfSumIsGoodForBonus(string[,] gameBoard, int numberOfDices, int bonus)
        {
            //-- find out what you minimum need ((number of dice * 3) / 4)
            int vs = (numberOfDices * 3) / 4;
            int needed = 0;
            //-- this gets the sum needed to get the bonus
            for (int i = 1;i < 7; i++)
            {
                needed += vs * i;
            }
            //-- finds the player who has just gotten their Upper Section sum calculated 
            for (int i = 0; i < gameBoard.Length; i++)
            {
                if(gameBoard[i,0] == "Sum")
                {
                    for (int j = 0; j < gameBoard.Length; j++)
                    {
                        if (gameBoard[i, j] != "" && gameBoard[i+1, j] == null)
                        {
                            vs = Convert.ToInt32(gameBoard[i, j]);
                            if (vs < needed)
                            {
                                bonus = 0;
                                break;
                            }
                        }
                    }
                    break;
                }
            }
            return bonus;
        }

        //-- an Calculator for dice of a kind in the Lower-Section
        public static int DiceOfKindsLowerSectionCalculator(int[] playersDices, int similar, int pairs, bool house)
        {
            int[] sum = new int[pairs];
            playersDices = playersDices.OrderBy(i => i).ToArray();
            for (int i = playersDices.Length-1; i >= similar - 1; i--)
            {
                int count = 0;
                for (int j = 0; j < similar; j++)
                {
                    //-- if the playersDices[i-j] is out of scope, than this breaks the loop
                    if (i - j < 0)
                    {
                        break;
                    }
                    else if (playersDices[i-j] != playersDices[i])
                    {
                        break;
                    }
                    else
                    {
                        count++;
                    }
                }
                //-- checks if the count match and that the dice ISN'T already there
                if (count == similar && !Array.Exists(sum, x => x == playersDices[i]))
                {
                    sum[pairs-1] = playersDices[i];
                    pairs--;
                    if (house)
                    {
                        similar -= 1;
                    }
                }
                //-- if the roll has a legal result, it will return the higest value here
                if (pairs == 0)
                {
                    if (house)
                    {
                        //-- I'm using pairs here because it is already zero
                        foreach (int item in sum)
                        {
                            pairs += item * ++similar; 
                        }
                        return pairs;
                    }
                    else
                    {
                        return sum.Sum() * similar;
                    }
                }
                i -= count-1;
            }
            return 0;
        }

        //-- Rolls one Dice only
        public static int OneDice()
        {
            Random random = new Random();
            //-- Is needed because the computer is skipping the Random.Next and sending back the last result it got
            Task.Delay(1).Wait();
            return random.Next(1,7);
        }

        //-- Rolls all you dice as the start of a new turn
        public static int[] DiceRolledArray(int numberOfdice)
        {
            int[] diceRolledArray = new int[numberOfdice];
            for (int i = 0; i < diceRolledArray.Length; i++)
            {
                diceRolledArray[i] = OneDice();
            }
            return diceRolledArray;
        }

        //-- ReRoller logic. User givet a string of '+' and '-', the string legnths must be the same as the number of dice they have
        //-- '+' == reroll this index 
        //-- '-' == keep this index 
        public static int[] DiceReRoller(int[] pastDices, string reRollList)
        {
            if (reRollList.Count() != pastDices.Count())
            {
                return pastDices;
            }
            for (int i = 0; i < pastDices.Length; i++)
            {
                if (reRollList[i] == '+')
                {
                    pastDices[i] = OneDice();
                }
            }
            return pastDices;
        }

        //-- Makes the gameboard 
        public static string[,] GameBoard(int numberOfPlayers, string[] typeOfGame)
        {
            string[,] board = new string[typeOfGame.Length,numberOfPlayers+1];
            for (int i = 0; i < typeOfGame.Length; i++)
            {
                board[i,0] = typeOfGame[i];
            }
            return board;
        }

        //-- A normal yathzee-board
        public static string[] NormalYahtzee()
        {
            return new string[] 
            {
                "Spiller:",
                "Ene'ere",
                "To'ere",
                "Tre'ere",
                "Fire'ere",
                "Fem'ere",
                "Seks'ere",
                "Sum",
                "Bonus",
                "Et Par",
                "To Par",
                "Tre enes",
                "Fire enes",
                "Den Lille",
                "Den Store",
                "Fuld Hus",
                "Changen",
                "Yathzee",
                "Total"
            };
        }

        //-- Prints out the gameboard as is. DOESN'T RETURN
        public static void GameBoardPrinter(string[,] gameboard)
        {
            for (int i = 0; i < gameboard.GetLength(0); i++)
            {
                for (int j = 0; j < gameboard.GetLength(1); j++)
                {
                    Console.Write(gameboard[i,j]);
                }
                Console.WriteLine();
            }
        }

        //-- Prints out the dice-rolls as they are 
        public static void DiceArrayPrinter(int[] diceArray)
        {
            foreach (var item in diceArray)
            {
                Console.Write(item+", ");
            }
            Console.WriteLine();
        }
    }
}
