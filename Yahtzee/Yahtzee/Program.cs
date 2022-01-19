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
            //-- TK
            int numberOfPlayers = 1;
            int numberOfDiceRolls = 3;
            int numberOfDices = 5;
            //-- TK^^
            string[,] gameBoard = GameBoard(numberOfPlayers);
            while (true)
            {
                Console.Clear();
                GameBoardPrinter(gameBoard);
                string playerCommand = "";
                //-- Loop for the rounds 
                for (int round = 1; round < gameBoard.Length; round++)
                {
                    //-- the loop for a players turn, so we know whoes turn it is
                    for (int turn = 1; turn < numberOfPlayers; turn++)
                    {
                        //-- might change this to be a standalone method instead of a part of AddResultToGameboardFields, so that Sum is sperate and and skips the the two turns of "sum" and "bonus"
                        if (gameBoard[round, 0] == "Sum")
                        {
                            gameBoard = AddUpperSectionTogether(gameBoard, turn);
                            continue;
                        }
                        else if (gameBoard[round, 0] == "bonus")
                        {
                            gameBoard = CheckIfSumIsGoodForBonus(gameBoard, turn);
                            continue;
                        }

                        int[] playersDices = DiceRolledArray(numberOfDices);
                        //-- loop for the number for rolls the player has
                        for (int timesRolled = 0; timesRolled < numberOfDiceRolls; timesRolled++)
                        {
                            Console.Clear();
                            GameBoardPrinter(gameBoard);
                            playersDices = playersDices.OrderBy(i => i).ToArray();
                            DiceArrayPrinter(playersDices);
                            playerCommand = Console.ReadLine();
                            //-- 
                            if (playerCommand == "stop" || timesRolled >= 2)
                            {
                                gameBoard = AddResultToGameboardFields(playersDices, gameBoard, round, turn);
                            }
                            playersDices = DiceReRoller(playersDices, playerCommand);
                        }
                    }
                }
            }
        }

        public static string[,] CheckIfSumIsGoodForBonus(string[,] gameBoard, int turn)
        {
            throw new NotImplementedException();
        }

        public static string[,] AddUpperSectionTogether(string[,] gameBoard, int turn)
        {
            throw new NotImplementedException();
        }

        //-- TK
        public static string[,] AddResultToGameboardFields(int[] playersDices, string[,] gameBoard, int round, int turn)
        {
            switch (gameBoard[round,0])
            {
                case "Ene'er":
                    gameBoard[round,turn] = SingleUpperSectionCalculator(playersDices, 1).ToString();
                    break;
                case "To'er":
                    gameBoard[round, turn] = SingleUpperSectionCalculator(playersDices, 2).ToString();
                    break;
                case "Tre'er":
                    gameBoard[round, turn] = SingleUpperSectionCalculator(playersDices, 3).ToString();
                    break;
                case "Fire'er":
                    gameBoard[round, turn] = SingleUpperSectionCalculator(playersDices, 4).ToString();
                    break;
                case "Fem'er":
                    gameBoard[round, turn] = SingleUpperSectionCalculator(playersDices, 5).ToString();
                    break;
                case "Seks'er":
                    gameBoard[round, turn] = SingleUpperSectionCalculator(playersDices, 6).ToString();
                    break;
                case "Sum":

                    break;
                case "Et Par":
                    gameBoard[round, turn] = DiceOfAKindLowerSectionCalculator(playersDices, 2).ToString();
                    break;
                case "To Par":

                    break;
                case "Tre enes":
                    gameBoard[round, turn] = DiceOfAKindLowerSectionCalculator(playersDices, 3).ToString();
                    break;
                case "Fire enes":
                    gameBoard[round, turn] = DiceOfAKindLowerSectionCalculator(playersDices, 4).ToString();
                    break;
                case "Den Lille":

                    break;
                case "Den Store":

                    break;
                case "Fuld Hus":

                    break;
                case "Changen":
                    gameBoard[round, turn] = playersDices.Sum().ToString();
                    break;
                case "Yathzee":
                    gameBoard[round, turn] = DiceOfAKindLowerSectionCalculator(playersDices, 5).ToString();
                    break;
                default:
                    break;
            }
            return gameBoard;
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
        //-- an Calculator for dice of a kind in the Lower-Section
        public static int DiceOfAKindLowerSectionCalculator(int[] playersDices, int howMany)
        {
            int sum = 0;
            playersDices = playersDices.OrderBy(i => i).ToArray();
            for (int i = playersDices.Length-1; i >= howMany-1; i--)
            {
                int count = 0;
                for (int j = 0; j < howMany; j++)
                {
                    if(playersDices[i-j] != playersDices[i])
                    {
                        break;
                    }
                    else
                    {
                        count++;
                    }
                }
                if (count == howMany)
                {
                    sum = howMany * playersDices[i];
                    break;
                }
            }
            return sum;
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
        public static string[,] GameBoard(int numberOfPlayers)
        {
            //-- TK
            string[] typeOfGame = NormalYahtzee();
            //-- TK^^
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
                "Ene'er",
                "To'er",
                "Tre'er",
                "Fire'er",
                "Fem'er",
                "Seks'er",
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
