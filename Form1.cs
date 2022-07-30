using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUIImageArray;
// Uses the GUI Image Array Class
using System.IO;
// Using Input Output System to get access to directories on the system
using MyDialogs;
// Uses MyDialogs class

namespace O_Neillo_Assignment
{
    public partial class Form1 : Form
    {
        #region Global variable instantiations
        GImageArray GUI_oNeilloBoard = null;
        // GUI image array instantiated in Form 1
        // Made global so all methods/functions have access to it

        public int[,] oNeilloBoard = new int[8, 8];
        // 2D Array instantiated to have an 8x8 board
        // Made global so all methods/functions have access to it

        string PathImage = Directory.GetCurrentDirectory() + "\\images\\";
        // Allows access to the directory containing my GUI images for the game to use
        // Made Global so all methods/functions have access to the images in the directory

        int whoIsPlaying = 0;
        // Variable for storing who is playing - Default being black (Which is equal to 0)

        string saveApplicationPath = Directory.GetCurrentDirectory() + "\\gameSaves\\";
        // Variable which stores the directory where save files should be stored
        // Allows the save function access to this directory
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region Function when element is clicked change the image icon
        private void Which_Element_Clicked(object sender, EventArgs e)
        {
            int Col = GUI_oNeilloBoard.Get_Col(sender);
            int Row = GUI_oNeilloBoard.Get_Row(sender);
            // Creates the local variables to hold the Column and Row from the array on the GUI

            int numChangedTokens = 0;

            numChangedTokens = numChangedTokens + NorthCheckFlip(Row, Col);
            numChangedTokens = numChangedTokens + SouthCheckFlip(Row, Col);
            numChangedTokens = numChangedTokens + WestCheckFlip(Row, Col);
            numChangedTokens = numChangedTokens + EastCheckFlip(Row, Col);
            numChangedTokens = numChangedTokens + NorthWestCheckFlip(Row, Col);
            numChangedTokens = numChangedTokens + NorthEastCheckFlip(Row, Col);
            numChangedTokens = numChangedTokens + SouthWestCheckFlip(Row, Col);
            numChangedTokens = numChangedTokens + SouthEastCheckFlip(Row, Col);
            // Runs the functions to check if the tokens can be flipped and then if there are it flips them


            if (numChangedTokens > 0)
            {
                // If valid move (Changeable tokens) then run the code below - Makes sure no illegal moves can be placed
                if (whoIsPlaying == 0)
                {
                    toPlayWhite.Visible = true;
                    toPlayBlck.Visible = false;
                    // When black takes its turn the icon to say whos playing alternates to the next player
                    oNeilloBoard[Row, Col] = 0;
                    whoIsPlaying = 1;
                    // Checks to see if black is playing 
                    // If it is run the code in this statement
                    // The code in this statement will declare that once the black is placed
                    // WhoIsPlaying will be then equal to 1, which will then mean that white is playing
                }
                else
                {
                    // else statement allows white to move now
                    toPlayWhite.Visible = false;
                    toPlayBlck.Visible = true;
                    // When white takes its turn the icon to say whos playing alternates to the next player
                    oNeilloBoard[Row, Col] = 1;
                    whoIsPlaying = 0;
                    // After white has taken its turn then the whoIsPlaying goes back to black for their next turn etc...
                }
            }
            GUI_oNeilloBoard.UpDateImages(oNeilloBoard);
            // When a square is clicked, the image will update to the either black or white depending on the players turn
        }
        #endregion

        #region Function which creates the starting board
        private void gameInit()
        {
            for (int Row = 0; Row <= 7; Row++)
            {
                for (int Column = 0; Column <= 7; Column++)
                {
                    oNeilloBoard[Row, Column] = 10;
                    oNeilloBoard[3, 3] = 1;
                    oNeilloBoard[4, 4] = 1;
                    oNeilloBoard[4, 3] = 0;
                    oNeilloBoard[3, 4] = 0;
                    // For loop, to loop through the array and set the default starting image icons
                    // Loops through and makes every icon green, which is then over written by specifically making
                    // the starting positions the required icons
                }
            }
            toPlayBlck.Visible = true;
            // Sets toPlayBlck icon to true by default upon game starting
            // To notify whos turn it is first
        }
        #endregion

        #region New Game Function
        private void newGameItem_Click(object sender, EventArgs e)
        {
            if (playerOneName.Text == "" || playerTwoName.Text == "")
            {
                MessageBox.Show("A players name is missing, please enter the missing players name before starting this game");
                // If either one of the name boxes are missing, then the error statement above will be outputted
            }
            else
            {
                gameInit();
                // Function ran when form application loaded
                if (GUI_oNeilloBoard == null)
                {
                    GUI_oNeilloBoard = new GImageArray(this, oNeilloBoard, 35, 20, 70, 20, 2, PathImage);
                    // Creates the GUI board on Form1 IF there is no pre-existing GUI board
                }
                else
                {
                    // If there is already a pre-exisint GUI board and New Game is pressed a Dialog option will pop up asking the player if they wish to save the current session of the game
                    DialogResult saveRequestNewGame = MessageBox.Show("Would you like to save your current game before starting a new game?",
                            "Save Current Session", MessageBoxButtons.YesNo);
                    if (saveRequestNewGame == DialogResult.Yes)
                    {
                        saveFunction();
                        // Accesses the save function
                        MessageBox.Show("Save Complete");
                        // If option yes is chosen the current game will save and then the program will continue to reset the game
                    }
                    else if (saveRequestNewGame == DialogResult.No)
                    {
                        // If option no is chosen the game is not saved and the program moves onto the code following code below
                    }
                    GUI_oNeilloBoard.UpDateImages(oNeilloBoard);
                    // If there is already a pre-existing GUI board, update the images back to default
                    GUI_oNeilloBoard.Which_Element_Clicked += new GImageArray.ImageClickedEventHandler(Which_Element_Clicked);
                    // Then, allow the player to Access Which_Element_Clicked function
                    toPlayWhite.Visible = false;
                    // Fixes bug where it states it is also whites turn when new game is clicked while it is whites turn
                }
                GUI_oNeilloBoard.Which_Element_Clicked += new GImageArray.ImageClickedEventHandler(Which_Element_Clicked);
                // Access Which_Element_Clicked function - Second required for the program to work
            }
        }
        #endregion

        #region flipFunction
        private int NorthCheckFlip(int row, int col)
        {
            int turnTokens = 0;
            // Stores the value for how many tokens need to be turned

            int aboveToken = row - 1;
            // Stores how many tokens are above the recently placed token

            bool illegalMove = false;
            // Boolean to determine if the move made is illegal, and if it is it won't be placed

            int[] locationGridRow = new int[8];
            int[] locationGridCol = new int[8];

            locationGridRow[turnTokens] = row;
            locationGridCol[turnTokens] = col;
            // Instantiation of the arrays to hold the location for the row and column

            do
            {
                if (aboveToken == 8 || aboveToken == -1)
                {
                    return 0;
                    // If out of bounds of the array, return 0
                }
                if (oNeilloBoard[aboveToken, col] != whoIsPlaying && oNeilloBoard[aboveToken, col] != 10)
                {
                    turnTokens = turnTokens + 1;
                    locationGridRow[turnTokens] = aboveToken;
                    // Sets the amount of tokens that need to be flipped by the amount of tokens of the opposite colour above the
                    // recently placed token
                    locationGridCol[turnTokens] = col;
                    aboveToken = aboveToken - 1;
                    if (aboveToken < 0)
                    {
                        illegalMove = true;
                        aboveToken = 0;
                        // If there are no tokens of the opposite colour above then it will become an illegal move
                    }
                }
                else
                {
                    illegalMove = true;
                    // If the if statement condition is not met then the move will become and illegal move
                }

            } while (oNeilloBoard[aboveToken, col] != whoIsPlaying && !illegalMove);
            // While loop at the end to check if the statement is true

            if (turnTokens >= 0 && !illegalMove)
            // If there are tokens that can be turned the for loop nested in the if will take place
            {
                for (int tokens = 0; tokens < turnTokens + 1; tokens++)
                {
                    int r = locationGridRow[tokens];
                    int c = locationGridCol[tokens];
                    oNeilloBoard[r, c] = whoIsPlaying;
                    // Loops the amount of tokens that need to be placed
                }
                return turnTokens;
                // Flips tokens on the board
            }
            return 0;
            // Determines success, if not a 0 then failure
        }

        private int SouthCheckFlip(int row, int col)
        {
            int turnTokens = 0;
            // Stores the value for how many tokens need to be turned

            int belowToken = row + 1;
            // Stores how many tokens are below the recently placed token

            bool illegalMove = false;
            // Boolean to determine if the move made is illegal, and if it is it won't be placed

            int[] locationGridRow = new int[8];
            int[] locationGridCol = new int[8];

            locationGridRow[turnTokens] = row;
            locationGridCol[turnTokens] = col;
            // Instantiation of the arrays to hold the location for the row and column

            do
            {
                if (belowToken == 8 || belowToken == -1)
                {
                    return 0;
                    // If out of bounds of the array, return 0
                }
                if (oNeilloBoard[belowToken, col] != whoIsPlaying && oNeilloBoard[belowToken, col] != 10)
                {
                    turnTokens = turnTokens + 1;
                    locationGridRow[turnTokens] = belowToken;
                    // Sets the amount of tokens that need to be flipped by the amount of tokens of the opposite colour above the
                    // recently placed token
                    locationGridCol[turnTokens] = col;
                    belowToken = belowToken + 1;
                    if (belowToken < 0)
                    {
                        illegalMove = true;
                        belowToken = 0;
                        // If there are no tokens of the opposite colour above then it will become an illegal move
                    }
                }
                else
                {
                    illegalMove = true;
                    // If the if statement condition is not met then the move will become and illegal move
                }
            } while (oNeilloBoard[belowToken, col] != whoIsPlaying && !illegalMove);
            // While loop at the end to check if the statement is true

            if (turnTokens >= 0 && !illegalMove)
            // If there are tokens that can be turned the for loop nested in the if will take place
            {
                for (int tokens = 0; tokens < turnTokens + 1; tokens++)
                {
                    int r = locationGridRow[tokens];
                    int c = locationGridCol[tokens];
                    oNeilloBoard[r, c] = whoIsPlaying;
                    // Loops the amount of tokens that need to be placed
                }
                return turnTokens;
                // Flips tokens on the board
            }
            return 0;
            // Determines success, if not a 0 then failure
        }

        private int WestCheckFlip(int row, int col)
        {
            int turnTokens = 0;
            // Stores the value for how many tokens need to be turned

            int leftToken = col - 1;
            // Stores how many tokens to the left that need to be flipped

            bool illegalMove = false;
            // Boolean to determine if the move made is illegal, and if it is it won't be placed

            int[] locationGridRow = new int[8];
            int[] locationGridCol = new int[8];

            locationGridRow[turnTokens] = row;
            locationGridCol[turnTokens] = col;
            // Instantiation of the arrays to hold the location for the row and column

            do
            {
                if (leftToken == 8 || leftToken == -1)
                {
                    return 0;
                    // If out of bounds of the array, return 0
                }
                if (oNeilloBoard[row, leftToken] != whoIsPlaying && oNeilloBoard[row, leftToken] != 10)
                {
                    turnTokens = turnTokens + 1;
                    locationGridRow[turnTokens] = row;
                    locationGridCol[turnTokens] = leftToken;
                    // Sets the amount of tokens that need to be flipped by the amount of tokens of the opposite colour above the
                    // recently placed token
                    leftToken = leftToken - 1;
                    if (leftToken < 0)
                    {
                        illegalMove = true;
                        leftToken = 0;
                        // If there are no tokens of the opposite colour above then it will become an illegal move
                    }
                }
                else
                {
                    illegalMove = true;
                    // If the if statement condition is not met then the move will become and illegal move
                }

            } while (oNeilloBoard[row, leftToken] != whoIsPlaying && !illegalMove);
            // While loop at the end to check if the statement is true

            if (turnTokens >= 0 && !illegalMove)
            {
                for (int tokens = 0; tokens < turnTokens + 1; tokens++)
                {
                    int r = locationGridRow[tokens];
                    int c = locationGridCol[tokens];
                    oNeilloBoard[r, c] = whoIsPlaying;
                    // Loops the amount of tokens that need to be placed
                }
                return turnTokens;
                // Flips tokens on the board
            }
            return 0;
            // Determines success, if not a 0 then failure
        }

        private int EastCheckFlip(int row, int col)
        {
            int turnTokens = 0;
            // Stores the value for how many tokens need to be turned

            int rightToken = col + 1;
            // Stores how many tokens to the right need to be flipped

            bool illegalMove = false;
            // Boolean to determine if the move made is illegal, and if it is it won't be placed

            int[] locationGridRow = new int[8];
            int[] locationGridCol = new int[8];

            locationGridRow[turnTokens] = row;
            locationGridCol[turnTokens] = col;
            // Sets the amount of tokens that need to be flipped by the amount of tokens of the opposite colour above the
            // recently placed token

            do
            {
                if (rightToken == 8 || rightToken == 0)
                {
                    return 0;
                    // If out of bounds of the array, return 0
                }
                if (oNeilloBoard[row, rightToken] != whoIsPlaying && oNeilloBoard[row, rightToken] != 10)
                {
                    turnTokens = turnTokens + 1;
                    locationGridRow[turnTokens] = row;
                    // Sets the amount of tokens that need to be flipped by the amount of tokens of the opposite colour above the
                    // recently placed token
                    locationGridCol[turnTokens] = rightToken;
                    rightToken = rightToken + 1;
                    if (rightToken < 0)
                    {
                        illegalMove = true;
                        rightToken = 0;
                        // If there are no tokens of the opposite colour above then it will become an illegal move
                    }
                }
                else
                {
                    illegalMove = true;
                    // If the if statement condition is not met then the move will become and illegal move
                }
            } while (oNeilloBoard[row, rightToken] != whoIsPlaying && !illegalMove);
            // While loop at the end to check if the statement is true

            if (turnTokens >= 0 && !illegalMove)
            {
                for (int tokens = 0; tokens < turnTokens + 1; tokens++)
                {
                    int r = locationGridRow[tokens];
                    int c = locationGridCol[tokens];
                    oNeilloBoard[r, c] = whoIsPlaying;
                    // Loops the amount of tokens that need to be placed
                }
                return turnTokens;
                // Flips tokens on the board
            }
            return 0;
            // Determines success, if not a 0 then failure
        }

        private int NorthWestCheckFlip(int row, int col)
        {
            int turnTokens = 0;
            // Stores the value for how many tokens need to be turned

            int colNWToken = col - 1;
            int rowNWToken = row - 1;
            // Stores the positions going diagonally of the tokens that need to be flipped (North West)

            bool illegalMove = false;
            // Boolean to determine if the move made is illegal, and if it is it won't be placed

            int[] locationGridRow = new int[8];
            int[] locationGridCol = new int[8];

            locationGridRow[turnTokens] = row;
            locationGridCol[turnTokens] = col;
            // Sets the amount of tokens that need to be flipped by the amount of tokens of the opposite colour above the
            // recently placed token

            do
            {
                if (colNWToken == 8 || rowNWToken == -1 || colNWToken == -1 || rowNWToken == 8)
                {
                    return 0;
                    // If out of bounds of the array, return 0
                }
                if (oNeilloBoard[rowNWToken, colNWToken] != whoIsPlaying && oNeilloBoard[rowNWToken, colNWToken] != 10)
                {
                    turnTokens = turnTokens + 1;
                    locationGridRow[turnTokens] = rowNWToken;
                    locationGridCol[turnTokens] = colNWToken;
                    // Sets the amount of tokens that need to be flipped by the amount of tokens of the opposite colour above the
                    // recently placed token
                    colNWToken = colNWToken - 1;
                    rowNWToken = rowNWToken - 1;
                    if (colNWToken < 0)
                    {
                        illegalMove = true;
                        colNWToken = 0;
                        // If there are no tokens of the opposite colour above then it will become an illegal move
                    }
                    if (rowNWToken < 0)
                    {
                        illegalMove = true;
                        rowNWToken = 0;
                        // If there are no tokens of the opposite colour above then it will become an illegal move
                    }
                }
                else
                {
                    illegalMove = true;
                    // If the if statement condition is not met then the move will become and illegal move
                }
            } while (oNeilloBoard[rowNWToken, colNWToken] != whoIsPlaying && !illegalMove);
            // While loop at the end to check if the statement is true

            if (turnTokens >= 0 && !illegalMove)
            {
                for (int tokens = 0; tokens < turnTokens + 1; tokens++)
                {
                    int r = locationGridRow[tokens];
                    int c = locationGridCol[tokens];
                    oNeilloBoard[r, c] = whoIsPlaying;
                    // Loops the amount of tokens that need to be placed
                }
                return turnTokens;
                // Flips tokens on the board
            }
            return 0;
            // Determines success, if not a 0 then failure
        }

        private int NorthEastCheckFlip(int row, int col)
        {
            int turnTokens = 0;
            // Stores the value for how many tokens need to be turned

            int colNEToken = col - 1;
            int rowNEToken = row + 1;
            // Stores the positions going diagonally of the tokens that need to be flipped (North East)

            bool illegalMove = false;
            // Boolean to determine if the move made is illegal, and if it is it won't be placed

            int[] locationGridRow = new int[8];
            int[] locationGridCol = new int[8];

            locationGridRow[turnTokens] = row;
            locationGridCol[turnTokens] = col;
            // Sets the amount of tokens that need to be flipped by the amount of tokens of the opposite colour above the
            // recently placed token

            do
            {
                if (colNEToken == 8 || rowNEToken == -1 || colNEToken == -1 || rowNEToken == 8)
                {
                    return 0;
                    // If out of bounds of the array, return 0
                }
                if (oNeilloBoard[rowNEToken, colNEToken] != whoIsPlaying && oNeilloBoard[rowNEToken, colNEToken] != 10)
                {
                    turnTokens = turnTokens + 1;
                    locationGridRow[turnTokens] = rowNEToken;
                    locationGridCol[turnTokens] = colNEToken;
                    // Sets the amount of tokens that need to be flipped by the amount of tokens of the opposite colour above the
                    // recently placed token
                    colNEToken = colNEToken - 1;
                    rowNEToken = rowNEToken + 1;
                    if (colNEToken < 0)
                    {
                        illegalMove = true;
                        colNEToken = 0;
                        // If there are no tokens of the opposite colour above then it will become an illegal move
                    }
                    if (rowNEToken < 0)
                    {
                        illegalMove = true;
                        rowNEToken = 0;
                        // If there are no tokens of the opposite colour above then it will become an illegal move
                    }
                }
                else
                {
                    illegalMove = true;
                    // If the if statement condition is not met then the move will become and illegal move
                }
            } while (oNeilloBoard[rowNEToken, colNEToken] != whoIsPlaying && !illegalMove);
            // While loop at the end to check if the statement is true

            if (turnTokens >= 0 && !illegalMove)
            {
                for (int tokens = 0; tokens < turnTokens + 1; tokens++)
                {
                    int r = locationGridRow[tokens];
                    int c = locationGridCol[tokens];
                    oNeilloBoard[r, c] = whoIsPlaying;
                    // Loops the amount of tokens that need to be placed
                }
                return turnTokens;
                // Flips tokens on the board
            }
            return 0;
            // Determines success, if not a 0 then failure
        }

        private int SouthWestCheckFlip(int row, int col)
        {
            int turnTokens = 0;
            // Stores the value for how many tokens need to be turned

            int colSWToken = col + 1;
            int rowSWToken = row + 1;
            // Stores the positions going diagonally of the tokens that need to be flipped (South West)

            bool illegalMove = false;
            // Boolean to determine if the move made is illegal, and if it is it won't be placed

            int[] locationGridRow = new int[8];
            int[] locationGridCol = new int[8];

            locationGridRow[turnTokens] = row;
            locationGridCol[turnTokens] = col;
            // Sets the amount of tokens that need to be flipped by the amount of tokens of the opposite colour above the
            // recently placed token

            do
            {
                if(colSWToken == 8 || rowSWToken == -1 || colSWToken == -1 || rowSWToken == 8)
                {
                    return 0;
                    // If out of bounds of the array, return 0
                }
                if (oNeilloBoard[rowSWToken, colSWToken] != whoIsPlaying && oNeilloBoard[rowSWToken, colSWToken] != 10)
                {
                    turnTokens = turnTokens + 1;
                    locationGridRow[turnTokens] = rowSWToken;
                    locationGridCol[turnTokens] = colSWToken;
                    // Sets the amount of tokens that need to be flipped by the amount of tokens of the opposite colour above the
                    // recently placed token
                    colSWToken = colSWToken + 1;
                    rowSWToken = rowSWToken + 1;
                    if (colSWToken < 0)
                    {
                        illegalMove = true;
                        colSWToken = 0;
                        // If there are no tokens of the opposite colour above then it will become an illegal move
                    }
                    if (rowSWToken < 0)
                    {
                        illegalMove = true;
                        rowSWToken = 0;
                        // If there are no tokens of the opposite colour above then it will become an illegal move
                    }
                }
                else
                {
                    illegalMove = true;
                    // If the if statement condition is not met then the move will become and illegal move
                }
            } while (oNeilloBoard[rowSWToken, colSWToken] != whoIsPlaying && !illegalMove);
            // While loop at the end to check if the statement is true

            if (turnTokens >= 0 && !illegalMove)
            {
                for (int tokens = 0; tokens < turnTokens + 1; tokens++)
                {
                    int r = locationGridRow[tokens];
                    int c = locationGridCol[tokens];
                    oNeilloBoard[r, c] = whoIsPlaying;
                    // Loops the amount of tokens that need to be placed
                }
                return turnTokens;
                // Flips tokens on the board
            }
            return 0;
            // Determines success, if not a 0 then failure
        }

        private int SouthEastCheckFlip(int row, int col)
        {
            int turnTokens = 0;
            // Stores the value for how many tokens need to be turned

            int colSEToken = col + 1;
            int rowSEToken = row - 1;
            // Stores the positions going diagonally of the tokens that need to be flipped (South East)

            bool illegalMove = false;
            // Boolean to determine if the move made is illegal, and if it is it won't be placed

            int[] locationGridRow = new int[8];
            int[] locationGridCol = new int[8];

            locationGridRow[turnTokens] = row;
            locationGridCol[turnTokens] = col;
            // Sets the amount of tokens that need to be flipped by the amount of tokens of the opposite colour above the
            // recently placed token

            do
            {
                if(colSEToken == 8 || rowSEToken == -1 || colSEToken == -1 || rowSEToken == 8)
                {
                    return 0;
                    // If out of bounds of the array, return 0
                }
                if (oNeilloBoard[rowSEToken, colSEToken] != whoIsPlaying && oNeilloBoard[rowSEToken, colSEToken] != 10)
                {
                    turnTokens = turnTokens + 1;
                    locationGridRow[turnTokens] = rowSEToken;
                    locationGridCol[turnTokens] = colSEToken;
                    // Sets the amount of tokens that need to be flipped by the amount of tokens of the opposite colour above the
                    // recently placed token
                    colSEToken = colSEToken + 1;
                    rowSEToken = rowSEToken - 1;
                    if (colSEToken < 0)
                    {
                        illegalMove = true;
                        colSEToken = 0;
                        // If there are no tokens of the opposite colour above then it will become an illegal move
                    }
                    if (rowSEToken < 0)
                    {
                        illegalMove = true;
                        rowSEToken = 0;
                        // If there are no tokens of the opposite colour above then it will become an illegal move
                    }
                }
                else
                {
                    illegalMove = true;
                    // If the if statement condition is not met then the move will become and illegal move
                }
            } while (oNeilloBoard[rowSEToken, colSEToken] != whoIsPlaying && !illegalMove);
            // While loop at the end to check if the statement is true

            if (turnTokens >= 0 && !illegalMove)
            {
                for (int tokens = 0; tokens < turnTokens + 1; tokens++)
                {
                    int r = locationGridRow[tokens];
                    int c = locationGridCol[tokens];
                    oNeilloBoard[r, c] = whoIsPlaying;
                    // Loops the amount of tokens that need to be placed
                }
                return turnTokens;
                // Flips tokens on the board
            }
            return 0;
            // Determines success, if not a 0 then failure
        }


        #endregion

        #region helpButtonOnClick Function
        private void about_helpItem_Click(object sender, EventArgs e)
            {
                Form2 nextForm = new Form2();
                 nextForm.Show();
                // When About is pressed on the Menu Strip at the top of form1
                // form2 is opened which discusses what the application is
            }
        #endregion

        #region saveGame and restoreGame Function
        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFunction();
            // Upon Save game being pressed the saveFunction is used
        }

        private void restoreGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toPlayWhite.Visible = false;
            toPlayBlck.Visible = false;
            // Sets the toPlay(Colour icon) to null

            OpenFileDialog openSaveFile = new OpenFileDialog();
            // Opens the file explorer to select the file that the user wants to read from

            openSaveFile.Filter = "txt files (*.txt)|*.txt";
            // A filter for only being able to see/use .txt files

            if (openSaveFile.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader saveFile = new StreamReader(openSaveFile.FileName))
                // Uses StreamReader to read the file into the required areas of the game 
                {
                    playerOneName.Text = saveFile.ReadLine();
                    playerTwoName.Text = saveFile.ReadLine();
                    // Reads the player names on the first two lines of the text file will be placed onto the name text boxes
                    whoIsPlaying = Convert.ToInt32(saveFile.ReadLine());
                    // Reads the third line and updates whoIsPlaying variable to determine who's turn it was at the time of the save

                    for (int Row = 0; Row <= 7; Row++)
                    {
                        for (int Col = 0; Col <= 7; Col++)
                        {
                            oNeilloBoard[Row, Col] = Convert.ToInt32(saveFile.ReadLine());
                            // For loop to read through the rest of the lines of the text file to update every row and column to the
                            // icons saved into the text file
                        }
                    }

                    if (GUI_oNeilloBoard == null)
                    {
                        GUI_oNeilloBoard = new GImageArray(this, oNeilloBoard, 35, 20, 70, 20, 2, PathImage);
                        // Creates the GUI board on Form1 IF there is no pre-existing GUI board upon restoring the save game
                    }
                    else
                    {
                        GUI_oNeilloBoard.UpDateImages(oNeilloBoard);
                        // Updates the image icons based on the save file
                        GUI_oNeilloBoard.Which_Element_Clicked += new GImageArray.ImageClickedEventHandler(Which_Element_Clicked);
                        // Then, allow the player to Access Which_Element_Clicked function
                    }
                    GUI_oNeilloBoard.Which_Element_Clicked += new GImageArray.ImageClickedEventHandler(Which_Element_Clicked);
                    // Then, allow the player to Access Which_Element_Clicked function
                    // Two statements of these are required for this to work

                    if (whoIsPlaying == 0)
                    {
                        // If statement to determine who's turn it was at the time of game save
                        toPlayBlck.Visible = true;
                        // If the variable whoIsPlaying is updated to from the save file to 0
                        // Then toPlayBlck image will be visible (As it will be blacks turn)
                    }
                    else
                    {
                        toPlayWhite.Visible = true;
                        // If the variable whoIsPlaying is updated to from the save file to 1
                        // Then toPlayWhite image will be visible (As it will be whites turn)
                    }
                }
            }
        }

        private void saveFunction()
        {
            string nameOfSaveFile;
            // Stores the name of the file as a string

            nameOfSaveFile = My_Dialogs.InputBox("What would you like to name the save file?");
            // Allows the user to name the save file by using the My_Dialogs class

            if(!Directory.Exists(saveApplicationPath))
            {
                Directory.CreateDirectory(saveApplicationPath);
            }
            StreamWriter writeSaveFile = File.CreateText(saveApplicationPath + nameOfSaveFile + ".txt");
            // Uses StreamWriter function which can be referenced as writeSaveFile
            // This line creates the text document and saves into the directory of saveApplicationPath and saves as the name the user
            // Has entered as nameOfSaveFile

            writeSaveFile.WriteLine(playerOneName.Text);
            // Saves the first players name into the first line of the text document
            writeSaveFile.WriteLine(playerTwoName.Text);
            // Saves the second players name into the second line of the text document
            writeSaveFile.WriteLine(whoIsPlaying.ToString());
            // Saves the whoIsPlaying variable is a string to tell the game whos turn it is

            for (int Row = 0; Row <= 7; Row++)
            {
                for (int Col = 0; Col <= 7; Col++)
                {
                    writeSaveFile.WriteLine(oNeilloBoard[Row, Col]);
                    // Loops through the array to check what icon is being used for each piece of the board (e.g. Green (10), Black (0), White (1))
                    // This loop will write every colour into a text file (Mentioning either 10, 1, or 0) and will place them in order (Which can then be restored and read)
                }
            }
            writeSaveFile.Close();
            // Once the loop is finished it will finalise the text file and save it into the directory
        }
        #endregion

        #region formClosing Function
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Uses the X button on the top right corner to exit the game
            exitGameFunction();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Uses exit button in the game menu to exit the game
            exitGameFunction();
        }

        private void exitGameFunction()
        {
            // Exit game function to be called
            if (GUI_oNeilloBoard != null)
            {
                // If there is GUI board on the form via the newGame menu strip button being pressed prior to the form closing
                // Then the DialogResult box will ask if you want to save the game 
                DialogResult saveRequestExit = MessageBox.Show("Would you like to save your game before exiting?",
                    "Exit", MessageBoxButtons.YesNo);

                if (saveRequestExit == DialogResult.Yes)
                {
                    saveFunction();
                    // Accesses the save function
                    Application.Exit();
                    // Closes application
                }

                else if (saveRequestExit == DialogResult.No)
                {
                    Application.Exit();
                    // Closes application
                }
            }
            #endregion
        }
    }
    #region References

    // • Open Files in C#. (C.L.). www.youtube.com. Retrieved November 12, 2021, from https://www.youtube.com/watch?v=R2ntvGzQpwU&t=558s

    #endregion
}