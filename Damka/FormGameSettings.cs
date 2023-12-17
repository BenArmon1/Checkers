using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex02;
using Damka;

namespace GameSettings
{
    public partial class FormGameSettings : Form
    {
        Player m_PlayerOne = null;
        Player m_PlayerTwo = null;
        int m_CheckerSize = 0;
        public FormDamka m_FormDamka;
        bool m_CheckBox = false; // false for computer, true for player2

        public Player PlayerOne
        {
            get { return m_PlayerOne; }
        }

        public Player PlayerTwo
        {
            get { return m_PlayerTwo; }
        }

        public int CheckerSize
        {
            get { return m_CheckerSize; }
        }

        public bool CheckBox
        {
            get { return m_CheckBox; }
        }

        public FormGameSettings()
        {
            InitializeComponent();
        }

        private void checkBoxPlayerTwo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPlayerTwo.Checked == true)
            {
                textBoxPlayerTwoName.Enabled = true;
                textBoxPlayerTwoName.Text = "";
            }
            else
            {
                textBoxPlayerTwoName.Enabled = false;
                textBoxPlayerTwoName.Text = "[Computer]";
            }
        }

        private void RadioButtonSize_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonSizeSix.Checked == true)
            {
                RadioButtonSizeEight.Checked = false;
                RadioButtonSizeTen.Checked = false;
            }
            else if (RadioButtonSizeEight.Checked == true)
            {
                RadioButtonSizeSix.Checked = false;
                RadioButtonSizeTen.Checked = false;
            }
            else
            {
                RadioButtonSizeSix.Checked = false;
                RadioButtonSizeEight.Checked = false;
            }
        }

        private void ButtonDone_Click(object sender, EventArgs e)
        {
            if ((!RadioButtonSizeSix.Checked && !RadioButtonSizeEight.Checked && !RadioButtonSizeTen.Checked)
                || textBoxPlayerOneName.Text.Length == 0 || (checkBoxPlayerTwo.Checked && textBoxPlayerTwoName.Text.Length == 0))
            {
                MessageBox.Show("Plesae notice that you fill all requirements");
            }
            else if (checkBoxPlayerTwo.Checked)
            {
                m_CheckBox = true;
                ButtonDone.DialogResult = DialogResult.OK;
                m_CheckerSize = findCheckerSize();
                m_PlayerOne = new Player(textBoxPlayerOneName.Text, CheckerSize, "X");
                m_PlayerTwo = new Player(textBoxPlayerTwoName.Text, CheckerSize, "O");
            }
            else
            {
                m_CheckBox = false;
                ButtonDone.DialogResult = DialogResult.OK;
                m_CheckerSize = findCheckerSize();
                m_PlayerOne = new Player(textBoxPlayerOneName.Text, CheckerSize, "X");
                m_PlayerTwo = new Player("Computer", CheckerSize, "O");
            }
        }

        private int findCheckerSize()
        {
            int size = 0;
            foreach (RadioButton buttonSize in this.Controls.OfType<RadioButton>())
            {
                if (buttonSize.Checked)
                {
                    size = int.Parse(buttonSize.Text.Split('x')[0]);
                }
            }

            return size;
        }

        private void FormGameSettings_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel)
            {
                Application.Exit();
            }
            
        }
    }
}
