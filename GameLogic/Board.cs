using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    public class Board
    {
        private string[,] m_CheckersBoard;
        public Player m_PlayerOne;
        public Player m_PlayerTwo;

        public Board(string[,] i_CheckersBoard, Player i_PlayerOne, Player i_PlayerTwo)
        {
            this.m_CheckersBoard = i_CheckersBoard;
            this.m_PlayerOne = i_PlayerOne;
            this.m_PlayerTwo = i_PlayerTwo;
        }

        public void PrintBoard()
        {
            m_PlayerOne.CheckIfManChangeToKing();
            m_PlayerTwo.CheckIfManChangeToKing();
            m_CheckersBoard = new string[m_PlayerOne.CheckerSize, m_PlayerOne.CheckerSize];
            foreach (CheckersSoldiers soldier in m_PlayerOne.m_CheckersSoldiers)
            {
                m_CheckersBoard[soldier.RowInCheckers, soldier.ColInCheckers] = soldier.SoldierLabel;
            }

            foreach (CheckersSoldiers soldier in m_PlayerTwo.m_CheckersSoldiers)
            {
                m_CheckersBoard[soldier.RowInCheckers, soldier.ColInCheckers] = soldier.SoldierLabel;
            }

            StringBuilder rowFormat = new StringBuilder("    ");
            char colIndex = 'A';
            for (int i = 0; i < m_CheckersBoard.GetLength(0); i++)
            {
                rowFormat.Append(colIndex + "   ");
                colIndex++;
            }

            Console.WriteLine(rowFormat);
            StringBuilder rowSpeartor = new StringBuilder("  ");
            for (int i = 0; i < m_CheckersBoard.GetLength(0); i++)
            {
                rowSpeartor.Append("====");
            }

            rowSpeartor.Append("=");
            Console.WriteLine(rowSpeartor);
            char rowIndex = 'a';
            for (int i = 0; i < m_CheckersBoard.GetLength(0); i++)
            {
                Console.Write(" " + rowIndex + "|");
                for (int j = 0; j < m_CheckersBoard.GetLength(0); j++)
                {
                    if (m_CheckersBoard[i, j] == null)
                    {
                        Console.Write("   |");
                    }
                    else
                    {
                        Console.Write(" " + m_CheckersBoard[i, j] + " |");
                    }
                }

                Console.WriteLine();
                Console.WriteLine(rowSpeartor);
                rowIndex++;
            }
        }

        public static int[] CellByStringToNumber(string i_NextMoveThatTheUserWantToPlay)
        {
            int[] cellsValue = new int[i_NextMoveThatTheUserWantToPlay.Length - 1];
            cellsValue[0] = (int)i_NextMoveThatTheUserWantToPlay[0] - 65; // Col current cell
            cellsValue[1] = (int)i_NextMoveThatTheUserWantToPlay[1] - 97; // Row current cell
            cellsValue[2] = (int)i_NextMoveThatTheUserWantToPlay[3] - 65; // Col next cell
            cellsValue[3] = (int)i_NextMoveThatTheUserWantToPlay[4] - 97; // Row next cell 

            return cellsValue;
        }

        public void CheckersMovement(string i_NextMove, bool i_PlayerDirection)
        {
            int[] currentMoveAndNextMove = CellByStringToNumber(i_NextMove);
            if (i_PlayerDirection)
            {
                CheckersSoldiers soldierThatWillMove = null;
                foreach (CheckersSoldiers soldierOfPlayerOne in m_PlayerOne.m_CheckersSoldiers)
                {
                    if (soldierOfPlayerOne.RowInCheckers == currentMoveAndNextMove[1] && soldierOfPlayerOne.ColInCheckers == currentMoveAndNextMove[0])
                    {
                        soldierThatWillMove = soldierOfPlayerOne;
                    }
                }

                int indexOfCheckersList = 0;
                int count = 0;

                if (NextMoveIsEatForMan(currentMoveAndNextMove, i_PlayerDirection) || NextMoveIsEatForKing(currentMoveAndNextMove, i_PlayerDirection))
                {
                    foreach (CheckersSoldiers soldierOfPlayerTwo in m_PlayerTwo.m_CheckersSoldiers)
                    {
                        if (soldierOfPlayerTwo.RowInCheckers == (currentMoveAndNextMove[1] + currentMoveAndNextMove[3]) / 2 && soldierOfPlayerTwo.ColInCheckers == (currentMoveAndNextMove[0] + currentMoveAndNextMove[2]) / 2)
                        {
                            indexOfCheckersList = count;
                        }

                        count++;
                    }

                    m_PlayerTwo.CheckersSoldiers.RemoveAt(indexOfCheckersList);
                }

                soldierThatWillMove.RowInCheckers = currentMoveAndNextMove[3];
                soldierThatWillMove.ColInCheckers = currentMoveAndNextMove[2];
            }
            else
            {
                CheckersSoldiers soldierThatWillMove = null;
                foreach (CheckersSoldiers soldierOfPlayerTwo in m_PlayerTwo.m_CheckersSoldiers)
                {
                    if (soldierOfPlayerTwo.RowInCheckers == currentMoveAndNextMove[1] && soldierOfPlayerTwo.ColInCheckers == currentMoveAndNextMove[0])
                    {
                        soldierThatWillMove = soldierOfPlayerTwo;
                    }
                }

                int indexOfCheckersList = 0;
                int count = 0;

                if (NextMoveIsEatForMan(currentMoveAndNextMove, i_PlayerDirection) || NextMoveIsEatForKing(currentMoveAndNextMove, i_PlayerDirection))
                {
                    foreach (CheckersSoldiers soldierOfPlayerOne in m_PlayerOne.m_CheckersSoldiers)
                    {
                        if (soldierOfPlayerOne.RowInCheckers == (currentMoveAndNextMove[1] + currentMoveAndNextMove[3]) / 2 && soldierOfPlayerOne.ColInCheckers == (currentMoveAndNextMove[0] + currentMoveAndNextMove[2]) / 2)
                        {
                            indexOfCheckersList = count;
                        }

                        count++;
                    }

                    m_PlayerOne.CheckersSoldiers.RemoveAt(indexOfCheckersList);
                }

                soldierThatWillMove.RowInCheckers = currentMoveAndNextMove[3];
                soldierThatWillMove.ColInCheckers = currentMoveAndNextMove[2];
            }
        }

        public bool IsSoldierExist(int i_RowInChecker, int i_ColInChecker, bool i_PlayerId, out string o_SoldierLabel)
        {
            bool IsSoldierExist = false;
            string label = "";
            if (i_PlayerId)
            {
                foreach (CheckersSoldiers soldierOfPlayer in m_PlayerOne.m_CheckersSoldiers)
                {
                    if (soldierOfPlayer.RowInCheckers == i_RowInChecker && soldierOfPlayer.ColInCheckers == i_ColInChecker)
                    {
                        label = soldierOfPlayer.SoldierLabel;
                        IsSoldierExist = true;
                    }
                }
            }
            else
            {
                foreach (CheckersSoldiers soldierOfPlayer in m_PlayerTwo.m_CheckersSoldiers)
                {
                    if (soldierOfPlayer.RowInCheckers == i_RowInChecker && soldierOfPlayer.ColInCheckers == i_ColInChecker)
                    {
                        label = soldierOfPlayer.SoldierLabel;
                        IsSoldierExist = true;
                    }
                }
            }

            o_SoldierLabel = label;
            return IsSoldierExist;
        }

        public bool CellIsEmpty(int i_RowInChecker, int i_ColInChecker)
        {
            string label = "";

            return !IsSoldierExist(i_RowInChecker, i_ColInChecker, true, out label) && !IsSoldierExist(i_RowInChecker, i_ColInChecker, false, out label);
        }

        // Check that the move is valid and its diagonal move
        public bool ValidMoveForMan(int[] i_CurrentCellAndNextMove, bool i_PlayerId)
        {
            bool validMove = true;

            if (!CellIsEmpty(i_CurrentCellAndNextMove[3], i_CurrentCellAndNextMove[2]))
            {
                validMove = false;
            }
            else if (i_PlayerId)
            {
                if (i_CurrentCellAndNextMove[3] + 1 != i_CurrentCellAndNextMove[1] || Math.Abs(i_CurrentCellAndNextMove[2] - i_CurrentCellAndNextMove[0]) != 1 || !(i_CurrentCellAndNextMove[2] >= 0 && i_CurrentCellAndNextMove[2] <= m_CheckersBoard.Length) || i_CurrentCellAndNextMove[3] < 0)
                {
                    validMove = false;
                }
            }
            else
            {
                if (i_CurrentCellAndNextMove[3] - 1 != i_CurrentCellAndNextMove[1] || Math.Abs(i_CurrentCellAndNextMove[2] - i_CurrentCellAndNextMove[0]) != 1 || !(i_CurrentCellAndNextMove[2] >= 0 && i_CurrentCellAndNextMove[2] <= m_CheckersBoard.Length) || i_CurrentCellAndNextMove[3] < 0)
                {
                    validMove = false;
                }
            }

            return validMove;
        }

        public bool ValidMoveForKing(int[] i_CurrentCellAndNextMove)
        {
            return ValidMoveForMan(i_CurrentCellAndNextMove, true) || ValidMoveForMan(i_CurrentCellAndNextMove, false);
        }

        public bool NextMoveIsEatForMan(int[] i_CurrentCellAndNextMove, bool i_PlayerId)
        {
            bool nextMoveIsEat = false;
            string soldierLabelIfWeFindHim = null;
            int middleCol = (i_CurrentCellAndNextMove[0] + i_CurrentCellAndNextMove[2]) / 2;

            if (i_PlayerId)
            {
                if (i_CurrentCellAndNextMove[3] - i_CurrentCellAndNextMove[1] == -2 && (Math.Abs(i_CurrentCellAndNextMove[0] - i_CurrentCellAndNextMove[2]) == 2) && i_CurrentCellAndNextMove[3] < m_CheckersBoard.Length && i_CurrentCellAndNextMove[2] < m_CheckersBoard.Length && i_CurrentCellAndNextMove[3] >= 0 && i_CurrentCellAndNextMove[2] >= 0)
                {
                    if (!IsSoldierExist(i_CurrentCellAndNextMove[3], i_CurrentCellAndNextMove[2], false, out soldierLabelIfWeFindHim) && !IsSoldierExist(i_CurrentCellAndNextMove[3], i_CurrentCellAndNextMove[2], true, out soldierLabelIfWeFindHim) && IsSoldierExist(i_CurrentCellAndNextMove[3] + 1, middleCol, false, out soldierLabelIfWeFindHim))
                    {
                        nextMoveIsEat = true;
                    }
                }
            }
            else
            {
                if (i_CurrentCellAndNextMove[3] - i_CurrentCellAndNextMove[1] == 2 && (Math.Abs(i_CurrentCellAndNextMove[0] - i_CurrentCellAndNextMove[2]) == 2) && i_CurrentCellAndNextMove[3] < m_CheckersBoard.Length && i_CurrentCellAndNextMove[2] < m_CheckersBoard.Length && i_CurrentCellAndNextMove[3] >= 0 && i_CurrentCellAndNextMove[2] >= 0)
                {
                    if (!IsSoldierExist(i_CurrentCellAndNextMove[3], i_CurrentCellAndNextMove[2], false, out soldierLabelIfWeFindHim) && !IsSoldierExist(i_CurrentCellAndNextMove[3], i_CurrentCellAndNextMove[2], true, out soldierLabelIfWeFindHim) && IsSoldierExist(i_CurrentCellAndNextMove[3] - 1, middleCol, true, out soldierLabelIfWeFindHim))
                    {
                        nextMoveIsEat = true;
                    }
                }
            }

            return nextMoveIsEat;
        }

        public bool NextMoveIsEatForKing(int[] i_CurrentCellAndNextMove, bool i_Turn)
        {
            bool nextMoveIsEat = false;
            string soldierLabelIfWeFindHim = null;
            int middleCol = (i_CurrentCellAndNextMove[0] + i_CurrentCellAndNextMove[2]) / 2;


            if (Math.Abs(i_CurrentCellAndNextMove[3] - i_CurrentCellAndNextMove[1]) == 2 && (Math.Abs(i_CurrentCellAndNextMove[0] - i_CurrentCellAndNextMove[2]) == 2) && i_CurrentCellAndNextMove[3] < m_CheckersBoard.Length && i_CurrentCellAndNextMove[2] < m_CheckersBoard.Length && i_CurrentCellAndNextMove[3] >= 0 && i_CurrentCellAndNextMove[2] >= 0)
            {
                if (!IsSoldierExist(i_CurrentCellAndNextMove[3], i_CurrentCellAndNextMove[2], false, out soldierLabelIfWeFindHim) && !IsSoldierExist(i_CurrentCellAndNextMove[3], i_CurrentCellAndNextMove[2], true, out soldierLabelIfWeFindHim) && IsSoldierExist(i_CurrentCellAndNextMove[3] + 1, middleCol, !i_Turn, out soldierLabelIfWeFindHim))
                {
                    nextMoveIsEat = true;
                }
                else if (!IsSoldierExist(i_CurrentCellAndNextMove[3], i_CurrentCellAndNextMove[2], false, out soldierLabelIfWeFindHim) && !IsSoldierExist(i_CurrentCellAndNextMove[3], i_CurrentCellAndNextMove[2], true, out soldierLabelIfWeFindHim) && IsSoldierExist(i_CurrentCellAndNextMove[3] - 1, middleCol, !i_Turn, out soldierLabelIfWeFindHim))
                {
                    nextMoveIsEat = true;
                }
            }

            return nextMoveIsEat;
        }

        // If return true there is an EatMove with the man you chosen to move
        public bool ThereIsEatMoveForMan(int[] i_CurrentCellAndNextMove, bool i_PlayerId)
        {
            bool eatMove = false;
            string soldierLabelIfWeFindHim = null;

            if (i_PlayerId)
            {
                if (i_CurrentCellAndNextMove[0] - 2 >= 0 && i_CurrentCellAndNextMove[1] - 2 >= 0 && (IsSoldierExist(i_CurrentCellAndNextMove[1] - 1, i_CurrentCellAndNextMove[0] - 1, false, out soldierLabelIfWeFindHim) && CellIsEmpty(i_CurrentCellAndNextMove[1] - 2, i_CurrentCellAndNextMove[0] - 2)))
                {
                    eatMove = true;
                }

                if (i_CurrentCellAndNextMove[0] + 2 < m_PlayerOne.CheckerSize && i_CurrentCellAndNextMove[1] - 2 >= 0 && (IsSoldierExist(i_CurrentCellAndNextMove[1] - 1, i_CurrentCellAndNextMove[0] + 1, false, out soldierLabelIfWeFindHim) && CellIsEmpty(i_CurrentCellAndNextMove[1] - 2, i_CurrentCellAndNextMove[0] + 2)))
                {
                    eatMove = true;
                }
            }
            else
            {
                if (i_CurrentCellAndNextMove[0] + 2 < m_PlayerTwo.CheckerSize && i_CurrentCellAndNextMove[1] + 2 < m_PlayerTwo.CheckerSize && (IsSoldierExist(i_CurrentCellAndNextMove[1] + 1, i_CurrentCellAndNextMove[0] + 1, true, out soldierLabelIfWeFindHim) && CellIsEmpty(i_CurrentCellAndNextMove[1] + 2, i_CurrentCellAndNextMove[0] + 2)))
                {
                    eatMove = true;
                }

                if (i_CurrentCellAndNextMove[0] - 2 >= 0 && i_CurrentCellAndNextMove[1] + 2 < m_PlayerTwo.CheckerSize && (IsSoldierExist(i_CurrentCellAndNextMove[1] + 1, i_CurrentCellAndNextMove[0] - 1, true, out soldierLabelIfWeFindHim) && CellIsEmpty(i_CurrentCellAndNextMove[1] + 2, i_CurrentCellAndNextMove[0] - 2)))
                {
                    eatMove = true;
                }
            }

            return eatMove;
        }

        // If return true there is an EatMove with the king you chosen to move
        public bool ThereIsEatMoveForKing(int[] i_CurrentCellAndNextMove, bool i_Turn)
        {
            bool eatMove = false;
            string soldierLabelIfWeFindHim = null;

            if (i_CurrentCellAndNextMove[0] - 2 >= 0 && i_CurrentCellAndNextMove[1] - 2 >= 0 && (IsSoldierExist(i_CurrentCellAndNextMove[1] - 1, i_CurrentCellAndNextMove[0] - 1, !i_Turn, out soldierLabelIfWeFindHim) && CellIsEmpty(i_CurrentCellAndNextMove[1] - 2, i_CurrentCellAndNextMove[0] - 2)))
            {
                eatMove = true;
            }
            else if (i_CurrentCellAndNextMove[0] + 2 < m_PlayerOne.CheckerSize && i_CurrentCellAndNextMove[1] - 2 >= 0 && (IsSoldierExist(i_CurrentCellAndNextMove[1] - 1, i_CurrentCellAndNextMove[0] + 1, !i_Turn, out soldierLabelIfWeFindHim) && CellIsEmpty(i_CurrentCellAndNextMove[1] - 2, i_CurrentCellAndNextMove[0] + 2)))
            {
                eatMove = true;
            }
            else if (i_CurrentCellAndNextMove[0] + 2 < m_PlayerTwo.CheckerSize && i_CurrentCellAndNextMove[1] + 2 < m_PlayerTwo.CheckerSize && (IsSoldierExist(i_CurrentCellAndNextMove[1] + 1, i_CurrentCellAndNextMove[0] + 1, !i_Turn, out soldierLabelIfWeFindHim) && CellIsEmpty(i_CurrentCellAndNextMove[1] + 2, i_CurrentCellAndNextMove[0] + 2)))
            {
                eatMove = true;
            }
            else if (i_CurrentCellAndNextMove[0] - 2 >= 0 && i_CurrentCellAndNextMove[1] + 2 < m_PlayerTwo.CheckerSize && (IsSoldierExist(i_CurrentCellAndNextMove[1] + 1, i_CurrentCellAndNextMove[0] - 1, !i_Turn, out soldierLabelIfWeFindHim) && CellIsEmpty(i_CurrentCellAndNextMove[1] + 2, i_CurrentCellAndNextMove[0] - 2)))
            {
                eatMove = true;
            }

            return eatMove;
        }

        public bool ThereISEatMoveWithOtherMan(bool i_PlayerId)
        {
            bool thereIsEatMoveWithOtherMan = false;
            string soldierLabelIfWeFindHim = null;
            if (i_PlayerId)
            {
                foreach (CheckersSoldiers soldierOfPlayerOne in m_PlayerOne.m_CheckersSoldiers)
                {
                    int rowToCheck = soldierOfPlayerOne.RowInCheckers;
                    int colToCheck = soldierOfPlayerOne.ColInCheckers;

                    if (IsSoldierExist(rowToCheck - 1, colToCheck + 1, !i_PlayerId, out soldierLabelIfWeFindHim) && CellIsEmpty(rowToCheck - 2, colToCheck + 2) && rowToCheck - 2 >= 0 && colToCheck + 2 < m_PlayerOne.CheckerSize)
                    {
                        thereIsEatMoveWithOtherMan = true;
                    }

                    if (IsSoldierExist(rowToCheck - 1, colToCheck - 1, !i_PlayerId, out soldierLabelIfWeFindHim) && CellIsEmpty(rowToCheck - 2, colToCheck - 2) && rowToCheck - 2 >= 0 && colToCheck - 2 >= 0)
                    {
                        thereIsEatMoveWithOtherMan = true;
                    }
                }
            }
            else
            {
                foreach (CheckersSoldiers soldierOfPlayerTwo in m_PlayerTwo.m_CheckersSoldiers)
                {
                    int rowToCheck = soldierOfPlayerTwo.RowInCheckers;
                    int colToCheck = soldierOfPlayerTwo.ColInCheckers;
                    if (IsSoldierExist(rowToCheck + 1, colToCheck + 1, !i_PlayerId, out soldierLabelIfWeFindHim) && CellIsEmpty(rowToCheck + 2, colToCheck + 2) && rowToCheck + 2 < m_PlayerTwo.CheckerSize && colToCheck + 2 < m_PlayerTwo.CheckerSize)
                    {
                        thereIsEatMoveWithOtherMan = true;
                    }

                    if (IsSoldierExist(rowToCheck + 1, colToCheck - 1, !i_PlayerId, out soldierLabelIfWeFindHim) && CellIsEmpty(rowToCheck + 2, colToCheck - 2) && rowToCheck + 2 < m_PlayerTwo.CheckerSize && colToCheck - 2 >= 0)
                    {
                        thereIsEatMoveWithOtherMan = true;
                    }
                }
            }

            return thereIsEatMoveWithOtherMan;
        }

        public bool ThereISEatMoveWithOtherKing(bool i_PlayerId)
        {
            bool thereIsEatMoveWithOtherKing = false;
            string soldierLabelIfWeFindHim = null;

            if (ThereISEatMoveWithOtherMan(i_PlayerId))
            {
                thereIsEatMoveWithOtherKing = true;
            }
            else if (i_PlayerId)
            {
                foreach (CheckersSoldiers soldierOfPlayerOne in m_PlayerOne.m_CheckersSoldiers)
                {
                    int rowToCheck = soldierOfPlayerOne.RowInCheckers;
                    int colToCheck = soldierOfPlayerOne.ColInCheckers;
                    if (soldierOfPlayerOne.SoldierLabel == "Z")
                    {
                        if (IsSoldierExist(rowToCheck + 1, colToCheck + 1, !i_PlayerId, out soldierLabelIfWeFindHim) && CellIsEmpty(rowToCheck + 2, colToCheck + 2) && rowToCheck + 2 < m_PlayerOne.CheckerSize && colToCheck + 2 < m_PlayerOne.CheckerSize)
                        {
                            thereIsEatMoveWithOtherKing = true;
                        }
                        if (IsSoldierExist(rowToCheck + 1, colToCheck - 1, !i_PlayerId, out soldierLabelIfWeFindHim) && CellIsEmpty(rowToCheck + 2, colToCheck - 2) && rowToCheck + 2 < m_PlayerOne.CheckerSize && colToCheck - 2 >= 0)
                        {
                            thereIsEatMoveWithOtherKing = true;
                        }
                    }
                }
            }
            else if (!i_PlayerId)
            {
                foreach (CheckersSoldiers soldierOfPlayerTwo in m_PlayerTwo.m_CheckersSoldiers)
                {
                    int rowToCheck = soldierOfPlayerTwo.RowInCheckers;
                    int colToCheck = soldierOfPlayerTwo.ColInCheckers;

                    if (soldierOfPlayerTwo.SoldierLabel == "Q")
                    {
                        if (IsSoldierExist(rowToCheck - 1, colToCheck + 1, !i_PlayerId, out soldierLabelIfWeFindHim) && CellIsEmpty(rowToCheck - 2, colToCheck + 2) && rowToCheck - 2 >= 0 && colToCheck + 2 < m_PlayerTwo.CheckerSize)
                        {
                            thereIsEatMoveWithOtherKing = true;
                        }

                        if (IsSoldierExist(rowToCheck - 1, colToCheck - 1, !i_PlayerId, out soldierLabelIfWeFindHim) && CellIsEmpty(rowToCheck - 2, colToCheck - 2) && rowToCheck - 2 >= 0 && colToCheck - 2 >= 0)
                        {
                            thereIsEatMoveWithOtherKing = true;
                        }
                    }
                }
            }

            return thereIsEatMoveWithOtherKing;
        }

        public bool IsThereAvailableMoreMoves(Player i_PlayerThatWeCheckIfHeHasMoreMoves)
        {
            bool thereIsMoreMove = false;

            if (i_PlayerThatWeCheckIfHeHasMoreMoves.CheckersSoldiers.Count == 0)
            {
                thereIsMoreMove = false;
            }

            if (i_PlayerThatWeCheckIfHeHasMoreMoves.LabelSoldier == "X")
            {
                if (ThereISEatMoveWithOtherKing(true))
                {
                    thereIsMoreMove = true;
                }
                foreach (CheckersSoldiers soldier in i_PlayerThatWeCheckIfHeHasMoreMoves.CheckersSoldiers)
                {
                    if (soldier.SoldierLabel == "Z")
                    {
                        if (soldier.ColInCheckers - 1 >= 0 && soldier.RowInCheckers + 1 < i_PlayerThatWeCheckIfHeHasMoreMoves.CheckerSize && CellIsEmpty(soldier.RowInCheckers + 1, soldier.ColInCheckers - 1))
                        {
                            thereIsMoreMove = true;
                        }

                        if (soldier.ColInCheckers + 1 < i_PlayerThatWeCheckIfHeHasMoreMoves.CheckerSize && soldier.RowInCheckers + 1 < i_PlayerThatWeCheckIfHeHasMoreMoves.CheckerSize && CellIsEmpty(soldier.RowInCheckers + 1, soldier.ColInCheckers + 1))
                        {
                            thereIsMoreMove = true;
                        }
                    }

                    if (soldier.ColInCheckers - 1 >= 0 && soldier.RowInCheckers - 1 >= 0 && CellIsEmpty(soldier.RowInCheckers - 1, soldier.ColInCheckers - 1))
                    {
                        thereIsMoreMove = true;
                    }

                    if (soldier.ColInCheckers + 1 < i_PlayerThatWeCheckIfHeHasMoreMoves.CheckerSize && soldier.RowInCheckers - 1 >= 0 && CellIsEmpty(soldier.RowInCheckers - 1, soldier.ColInCheckers + 1))
                    {
                        thereIsMoreMove = true;
                    }
                }
            }
            else if (i_PlayerThatWeCheckIfHeHasMoreMoves.LabelSoldier == "O")
            {
                foreach (CheckersSoldiers soldier in i_PlayerThatWeCheckIfHeHasMoreMoves.CheckersSoldiers)
                {
                    if (soldier.SoldierLabel == "Q")
                    {
                        if (soldier.ColInCheckers - 1 >= 0 && soldier.RowInCheckers - 1 >= 0 && CellIsEmpty(soldier.RowInCheckers - 1, soldier.ColInCheckers - 1))
                        {
                            thereIsMoreMove = true;
                        }

                        if (soldier.ColInCheckers + 1 < i_PlayerThatWeCheckIfHeHasMoreMoves.CheckerSize && soldier.RowInCheckers - 1 >= 0 && CellIsEmpty(soldier.RowInCheckers - 1, soldier.ColInCheckers + 1))
                        {
                            thereIsMoreMove = true;
                        }
                    }

                    if (soldier.ColInCheckers - 1 >= 0 && soldier.RowInCheckers + 1 < i_PlayerThatWeCheckIfHeHasMoreMoves.CheckerSize && CellIsEmpty(soldier.RowInCheckers + 1, soldier.ColInCheckers - 1))
                    {
                        thereIsMoreMove = true;
                    }

                    if (soldier.ColInCheckers + 1 < i_PlayerThatWeCheckIfHeHasMoreMoves.CheckerSize && soldier.RowInCheckers + 1 < i_PlayerThatWeCheckIfHeHasMoreMoves.CheckerSize && CellIsEmpty(soldier.RowInCheckers + 1, soldier.ColInCheckers + 1))
                    {
                        thereIsMoreMove = true;
                    }
                }
            }

            {
            }

            return thereIsMoreMove;
        }

        public string NextMoveIsEat()
        {
            string moveForComputer = "";

            foreach (CheckersSoldiers soldierOfComputer in m_PlayerTwo.m_CheckersSoldiers)
            {
                foreach (CheckersSoldiers soldierOfPlayer in m_PlayerOne.m_CheckersSoldiers)
                {
                    if (soldierOfComputer.SoldierLabel == "Q")
                    {
                        moveForComputer = NextMoveIsEatForKing(soldierOfComputer, soldierOfPlayer);
                        if (moveForComputer != null)
                        {
                            return moveForComputer;
                        }
                    }

                    moveForComputer = NextMoveIsEatForMan(soldierOfComputer, soldierOfPlayer);
                    if (moveForComputer != null)
                    {
                        return moveForComputer;
                    }
                }
            }

            return null;
        }

        // Check randomly if computer's soldier can eat other soldier 
        public string NextMoveIsEatForMan(CheckersSoldiers soldierOfComputer, CheckersSoldiers soldierOfPlayer)
        {
            StringBuilder cellOfSoldierBeforeMoveAndAfterMove = null;

            if ((soldierOfPlayer.RowInCheckers == soldierOfComputer.RowInCheckers + 1) && (soldierOfPlayer.ColInCheckers == soldierOfComputer.ColInCheckers + 1))
            {
                if (CellIsEmpty(soldierOfComputer.RowInCheckers + 2, soldierOfComputer.ColInCheckers + 2))
                {
                    if (soldierOfComputer.RowInCheckers + 2 < m_PlayerTwo.CheckerSize && soldierOfComputer.ColInCheckers + 2 < m_PlayerTwo.CheckerSize)
                    {
                        cellOfSoldierBeforeMoveAndAfterMove = new StringBuilder("" + (char)(soldierOfComputer.ColInCheckers + 65) + (char)(soldierOfComputer.RowInCheckers + 97));
                        cellOfSoldierBeforeMoveAndAfterMove.Append(">" + (char)(soldierOfComputer.ColInCheckers + 65 + 2) + (char)(soldierOfComputer.RowInCheckers + 97 + 2));
                    }
                }
            }

            if ((soldierOfPlayer.RowInCheckers == soldierOfComputer.RowInCheckers + 1) && (soldierOfPlayer.ColInCheckers == soldierOfComputer.ColInCheckers - 1))
            {
                if (CellIsEmpty(soldierOfComputer.RowInCheckers + 2, soldierOfComputer.ColInCheckers - 2))
                {
                    if (soldierOfComputer.RowInCheckers + 2 < m_PlayerTwo.CheckerSize && soldierOfComputer.ColInCheckers - 2 >= 0)
                    {
                        cellOfSoldierBeforeMoveAndAfterMove = new StringBuilder("" + (char)(soldierOfComputer.ColInCheckers + 65) + (char)(soldierOfComputer.RowInCheckers + 97));
                        cellOfSoldierBeforeMoveAndAfterMove.Append(">" + (char)(soldierOfComputer.ColInCheckers + 65 - 2) + (char)(soldierOfComputer.RowInCheckers + 97 + 2));
                    }
                }
            }

            if (cellOfSoldierBeforeMoveAndAfterMove == null)
            {
                return null;
            }
            
            return cellOfSoldierBeforeMoveAndAfterMove.ToString();
        }

        public string CheckIfThereIsAnotherEatMoveWithTheSameSoldier(int i_RowInChecker, int i_ColInChecker)
        {
            StringBuilder cellOfSoldierBeforeMoveAndAfterMove = null;
            String label = "";
            CheckersSoldiers soldierThatWeCheckIfHaveAnotherEatMove = null;

            foreach (CheckersSoldiers soldier in m_PlayerTwo.CheckersSoldiers)
            {
                if (soldier.RowInCheckers == i_RowInChecker && soldier.ColInCheckers == i_ColInChecker)
                {
                    soldierThatWeCheckIfHaveAnotherEatMove = soldier;
                }
            }

            if (soldierThatWeCheckIfHaveAnotherEatMove.SoldierLabel == "Q")
            {
                if (i_RowInChecker - 1 >= 0 && i_ColInChecker - 1 >= 0 && i_RowInChecker - 2 >= 0 && i_ColInChecker - 2 >= 0 && IsSoldierExist(i_RowInChecker - 1, i_ColInChecker - 1, true, out label) && CellIsEmpty(i_RowInChecker - 2, i_ColInChecker - 2))
                {
                    cellOfSoldierBeforeMoveAndAfterMove = new StringBuilder("" + (char)(soldierThatWeCheckIfHaveAnotherEatMove.ColInCheckers + 65) + (char)(soldierThatWeCheckIfHaveAnotherEatMove.RowInCheckers + 97));
                    cellOfSoldierBeforeMoveAndAfterMove.Append(">" + (char)(soldierThatWeCheckIfHaveAnotherEatMove.ColInCheckers + 65 - 2) + (char)(soldierThatWeCheckIfHaveAnotherEatMove.RowInCheckers + 97 - 2));
                }

                if (i_RowInChecker - 1 >= 0 && i_ColInChecker + 1 < m_PlayerTwo.CheckerSize && i_RowInChecker - 2 >= 0 && i_ColInChecker + 2 < m_PlayerTwo.CheckerSize && IsSoldierExist(i_RowInChecker - 1, i_ColInChecker + 1, true, out label) && CellIsEmpty(i_RowInChecker - 2, i_ColInChecker + 2))
                {
                    cellOfSoldierBeforeMoveAndAfterMove = new StringBuilder("" + (char)(soldierThatWeCheckIfHaveAnotherEatMove.ColInCheckers + 65) + (char)(soldierThatWeCheckIfHaveAnotherEatMove.RowInCheckers + 97));
                    cellOfSoldierBeforeMoveAndAfterMove.Append(">" + (char)(soldierThatWeCheckIfHaveAnotherEatMove.ColInCheckers + 65 + 2) + (char)(soldierThatWeCheckIfHaveAnotherEatMove.RowInCheckers + 97 - 2));
                }
            }

            if (i_RowInChecker + 1 < m_PlayerTwo.CheckerSize && i_ColInChecker - 1 >= 0 && i_RowInChecker + 2 < m_PlayerTwo.CheckerSize && i_ColInChecker - 2 >= 0 && IsSoldierExist(i_RowInChecker + 1, i_ColInChecker - 1, true, out label) && CellIsEmpty(i_RowInChecker + 2, i_ColInChecker - 2))
            {
                cellOfSoldierBeforeMoveAndAfterMove = new StringBuilder("" + (char)(soldierThatWeCheckIfHaveAnotherEatMove.ColInCheckers + 65) + (char)(soldierThatWeCheckIfHaveAnotherEatMove.RowInCheckers + 97));
                cellOfSoldierBeforeMoveAndAfterMove.Append(">" + (char)(soldierThatWeCheckIfHaveAnotherEatMove.ColInCheckers + 65 - 2) + (char)(soldierThatWeCheckIfHaveAnotherEatMove.RowInCheckers + 97 + 2));
            }

            if (i_RowInChecker + 1 < m_PlayerTwo.CheckerSize && i_ColInChecker + 1 < m_PlayerTwo.CheckerSize && i_RowInChecker + 2 < m_PlayerTwo.CheckerSize && i_ColInChecker + 2 < m_PlayerTwo.CheckerSize && IsSoldierExist(i_RowInChecker + 1, i_ColInChecker + 1, true, out label) && CellIsEmpty(i_RowInChecker + 2, i_ColInChecker + 2))
            {
                cellOfSoldierBeforeMoveAndAfterMove = new StringBuilder("" + (char)(soldierThatWeCheckIfHaveAnotherEatMove.ColInCheckers + 65) + (char)(soldierThatWeCheckIfHaveAnotherEatMove.RowInCheckers + 97));
                cellOfSoldierBeforeMoveAndAfterMove.Append(">" + (char)(soldierThatWeCheckIfHaveAnotherEatMove.ColInCheckers + 65 + 2) + (char)(soldierThatWeCheckIfHaveAnotherEatMove.RowInCheckers + 97 + 2));
            }

            if (cellOfSoldierBeforeMoveAndAfterMove == null)
            {
                return null;
            }

            return cellOfSoldierBeforeMoveAndAfterMove.ToString();
        }

        public string NextMoveIsEatForKing(CheckersSoldiers i_SoldierOfComputer, CheckersSoldiers i_SoldierOfPlayer)
        {
            StringBuilder cellOfSoldierBeforeMoveAndAfterMove = null;
            string moveForward = NextMoveIsEatForMan(i_SoldierOfComputer, i_SoldierOfPlayer);
            bool wasFound = false;

            if (moveForward != null)
            {
                return moveForward;
            }

            if (i_SoldierOfComputer.SoldierLabel == "Q")
            {
                if ((i_SoldierOfPlayer.RowInCheckers == i_SoldierOfComputer.RowInCheckers - 1) && (i_SoldierOfPlayer.ColInCheckers == i_SoldierOfComputer.ColInCheckers + 1))
                {

                    if (CellIsEmpty(i_SoldierOfComputer.RowInCheckers - 2, i_SoldierOfComputer.ColInCheckers + 2))
                    {
                        if (i_SoldierOfComputer.RowInCheckers - 2 >= 0 && i_SoldierOfComputer.ColInCheckers + 2 < m_CheckersBoard.Length)
                        {
                            cellOfSoldierBeforeMoveAndAfterMove = new StringBuilder("" + (char)(i_SoldierOfComputer.ColInCheckers + 65) + (char)(i_SoldierOfComputer.RowInCheckers + 97));
                            cellOfSoldierBeforeMoveAndAfterMove.Append(">" + (char)(i_SoldierOfComputer.ColInCheckers + 65 + 2) + (char)(i_SoldierOfComputer.RowInCheckers + 97 - 2));
                            wasFound = true;
                        }
                    }
                }

                if ((i_SoldierOfPlayer.RowInCheckers == i_SoldierOfComputer.RowInCheckers - 1) && (i_SoldierOfPlayer.ColInCheckers == i_SoldierOfComputer.ColInCheckers - 1) && !wasFound)
                {
                    if (CellIsEmpty(i_SoldierOfComputer.RowInCheckers - 2, i_SoldierOfComputer.ColInCheckers - 2))
                    {
                        if (i_SoldierOfComputer.RowInCheckers - 2 >= 0 && i_SoldierOfComputer.ColInCheckers - 2 >= 0)
                        {
                            cellOfSoldierBeforeMoveAndAfterMove = new StringBuilder("" + (char)(i_SoldierOfComputer.ColInCheckers + 65) + (char)(i_SoldierOfComputer.RowInCheckers + 97));
                            cellOfSoldierBeforeMoveAndAfterMove.Append(">" + (char)(i_SoldierOfComputer.ColInCheckers + 65 - 2) + (char)(i_SoldierOfComputer.RowInCheckers + 97 - 2));
                        }
                    }
                }
            }

            if (cellOfSoldierBeforeMoveAndAfterMove == null)
            {
                return null;
            }

            return cellOfSoldierBeforeMoveAndAfterMove.ToString(); ;
        }

        // Regular move (randomly) if there is not EatMove
        public string NextComputerMove()
        {
            StringBuilder cellOfSoldierBeforeMoveAndAfterMove = null;
            Random randomNumber = new Random();
            int randomNumberForNextMove = randomNumber.Next(0, m_PlayerTwo.m_CheckersSoldiers.Count);
            bool thereWasAMove = false;

            while (!thereWasAMove)
            {
                int rowInCheckers = m_PlayerTwo.m_CheckersSoldiers[randomNumberForNextMove].RowInCheckers;
                int colInCheckers = m_PlayerTwo.m_CheckersSoldiers[randomNumberForNextMove].ColInCheckers;
                if (m_PlayerTwo.m_CheckersSoldiers[randomNumberForNextMove].SoldierLabel == "Q")
                {
                    if (rowInCheckers - 1 >= 0 && colInCheckers - 1 >= 0 && CellIsEmpty(rowInCheckers - 1, colInCheckers - 1))
                    {
                        cellOfSoldierBeforeMoveAndAfterMove = new StringBuilder("" + (char)(colInCheckers + 65) + (char)(rowInCheckers + 97));
                        cellOfSoldierBeforeMoveAndAfterMove.Append(">" + (char)(m_PlayerTwo.m_CheckersSoldiers[randomNumberForNextMove].ColInCheckers + 65 - 1) + (char)(m_PlayerTwo.m_CheckersSoldiers[randomNumberForNextMove].RowInCheckers + 97 - 1));
                        thereWasAMove = true;
                    }

                    if (rowInCheckers - 1 >= 0 && colInCheckers + 1 < m_PlayerTwo.CheckerSize && CellIsEmpty(rowInCheckers - 1, colInCheckers + 1) && !thereWasAMove)
                    {
                        cellOfSoldierBeforeMoveAndAfterMove = new StringBuilder("" + (char)(colInCheckers + 65) + (char)(rowInCheckers + 97));
                        cellOfSoldierBeforeMoveAndAfterMove.Append(">" + (char)(m_PlayerTwo.m_CheckersSoldiers[randomNumberForNextMove].ColInCheckers + 65 + 1) + (char)(m_PlayerTwo.m_CheckersSoldiers[randomNumberForNextMove].RowInCheckers + 97 - 1));
                        thereWasAMove = true;
                    }
                }

                if (rowInCheckers + 1 < m_PlayerTwo.CheckerSize && colInCheckers - 1 >= 0 && CellIsEmpty(rowInCheckers + 1, colInCheckers - 1) && !thereWasAMove)
                {
                    cellOfSoldierBeforeMoveAndAfterMove = new StringBuilder("" + (char)(colInCheckers + 65) + (char)(rowInCheckers + 97));
                    cellOfSoldierBeforeMoveAndAfterMove.Append(">" + (char)(m_PlayerTwo.m_CheckersSoldiers[randomNumberForNextMove].ColInCheckers + 65 - 1) + (char)(m_PlayerTwo.m_CheckersSoldiers[randomNumberForNextMove].RowInCheckers + 97 + 1));
                    thereWasAMove = true;
                }

                if (rowInCheckers + 1 < m_PlayerTwo.CheckerSize && colInCheckers + 1 < m_PlayerTwo.CheckerSize && CellIsEmpty(rowInCheckers + 1, colInCheckers + 1) && !thereWasAMove)
                {
                    cellOfSoldierBeforeMoveAndAfterMove = new StringBuilder("" + (char)(colInCheckers + 65) + (char)(rowInCheckers + 97));
                    cellOfSoldierBeforeMoveAndAfterMove.Append(">" + (char)(m_PlayerTwo.m_CheckersSoldiers[randomNumberForNextMove].ColInCheckers + 65 + 1) + (char)(m_PlayerTwo.m_CheckersSoldiers[randomNumberForNextMove].RowInCheckers + 97 + 1));
                    thereWasAMove = true;
                }

                randomNumberForNextMove = randomNumber.Next(0, m_PlayerTwo.m_CheckersSoldiers.Count);
            }

            return cellOfSoldierBeforeMoveAndAfterMove.ToString(); ;
        }
    }
}
