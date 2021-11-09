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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Which_Element_Clicked(object sender, EventArgs e)
        {
            int Col = GUI_oNeilloBoard.Get_Col(sender);
            int Row = GUI_oNeilloBoard.Get_Row(sender);
            // Creates the local variables to hold the Column and Row from the array on the GUI

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

            GUI_oNeilloBoard.UpDateImages(oNeilloBoard);
            // When a square is clicked, the image will update to the either black or white depending on the players turn
        }
        
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
                if(GUI_oNeilloBoard == null)
                {
                    GUI_oNeilloBoard = new GImageArray(this, oNeilloBoard, 35, 20, 70, 20, 2, PathImage);
                    // Creates the GUI board on Form1 IF there is no pre-existing GUI board
                }
                else
                {
                    // If there is already a pre-exisint GUI board and New Game is pressed a Dialog option will pop up asking the player if they wish to save the current session of the game
                    DialogResult saveRequestNewGame = MessageBox.Show("Would you like to save your current game before starting a new game?",
                            "Save Current Session", MessageBoxButtons.YesNo);
                    if(saveRequestNewGame == DialogResult.Yes)
                    {
                        // Save function needs creating
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

        private void about_helpItem_Click(object sender, EventArgs e)
        {
            Form2 nextForm = new Form2();
            nextForm.Show();
            // When About is pressed on the Menu Strip at the top of form1
            // form2 is opened which discusses what the application is
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(GUI_oNeilloBoard != null)
            {
                // If there is GUI board on the form via the newGame menu strip button being pressed prior to the form closing
                // Then the DialogResult box will ask if you want to save the game 
                DialogResult saveRequestExit = MessageBox.Show("Would you like to save your game before exiting?",
                            "Exit", MessageBoxButtons.YesNo);
                if (saveRequestExit == DialogResult.Yes)
                {
                    // Save function needs creating
                    MessageBox.Show("Save Complete");
                    // If yes is seclected the game will be saved and the form will close
                }
                else if (saveRequestExit == DialogResult.No)
                {
                    // If the option is no then the form will just close
                }
            }
            else
            {
                Application.Exit();
                // If there is no GUI board (Due to the new game button NOT being pressed prior)
                // Then the form wil just close when prompt
            }
        }

        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nameOfSaveFile;
            // Stores the name of the file as a string

            nameOfSaveFile = My_Dialogs.InputBox("What would you like to name the save file?");
            // Allows the user to name the save file by using the My_Dialogs class

            StreamWriter writeSaveFile = File.CreateText(saveApplicationPath + nameOfSaveFile + ".txt");
            // Uses StreamWriter function which can be referenced as writeSaveFile
            // This line creates the text document and saves into the directory of saveApplicationPath and saves as the name the user
            // Has entered as nameOfSaveFile

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

        private void restoreGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}