using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    public class Player
    {
        private readonly string m_PlayerName;
        internal List<CheckersSoldiers> m_CheckersSoldiers;
        private readonly int m_CheckerSize;
        public readonly string m_LabelSoldier;
        public int m_PlayerScore;

        public Player(string i_PlayerName, int i_CheckerSize, string i_SoldierLabel)
        {
            m_PlayerName = i_PlayerName;
            m_LabelSoldier = i_SoldierLabel;
            m_CheckerSize = i_CheckerSize;
            m_CheckersSoldiers = InitialChekcerSoldiers(i_CheckerSize, i_SoldierLabel);
            m_PlayerScore = 0;
        }

        public void ChangeValueOfRowAndCol(ref CheckersSoldiers i, int row, int col)
        {
            i.RowInCheckers = row;
            i.ColInCheckers = col;
        }

        public List<CheckersSoldiers> InitialChekcerSoldiers(int i_CheckerSize, string label)
        {
            List<CheckersSoldiers> soldiers = new List<CheckersSoldiers>();
            int soldierInARow = i_CheckerSize / 2;
            if (label == "X")
            {
                for (int j = i_CheckerSize - 1; j > soldierInARow; j--)
                {
                    for (int k = 0; k < i_CheckerSize; k++)
                    {
                        if ((j % 2 == 0 && k % 2 == 1) || (j % 2 == 1 && k % 2 == 0))
                        {
                            soldiers.Add(new CheckersSoldiers(j, k, "X"));
                        }
                    }

                }
            }
            else if (label == "O")
            {
                for (int j = 0; j < soldierInARow - 1; j++)
                {
                    for (int k = 0; k < i_CheckerSize; k++)
                    {
                        if ((j % 2 == 0 && k % 2 == 1) || (j % 2 == 1 && k % 2 == 0))
                        {
                            soldiers.Add(new CheckersSoldiers(j, k, "O"));
                        }
                    }

                }
            }
            return soldiers;
        }

        public string PlayerName
        {
            get { return m_PlayerName; }
        }

        public string LabelSoldier
        {
            get { return m_LabelSoldier; }
        }

        public int PlayerScore
        {
            get { return m_PlayerScore; }
            set { m_PlayerScore = value + PlayerScore; }
        }

        public List<CheckersSoldiers> CheckersSoldiers
        {
            get { return m_CheckersSoldiers; }
            set { m_CheckersSoldiers = value; }
        }

        public int CheckerSize
        {
            get { return m_CheckerSize; }
        }

        public void CheckIfManChangeToKing()
        {
            foreach (CheckersSoldiers soldier in CheckersSoldiers)
            {
                if (soldier.RowInCheckers == 0 && soldier.SoldierLabel == "X")
                {
                    soldier.ManToKing();
                }
                else if (soldier.RowInCheckers == CheckerSize - 1 && soldier.SoldierLabel == "O")
                {
                    soldier.ManToKing();
                }
            }
        }

        public static int ComputeScore(Player i_PlayerOne, Player i_PlayerTwo)
        {
            int scorePlayerOne = 0;
            int scorePlayerTwo = 0;
            foreach (CheckersSoldiers soldier in i_PlayerOne.CheckersSoldiers)
            {
                if (soldier.SoldierLabel == "X")
                {
                    scorePlayerOne++;
                }
                else
                {
                    scorePlayerOne = scorePlayerOne + 4;
                }
            }

            foreach (CheckersSoldiers soldier in i_PlayerTwo.CheckersSoldiers)
            {
                if (soldier.SoldierLabel == "O")
                {
                    scorePlayerTwo++;
                }
                else
                {
                    scorePlayerTwo = scorePlayerTwo + 4;
                }
            }

            return Math.Abs(scorePlayerOne - scorePlayerTwo);
        }
    }
}
