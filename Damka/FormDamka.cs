using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameSettings;
using Ex02;

namespace Damka
{
    public partial class FormDamka : Form
    {
        FormGameSettings m_GameSettings = new FormGameSettings();
        Button[,] m_Checker = null;
        bool m_FirstClick = false;
        int m_CheckerSize;
        Board m_ShadowBoard;
        string[] m_FirstClickIndex;
        string[] m_SecondClickIndex;
        bool m_PlayerTurn = true; // true for player one turn
        Player m_PlayerOne = null;
        Player m_PlayerTwo = null;
        int m_PlayerOneScore = 0;
        int m_PlayerTwoScore = 0;


        public FormDamka()
        {
            m_GameSettings.ShowDialog();

            if (m_GameSettings.DialogResult == DialogResult.OK)
            {
                InitializeComponent();
                m_CheckerSize = m_GameSettings.CheckerSize;
                m_PlayerOne = m_GameSettings.PlayerOne;
                m_PlayerTwo = m_GameSettings.PlayerTwo;
                m_ShadowBoard = new Board(new string[m_CheckerSize, m_CheckerSize], m_PlayerOne, m_PlayerTwo);
                this.labelPlayerTurn.Text = m_PlayerOne.PlayerName + "'s turn: X!";
                this.labelPlayerOneName.Text = m_PlayerOne.PlayerName + ":";
                this.labelPlayerTwoName.Text = m_PlayerTwo.PlayerName + ":";
                this.initializeChecker(m_GameSettings.CheckerSize);
            }
        }

        public Button[,] Checker
        {
            get { return m_Checker; }
        }

        private void initializeChecker(int i_CheckerSize)
        {
            m_Checker = new Button[i_CheckerSize, i_CheckerSize];
            this.Width = (i_CheckerSize + 1) * 57;
            this.Height = (i_CheckerSize + 1) * 60;
            this.labelPlayerTurn.Left = (this.ClientSize.Width - labelPlayerTurn.Size.Width) / 2;
            this.labelPlayerOneScore.Left = this.labelPlayerOneName.Left + this.labelPlayerOneName.Text.Length + 45;
            this.labelPlayerTwoName.Left = (this.ClientSize.Width * 2) / 3;
            this.labelPlayerTwoScore.Left = this.labelPlayerTwoName.Left + this.labelPlayerTwoName.Text.Length + 45;

            for (int i = 0; i < i_CheckerSize; i++)
            {
                for (int j = 0; j < i_CheckerSize; j++)
                {
                    m_Checker[i, j] = new Button();
                    m_Checker[i, j].Location = new Point(j * 50 + 45, i * 50 + 45);
                    m_Checker[i, j].Size = new Size(50, 50);
                    m_Checker[i, j].Anchor = AnchorStyles.Left & AnchorStyles.Right & AnchorStyles.Top & AnchorStyles.Bottom;
                    m_Checker[i, j].Click += new EventHandler(button_OnClick);
                    m_Checker[i, j].Tag = string.Format("{0},{1}", i, j);
                    this.Controls.Add(m_Checker[i, j]);
                }
            }

            for (int i = 0; i < (i_CheckerSize / 2) - 1; i++)
            {
                for (int j = 0; j < i_CheckerSize; j++)
                {
                    if ((i % 2 == 0 && j % 2 == 1) || (i % 2 == 1 && j % 2 == 0))
                    {
                        m_Checker[i, j].Text = "O";
                    }
                }
            }

            for (int j = i_CheckerSize - 1; j > (i_CheckerSize / 2); j--)
            {
                for (int k = 0; k < i_CheckerSize; k++)
                {
                    if ((j % 2 == 0 && k % 2 == 1) || (j % 2 == 1 && k % 2 == 0))
                    {
                        m_Checker[j, k].Text = "X";
                    }
                }
            }

            for (int i = 0; i < i_CheckerSize; i++)
            {
                for (int j = 0; j < i_CheckerSize; j++)
                {
                    if (i % 2 == 0 && j % 2 == 0)
                    {
                        m_Checker[i, j].Enabled = false;
                        m_Checker[i, j].BackColor = Color.Gray;
                    }
                    else if (i % 2 == 1 && j % 2 == 1)
                    {
                        m_Checker[i, j].Enabled = false;
                        m_Checker[i, j].BackColor = Color.Gray;
                    }
                }
            }
        }

        private void button_OnClick(object sender, EventArgs e)
        {
            Button buttonThatClick = sender as Button;
            string indexClick = "";
            string move = "";
            bool moveIsValid = true;

            if (buttonThatClick.BackColor == Color.LightBlue)
            {
                buttonThatClick.BackColor = Color.LightGray;
                m_FirstClick = false;
            }
            else if (!m_FirstClick)
            {
                buttonThatClick.BackColor = Color.LightBlue;
                indexClick = buttonThatClick.Tag.ToString();
                m_FirstClickIndex = indexClick.Split(',');
                m_FirstClick = true;
            }
            else
            {
                m_Checker[int.Parse(m_FirstClickIndex[0]), int.Parse(m_FirstClickIndex[1])].BackColor = Color.LightGray;
                indexClick = buttonThatClick.Tag.ToString();
                m_SecondClickIndex = indexClick.Split(',');
                m_FirstClick = false;
                move = moveFromIntToString(m_FirstClickIndex, m_SecondClickIndex);
                moveIsValid = cheackMoveValidtion(move, m_PlayerTurn);

                if (moveIsValid)
                {
                    m_ShadowBoard.CheckersMovement(move, m_PlayerTurn);
                    checkerUpdate();
                    int[] currentCell = { int.Parse(m_FirstClickIndex[1]), int.Parse(m_FirstClickIndex[0]) };
                    int[] nextCell = { int.Parse(m_SecondClickIndex[1]), int.Parse(m_SecondClickIndex[0]) };
                    
                    if (Math.Abs(currentCell[0] - nextCell[0]) == 2)
                    { 
                        if ((Checker[nextCell[1], nextCell[0]].Text == "Z" || Checker[nextCell[1], nextCell[0]].Text == "Q") && !m_ShadowBoard.ThereIsEatMoveForKing(nextCell , m_PlayerTurn))
                        {
                            m_PlayerTurn = !m_PlayerTurn;
                            thereIsMoreMoves(m_PlayerTurn);
                            changePlayerTurnLabel(m_PlayerTurn);

                            if (!m_GameSettings.CheckBox)
                            {
                                computerIsPlaying();
                            }
                        }
                        else if (!m_ShadowBoard.ThereIsEatMoveForMan(nextCell, m_PlayerTurn) && !(Checker[nextCell[1], nextCell[0]].Text == "Z" || Checker[nextCell[1], nextCell[0]].Text == "Q"))
                        {
                            m_PlayerTurn = !m_PlayerTurn;
                            thereIsMoreMoves(m_PlayerTurn);
                            changePlayerTurnLabel(m_PlayerTurn);

                            if (!m_GameSettings.CheckBox)
                            {
                                computerIsPlaying();
                            }
                        }
                    }
                    else
                    {
                        m_PlayerTurn = !m_PlayerTurn;
                        thereIsMoreMoves(m_PlayerTurn);
                        changePlayerTurnLabel(m_PlayerTurn);

                        if (!m_GameSettings.CheckBox)
                        {
                            computerIsPlaying();
                        }
                    }   
                }
            }
        }

        private string moveFromIntToString(string[] i_CurrentButton, string[] i_NextButton)
        {
            int currentCol = int.Parse(i_CurrentButton[1]);
            int currentRow = int.Parse(i_CurrentButton[0]);
            int nextCol = int.Parse(i_NextButton[1]);
            int nextRow = int.Parse(i_NextButton[0]);

            return "" + (char)(currentCol + 65) + (char)(currentRow + 97) + ">" + (char)(nextCol + 65) + (char)(nextRow + 97); 
        }

        private bool cheackMoveValidtion(string i_Move, bool i_Turn)
        {
            string checkIfPlayerQuit = "";
            string soldierLabel = "";
            bool validMove = true;

            if (i_Turn)
            {
                validMove = Damka.Checker.CheckinputValidtionForPlayerOne(i_Move,  ref m_ShadowBoard, i_Turn, m_CheckerSize, out checkIfPlayerQuit, out soldierLabel);
            }
            else
            {
                validMove = Damka.Checker.CheckinputValidtionForPlayerTwo(i_Move, ref m_ShadowBoard, i_Turn, m_CheckerSize, out checkIfPlayerQuit, out soldierLabel);
            }

            return validMove;
        }

        private void checkerUpdate()
        {
            m_PlayerOne.CheckIfManChangeToKing();
            m_PlayerTwo.CheckIfManChangeToKing();
            
            foreach (Button button in m_Checker)
            {
                button.Text = "";
            }

            foreach (CheckersSoldiers soldier in m_PlayerOne.CheckersSoldiers)
            {
                m_Checker[soldier.RowInCheckers, soldier.ColInCheckers].Text = soldier.SoldierLabel;
            }

            foreach (CheckersSoldiers soldier in m_PlayerTwo.CheckersSoldiers)
            {
                m_Checker[soldier.RowInCheckers, soldier.ColInCheckers].Text = soldier.SoldierLabel;
            }
        }

        private void changePlayerTurnLabel(bool i_Turn)
        {
            if (i_Turn)
            {
                this.labelPlayerTurn.Text = m_PlayerOne.PlayerName + "'s turn:  X!";
            }
            else
            {
                this.labelPlayerTurn.Text = m_PlayerTwo.PlayerName + "'s turn:  O!";
            }
        }

        private void thereIsMoreMoves(bool i_Turn)
        {
            bool checkIfThereIsMoreMoves = true;
            DialogResult dialogResult = DialogResult.None;
            
            if (!m_ShadowBoard.IsThereAvailableMoreMoves(m_PlayerOne) && !m_ShadowBoard.IsThereAvailableMoreMoves(m_PlayerTwo))
            {
                dialogResult = MessageBox.Show(String.Format(@"Tie!
Another Round?", m_PlayerTwo.PlayerName), "Damka", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else if (i_Turn)
            {
                checkIfThereIsMoreMoves = m_ShadowBoard.IsThereAvailableMoreMoves(m_PlayerOne);

                if (!checkIfThereIsMoreMoves)
                {
                    m_PlayerTwoScore += Player.ComputeScore(m_PlayerTwo, m_PlayerOne);
                    dialogResult = MessageBox.Show(String.Format(@"{0} Won!
Another Round?", m_PlayerTwo.PlayerName), "Damka",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
            }
            else
            {
                checkIfThereIsMoreMoves = m_ShadowBoard.IsThereAvailableMoreMoves(m_PlayerTwo);

                if (!checkIfThereIsMoreMoves)
                {
                    m_PlayerOneScore += Player.ComputeScore(m_PlayerOne, m_PlayerTwo);
                    dialogResult = MessageBox.Show(String.Format(@"{0} Won!
Another Round?", m_PlayerOne.PlayerName), "Damka", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
            }

           if (dialogResult == DialogResult.Yes)
           {
                this.labelPlayerOneScore.Text = "" + m_PlayerOneScore;
                this.labelPlayerTwoScore.Text = "" + m_PlayerTwoScore;
                m_PlayerOne = new Player(m_PlayerOne.PlayerName, m_CheckerSize, "X");
                m_PlayerTwo = new Player(m_PlayerTwo.PlayerName, m_CheckerSize, "O");
                m_ShadowBoard = new Board(new string[m_CheckerSize, m_CheckerSize], m_PlayerOne, m_PlayerTwo);
                checkerUpdate();
           }
           else if (dialogResult == DialogResult.No)
           {
                this.Close();
           }
        }

        private async void computerIsPlaying()
        {
            string thereIsEatMove = m_ShadowBoard.NextMoveIsEat();
            string nextMove = "";
            string reaularMove = "";
            bool wasEatMove = false;
            await Task.Delay(500);

            while (thereIsEatMove != null)
            {
                wasEatMove = true;
                m_ShadowBoard.CheckersMovement(thereIsEatMove, m_PlayerTurn);
                checkerUpdate();
                int[] cuurentCellAndNextMove = Board.CellByStringToNumber(thereIsEatMove);
                nextMove = thereIsEatMove;
                thereIsEatMove = m_ShadowBoard.CheckIfThereIsAnotherEatMoveWithTheSameSoldier(cuurentCellAndNextMove[3], cuurentCellAndNextMove[2]);

                if (thereIsEatMove == null)
                {
                    m_PlayerTurn = !m_PlayerTurn;
                    thereIsMoreMoves(m_PlayerTurn);
                    changePlayerTurnLabel(m_PlayerTurn);
                }
            }

            if (!wasEatMove)
            {
                reaularMove = m_ShadowBoard.NextComputerMove();
                m_ShadowBoard.CheckersMovement(reaularMove, m_PlayerTurn);
                checkerUpdate();
                m_PlayerTurn = !m_PlayerTurn;
                thereIsMoreMoves(m_PlayerTurn);
                changePlayerTurnLabel(m_PlayerTurn);
            }
        }
    }
}
