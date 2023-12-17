using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02;
using System.Windows.Forms;

namespace Damka
{
    internal class Checker
    {
        public static bool CheckinputValidtionForPlayerOne(string i_NextMoveOfPlayer, ref Board i_CheckerGame, bool i_PlayerTurn, int i_CheckerSize, out string o_CheckIfPlayerQuit, out string o_SoldierLabel)
        {
            bool checkIfThisMoveIsEatMove = true;
            int[] userNextMoveFromStringToInt = null;
            string soldierLabel = "";
            userNextMoveFromStringToInt = Board.CellByStringToNumber(i_NextMoveOfPlayer);
          
            if (!i_CheckerGame.IsSoldierExist(userNextMoveFromStringToInt[1], userNextMoveFromStringToInt[0], i_PlayerTurn, out soldierLabel))
            {
                MessageBox.Show("Invalid move!", "Damka", MessageBoxButtons.OK, MessageBoxIcon.Error);
                o_CheckIfPlayerQuit = null;
                o_SoldierLabel = null;
                return false;
            }

            if (soldierLabel == "X")
            {
                if (!i_CheckerGame.ValidMoveForMan(userNextMoveFromStringToInt, i_PlayerTurn) && !i_CheckerGame.NextMoveIsEatForMan(userNextMoveFromStringToInt, i_PlayerTurn))
                {
                    MessageBox.Show("Invalid move", "Damka", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    o_CheckIfPlayerQuit = null;
                    o_SoldierLabel = null;
                    return false;
                }

                if (!i_CheckerGame.NextMoveIsEatForMan(userNextMoveFromStringToInt, i_PlayerTurn))
                {
                    checkIfThisMoveIsEatMove = false;
                }

                if (!checkIfThisMoveIsEatMove && i_CheckerGame.ThereIsEatMoveForMan(userNextMoveFromStringToInt, i_PlayerTurn))
                {
                    MessageBox.Show("Please pay attention that you have Eat Move with the same man that you chosen", "Damka", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    o_CheckIfPlayerQuit = null;
                    o_SoldierLabel = null;
                    return false;
                }
            }
            else if (soldierLabel == "Z")
            {
                if (!i_CheckerGame.ValidMoveForKing(userNextMoveFromStringToInt) && !i_CheckerGame.NextMoveIsEatForKing(userNextMoveFromStringToInt, i_PlayerTurn))
                {
                    MessageBox.Show("Invalid move", "Damka", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    o_CheckIfPlayerQuit = null;
                    o_SoldierLabel = null;
                    return false;
                }

                if (!i_CheckerGame.NextMoveIsEatForKing(userNextMoveFromStringToInt, i_PlayerTurn))
                {
                    checkIfThisMoveIsEatMove = false;
                }

                if (!checkIfThisMoveIsEatMove && i_CheckerGame.ThereIsEatMoveForKing(userNextMoveFromStringToInt, i_PlayerTurn))
                {
                    MessageBox.Show("Please pay attention that you have Eat Move with the same king that you chosen", "Damka", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    o_CheckIfPlayerQuit = null;
                    o_SoldierLabel = null;
                    return false;
                }
            }

            if (!checkIfThisMoveIsEatMove && i_CheckerGame.ThereISEatMoveWithOtherMan(i_PlayerTurn))
            {
                MessageBox.Show("Please pay attention that there is an Eat Move", "Damka", MessageBoxButtons.OK, MessageBoxIcon.Error);
                o_CheckIfPlayerQuit = null;
                o_SoldierLabel = null;
                return false;
            }

            if (!checkIfThisMoveIsEatMove && i_CheckerGame.ThereISEatMoveWithOtherKing(i_PlayerTurn))
            {
                MessageBox.Show("Please pay attention that there is an Eat Move", "Damka", MessageBoxButtons.OK, MessageBoxIcon.Error);
                o_CheckIfPlayerQuit = null;
                o_SoldierLabel = null;
                return false;
            }

            o_CheckIfPlayerQuit = null;
            o_SoldierLabel = soldierLabel;
            return true;
        }

        public static bool CheckinputValidtionForPlayerTwo(string i_NextMoveOfPlayer, ref Board i_CheckerGame, bool i_PlayerTurn, int i_CheckerSize, out string o_CheckIfPlayerQuit, out string o_SoldierLabel)
        {
            bool checkIfThisMoveIsEatMove = true;
            int[] userNextMoveFromStringToInt = null;
            string soldierLabel = "";
            userNextMoveFromStringToInt = Board.CellByStringToNumber(i_NextMoveOfPlayer);

            if (!i_CheckerGame.IsSoldierExist(userNextMoveFromStringToInt[1], userNextMoveFromStringToInt[0], i_PlayerTurn, out soldierLabel))
            {
                MessageBox.Show("Invalid move", "Damka", MessageBoxButtons.OK, MessageBoxIcon.Error);
                o_CheckIfPlayerQuit = null;
                o_SoldierLabel = null;
                return false;
            }

            if (soldierLabel == "O")
            {
                if (!i_CheckerGame.ValidMoveForMan(userNextMoveFromStringToInt, i_PlayerTurn) && !i_CheckerGame.NextMoveIsEatForMan(userNextMoveFromStringToInt, i_PlayerTurn))
                {
                    MessageBox.Show("Invalid move", "Damka", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    o_CheckIfPlayerQuit = null;
                    o_SoldierLabel = null;
                    return false;
                }

                if (!i_CheckerGame.NextMoveIsEatForMan(userNextMoveFromStringToInt, i_PlayerTurn))
                {
                    checkIfThisMoveIsEatMove = false;
                }

                if (!checkIfThisMoveIsEatMove && i_CheckerGame.ThereIsEatMoveForMan(userNextMoveFromStringToInt, i_PlayerTurn))
                {
                    MessageBox.Show("Please pay attention that you have Eat Move with the same man that you chosen", "Damka", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    o_CheckIfPlayerQuit = null;
                    o_SoldierLabel = null;
                    return false;
                }
            }
            else if (soldierLabel == "Q")
            {
                if (!i_CheckerGame.ValidMoveForKing(userNextMoveFromStringToInt) && !i_CheckerGame.NextMoveIsEatForKing(userNextMoveFromStringToInt, i_PlayerTurn))
                {
                    MessageBox.Show("Invalid move", "Damka", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    o_CheckIfPlayerQuit = null;
                    o_SoldierLabel = null;
                    return false;
                }

                if (!i_CheckerGame.NextMoveIsEatForKing(userNextMoveFromStringToInt, i_PlayerTurn))
                {
                    checkIfThisMoveIsEatMove = false;
                }

                if (!checkIfThisMoveIsEatMove && i_CheckerGame.ThereIsEatMoveForKing(userNextMoveFromStringToInt, i_PlayerTurn))
                {
                    MessageBox.Show("Please pay attention that you have Eat Move with the same king that you chosen", "Damka", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    o_CheckIfPlayerQuit = null;
                    o_SoldierLabel = null;
                    return false;
                }
            }

            if (!checkIfThisMoveIsEatMove && i_CheckerGame.ThereISEatMoveWithOtherMan(i_PlayerTurn))
            {
                MessageBox.Show("Please pay attention that there is an Eat Move", "Damka", MessageBoxButtons.OK, MessageBoxIcon.Error);
                o_CheckIfPlayerQuit = null;
                o_SoldierLabel = null;
                return false;
            }

            if (!checkIfThisMoveIsEatMove && i_CheckerGame.ThereISEatMoveWithOtherKing(i_PlayerTurn))
            {
                MessageBox.Show("Please pay attention that there is an Eat Move", "Damka", MessageBoxButtons.OK, MessageBoxIcon.Error);
                o_CheckIfPlayerQuit = null;
                o_SoldierLabel = null;
                return false;
            }

            o_CheckIfPlayerQuit = null;
            o_SoldierLabel = soldierLabel;

            return true;
        }
    }
}


