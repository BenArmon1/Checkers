using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    public class CheckersSoldiers
    {
        internal int m_RowInCheckers;
        internal int m_ColInCheckers;
        private string m_SoldierLabel;

        public CheckersSoldiers(int i_RowInCheckers, int i_ColInCheckers, string i_SoldierLabel)
        {
            m_RowInCheckers = i_RowInCheckers;
            m_ColInCheckers = i_ColInCheckers;
            m_SoldierLabel = i_SoldierLabel;
        }

        public int RowInCheckers
        {
            get { return m_RowInCheckers; }
            set { m_RowInCheckers = value; }
        }

        public int ColInCheckers
        {
            get { return m_ColInCheckers; }
            set { m_ColInCheckers = value; }
        }

        public string SoldierLabel
        {
            get { return m_SoldierLabel; }
            set { m_SoldierLabel = value; }
        }

        public void ManToKing()
        {
            if (m_SoldierLabel == "X")
            {
                m_SoldierLabel = "Z";
            }
            else
            {
                m_SoldierLabel = "Q";
            }
        }
    }
}
