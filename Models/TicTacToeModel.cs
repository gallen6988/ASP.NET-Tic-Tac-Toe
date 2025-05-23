namespace FinalProjectTicTacToe.Models
{
    public class TicTacToeModel
    {
        // Properties
        public string WhosTurn { get; set; } = "X"; // Stores the who's turn it currently is. Player X always goes first.
        public string WinPlayer { get; set; } = string.Empty; // Stores the current winner of the game. Holds string.Empty if no player has won yet.
        public string[] gameboardRow0 { get; set; } = new string[3]; // Keeps track of the players' marks on each "cell" of the first row of the gameboard.
        public string[] gameboardRow1 { get; set; } = new string[3]; // Does the same as gameboardRow0, but it's for the second row of the gameboard.
        public string[] gameboardRow2 { get; set; } = new string[3]; // Does the same as the first two arrays, but it's for the last row of the gameboard.

        // Methods
        public string Winner() // Determines the winner (if there is one yet) using the various helper methods below.
        {
            // This if statement checks to see if player X has won and returns "X" if true.
            if (this.CheckAllRows("X") || this.CheckAllCols("X") || this.CheckDiagonals("X"))
            {
                return "X";
            }
            // This else-if statement checks to see if player O has won and returns "O" if true.
            else if(this.CheckAllRows("O") || this.CheckAllCols("O") || this.CheckDiagonals("O"))
            {
                return "O";
            }
            // This else-if statement only triggers if neither player X nor player O has won, but all cells are still filled (which indicates a tie).
            else if(this.CheckAllCellsFilled())
            {
                return "tie";
            }
            // This else statement only triggers if the game simply hasn't ended yet.
            else
            {
                return string.Empty;
            }
        }

        public bool CheckAllRows(string player) // Checks if an entered player has achieved a horizontal win using the CheckRowWin helper method below.
        {
            if(this.CheckRowWin(player, gameboardRow0) || this.CheckRowWin(player, gameboardRow1) || this.CheckRowWin(player, gameboardRow2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckRowWin(string player, string[] row) // Checks if an entered player has achieved three of their marks on the same entered row.
        {
            for (int n = 0; n < 3; n++)
            {
                if (row[n] != player)
                {
                    return false;
                }
            }
            return true;
        }
        public bool CheckAllCols(string player) // Checks if an entered player has achieved a vertical victory using the CheckColWin helper method below.
        {
            for(int h = 0; h < 3; h++)
            {
                if(this.CheckColWin(player, h))
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckColWin(string player, int colNum) // Checks if an entered player has achieved three marks in the same entered column.
        {
            bool[] win = { false, false, false };
            if (gameboardRow0[colNum] == player)
            {
                win[0] = true;
            }
            if (gameboardRow1[colNum] == player)
            {
                win[1] = true;
            }
            if (gameboardRow2[colNum] == player)
            {
                win[2] = true;
            }

            foreach(bool c in win)
            {
                if(c == false)
                {
                    return false;
                }
            }
            return true;
        }
        public bool CheckDiagonals(string player) // Checks if an entered player has achieved a diagonal victory using the two helper methods below.
        {
            if(this.CheckTopLeftToLowRight(player) || this.CheckTopRightToLowLeft(player))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckTopLeftToLowRight(string player) // Checks if an entered player has achieved three marks in the top left, middle, and lower right cells.
        {
            bool[] win = { false, false, false };
            if (gameboardRow0[0] == player)
            {
                win[0] = true;
            }
            if (gameboardRow1[1] == player)
            {
                win[1] = true;
            }
            if (gameboardRow2[2] == player)
            {
                win[2] = true;
            }

            foreach(bool v in win)
            {
                if(v == false)
                {
                    return false;
                }
            }
            return true;
        }
        public bool CheckTopRightToLowLeft(string player) // Checks if an entered player has achieved three marks in the top right, middle, and lower left cells.
        {
            bool[] win = { false, false, false };
            if (gameboardRow0[2] == player)
            {
                win[0] = true;
            }
            if (gameboardRow1[1] == player)
            {
                win[1] = true;
            }
            if (gameboardRow2[0] == player)
            {
                win[2] = true;
            }

            foreach(bool b in win)
            {
                if(b == false)
                {
                    return false;
                }
            }
            return true;
        }
        public bool CheckAllCellsFilled() // Checks if all cells have any kind of value in them other than string.Empty. Used to see if there's a tie and no one wining player.
        {
            foreach(string s in gameboardRow0)
            {
                if(s == null || s == string.Empty)
                {
                    return false;
                }
            }
            foreach (string b in gameboardRow1)
            {
                if (b == null || b == string.Empty)
                {
                    return false;
                }
            }
            foreach (string v in gameboardRow2)
            {
                if (v == null || v == string.Empty)
                {
                    return false;
                }
            }
            return true;
        }
    }
}