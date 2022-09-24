// Assignment: CSE210-01, Tic-Tac-Toe
// Author: Alysa Jarrell

using System;
using System.Collections.Generic;


namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // builds the first board of all numbers
            List<string> board = new List<string>{"1", "2", "3", "4", "5", "6", "7", "8", "9"};
            // initialize variables to be changed
            int turnCount = 1;
            string winner = "no";

            populateBoard(board);

            // runs a while loop of playing the game until there is a winner or no more turns can be made
            while (winner == "no")
            {
            turn(turnCount);
            updateBoard(board, turnCount);
            populateBoard(board);
            winner = checkWin(board, turnCount);
            turnCount= turnCount + 1;

            }
            
        } // end of main

        static void populateBoard(List<string> board )
        {
            Console.WriteLine(" ");
            Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
            Console.WriteLine($"-+-+-");
            Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
            Console.WriteLine($"-+-+-");
            Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
            Console.WriteLine(" ");
        }

        static void turn(int count)
        {
            // Check to see who's turn it
            if (count%2 == 0 )
            {
                Console.Write("It is O's turn: ");
            }
            else
            {
                Console.Write("It is X's turn: ");
            }
        }
        static List<string> updateBoard(List<string> board, int count)
        {
            // takes player's input for letter placement
            int play = int.Parse(Console.ReadLine());
            // adjusts input to correspond with board index
            play = play - 1;

            // determines what letter gets placed
            string turn;
            if (count%2 == 0 )
            {
                turn = "O";
            }
            else 
            {
                turn = "X";
            }

            // check availability of board index

            if (board[play] == "X" || board[play] == "O")
            {
                Console.Write($"Sorry, that spot is already taken, choose again: ");
                play = int.Parse(Console.ReadLine());
                play = play - 1;
            }

            // updates the board and returns it
            board[play] = turn;
            return board;

        }

        static string checkWin(List<string> board, int turnCount)
        {
            // does a series of tests, if there are 3 in a row of one letter we tell who the winner is and returns "yes" for winner
            // if there is not 3 in a row, winner is returned as "no"
            
            string winner = "yes";
            // row 1
            if (board[0] == board[1] && board[0] == board[2])
            {
                Console.WriteLine($"The winner is {board[0]}!");
            }
            // row 2
            else if (board[3] == board[4] && board[3] == board[5])
            {
                Console.WriteLine($"The winner is {board[3]}!");
            }
            // row 3
            else if (board[6] == board[7] && board[6] == board[8])
            {
                Console.WriteLine($"The winner is {board[6]}!");
            }
            // column 1
            else if (board[0] == board[3] && board[0] == board[6])
            {
                Console.WriteLine($"The winner is {board[0]}!");
            }
            // column 2
            else if (board[1] == board[4] && board[1] == board[7])
            {
                Console.WriteLine($"The winner is {board[1]}!");
            }
            // column 3
            else if (board[2] == board[5] && board[2] == board[8])
            {
                Console.WriteLine($"The winner is {board[2]}!");
            }
            // diagonal top left to bottom right
            else if (board[0] == board[4] && board[0] == board[8])
            {
                Console.WriteLine($"The winner is {board[0]}!");
            }
            // diagonal top right to bottom left
            else if (board[2] == board[4] && board[2] == board[6])
            {
                Console.WriteLine($"The winner is {board[2]}!");
            }
            else if (turnCount > 8)
            {
                Console.WriteLine($"Looks like there was a draw, better luck next time.");
            }
            else{
                winner = "no";
            }

            return winner;
        }





    }
}
