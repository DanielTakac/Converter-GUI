using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ConverterApp{

    public partial class Form1 : Form{

        string input = string.Empty;

        bool toggle = true;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private void SwitchPanel(Panel panel){

            HashPanel.Enabled = false;
            BinaryPanel.Enabled = false;
            HexPanel.Enabled = false;
            MorsePanel.Enabled = false;
            SettingsPanel.Enabled = false;
            HomePanel.Enabled = false;
            HashPanel.Visible = false;
            BinaryPanel.Visible = false;
            HexPanel.Visible = false;
            MorsePanel.Visible = false;
            SettingsPanel.Visible = false;
            HomePanel.Visible = false;
            panel.Enabled = true;
            panel.Visible = true;

        }

        private void ChangeTheme(){

            if (DarkModeToggle.Checked){

                panel3.BackColor = Color.FromArgb(46, 51, 73);
                panel1.BackColor = Color.FromArgb(24, 30, 54);
                HashButton.BackColor = Color.FromArgb(24, 30, 54);
                BinaryButton.BackColor = Color.FromArgb(24, 30, 54);
                HexButton.BackColor = Color.FromArgb(24, 30, 54);
                MorseButton.BackColor = Color.FromArgb(24, 30, 54);
                SettingsButton.BackColor = Color.FromArgb(24, 30, 54);
                HomeButton.BackColor = Color.FromArgb(24, 30, 54);
                CategoryLabel.ForeColor = Color.FromArgb(158, 161, 176);
                label1.ForeColor = Color.FromArgb(158, 161, 178);
                Panel9.BackColor = Color.FromArgb(37, 42, 64);
                panel8.BackColor = Color.FromArgb(37, 42, 64);
                label5.BackColor = Color.FromArgb(37, 42, 64);
                panel5.BackColor = Color.FromArgb(37, 42, 64);
                panel6.BackColor = Color.FromArgb(37, 42, 64);
                panel7.BackColor = Color.FromArgb(37, 42, 64);
                HashInputTextBox.BackColor = Color.FromArgb(67, 78, 120);
                HashOutputTextBox.BackColor = Color.FromArgb(67, 78, 120);
                BinaryInputTextBox.BackColor = Color.FromArgb(67, 78, 120);
                BinaryOutputText.BackColor = Color.FromArgb(67, 78, 120);
                HexInputTextBox.BackColor = Color.FromArgb(67, 78, 120);
                HexOutputTextBox.BackColor = Color.FromArgb(67, 78, 120);

            } else if (!DarkModeToggle.Checked){

                panel3.BackColor = Color.DarkGray;
                panel1.BackColor = Color.FromArgb(224, 224, 224);
                HashButton.BackColor = Color.FromArgb(224, 224, 224);
                BinaryButton.BackColor = Color.FromArgb(224, 224, 224);
                HexButton.BackColor = Color.FromArgb(224, 224, 224);
                MorseButton.BackColor = Color.FromArgb(224, 224, 224);
                SettingsButton.BackColor = Color.FromArgb(224, 224, 224);
                HomeButton.BackColor = Color.FromArgb(224, 224, 224);
                CategoryLabel.ForeColor = Color.FromArgb(64, 64, 64);
                label1.ForeColor = Color.FromArgb(64, 64, 64);
                Panel9.BackColor = Color.Silver;
                panel8.BackColor = Color.Silver;
                label5.BackColor = Color.Silver;
                panel5.BackColor = Color.Silver;
                panel6.BackColor = Color.Silver;
                panel7.BackColor = Color.Silver;
                HashInputTextBox.BackColor = Color.DimGray;
                HashOutputTextBox.BackColor = Color.DimGray;
                BinaryInputTextBox.BackColor = Color.DimGray;
                BinaryOutputText.BackColor = Color.DimGray;
                HexInputTextBox.BackColor = Color.DimGray;
                HexOutputTextBox.BackColor = Color.DimGray;

            }

        }

        private void ConvertBinary(){

            if (BinaryInputTextBox.Text == string.Empty || BinaryInputTextBox.Text == " Input...") return;

            if (BinaryToggle1.Checked){

                BinaryOutputText.Text = Functions.StringToBinary(BinaryInputTextBox.Text);

            }else if (BinaryToggle2.Checked && (BinaryInputTextBox.Text.Length % 8) == 0 && (BinaryInputTextBox.Text.Contains("0") || BinaryInputTextBox.Text.Contains("1"))){

                BinaryOutputText.Text = Functions.BinaryToString(BinaryInputTextBox.Text);

            }

        }

        private void ConvertHex(){

            if (HexInputTextBox.Text == string.Empty || HexInputTextBox.Text == " Input...") return;

            if (HexToggle1.Checked ){

                HexOutputTextBox.Text = Functions.StringToHex(HexInputTextBox.Text);

            }else if (HexToggle2.Checked){

                HexOutputTextBox.Text = Functions.HexToString(HexInputTextBox.Text);

            }

        }

        private void ConvertHash(){

            if (HashInputTextBox.Text == String.Empty || HashInputTextBox.Text == " Input...") return;

            if(HashToggle1.Checked){

                HashOutputTextBox.Text = Functions.HashString(HashInputTextBox.Text);

            }else if (HashToggle2.Checked){

                HashOutputTextBox.Text = Functions.UnhashString(HashInputTextBox.Text);

            }

        }

        private void ResetBinary(){

            BinaryInputTextBox.Text = " Input...";

            BinaryOutputText.Text = " Output...";

        }

        private void ResetHex(){

            HexInputTextBox.Text = " Input...";

            HexOutputTextBox.Text = " Output...";

        }

        private void ResetHash(){

            HashInputTextBox.Text = " Input...";

            HashOutputTextBox.Text = " Output...";

        }

        public Form1(){

            InitializeComponent();

            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            NavPanel.Height = HomeButton.Height;
            NavPanel.Top = HomeButton.Top;
            NavPanel.Left = HomeButton.Left;
            HomeButton.BackColor = Color.FromArgb(46, 51, 73);
            CategoryLabel.Text = "Home";
            SwitchPanel(HomePanel);
            DarkModeToggle.Checked = true;

        }

        private void HashButton_Click(object sender, EventArgs e){

            NavPanel.Height = HashButton.Height;
            NavPanel.Top = HashButton.Top;
            NavPanel.Left = HashButton.Left;
            HashButton.BackColor = Color.FromArgb(46, 51, 73);
            CategoryLabel.Text = "Hash";
            SwitchPanel(HashPanel);
            HashToggle1.Checked = true;

            ResetHash();

            if (!DarkModeToggle.Checked) { HashButton.BackColor = Color.Silver; }

        }

        private void BinaryButton_Click(object sender, EventArgs e){

            NavPanel.Height = BinaryButton.Height;
            NavPanel.Top = BinaryButton.Top;
            NavPanel.Left = BinaryButton.Left;
            BinaryButton.BackColor = Color.FromArgb(46, 51, 73);
            CategoryLabel.Text = "Binary";
            SwitchPanel(BinaryPanel);
            BinaryToggle1.Checked = true;

            ResetBinary();

            if (!DarkModeToggle.Checked) { BinaryButton.BackColor = Color.Silver; }

        }

        private void HexButton_Click(object sender, EventArgs e){

            NavPanel.Height = HexButton.Height;
            NavPanel.Top = HexButton.Top;
            NavPanel.Left = HexButton.Left;
            HexButton.BackColor = Color.FromArgb(46, 51, 73);
            CategoryLabel.Text = "Hexadecimal";
            SwitchPanel(HexPanel);
            HexToggle1.Checked = true;

            ResetHex();

            if (!DarkModeToggle.Checked) { HexButton.BackColor = Color.Silver; }

        }

        private void MorseButton_Click(object sender, EventArgs e){

            NavPanel.Height = MorseButton.Height;
            NavPanel.Top = MorseButton.Top;
            NavPanel.Left = MorseButton.Left;
            MorseButton.BackColor = Color.FromArgb(46, 51, 73);
            CategoryLabel.Text = "Morse Code";
            SwitchPanel(MorsePanel);

            if (!DarkModeToggle.Checked) { MorseButton.BackColor = Color.Silver; }

        }

        private void SettingsButton_Click(object sender, EventArgs e){

            NavPanel.Height = SettingsButton.Height;
            NavPanel.Top = SettingsButton.Top;
            NavPanel.Left = SettingsButton.Left;
            SettingsButton.BackColor = Color.FromArgb(46, 51, 73);
            CategoryLabel.Text = "Settings";
            SwitchPanel(SettingsPanel);

            if (!DarkModeToggle.Checked) { SettingsButton.BackColor = Color.Silver; }

        }

        private void HashButton_Leave(object sender, EventArgs e){

            HashButton.BackColor = Color.FromArgb(24, 30, 54);

            if (!DarkModeToggle.Checked) { HashButton.BackColor = Color.FromArgb(224, 224, 224); }

        }

        private void BinaryButton_Leave(object sender, EventArgs e){

            BinaryButton.BackColor = Color.FromArgb(24, 30, 54);

            if (!DarkModeToggle.Checked) { BinaryButton.BackColor = Color.FromArgb(224, 224, 224); }

        }

        private void HexButton_Leave(object sender, EventArgs e){

            HexButton.BackColor = Color.FromArgb(24, 30, 54);

            if (!DarkModeToggle.Checked) { HexButton.BackColor = Color.FromArgb(224, 224, 224); }

        }

        private void MorseButton_Leave(object sender, EventArgs e){

            MorseButton.BackColor = Color.FromArgb(24, 30, 54);

            if (!DarkModeToggle.Checked) { MorseButton.BackColor = Color.FromArgb(224, 224, 224); }

        }

        private void SettingsButton_Leave(object sender, EventArgs e){

            SettingsButton.BackColor = Color.FromArgb(24, 30, 54);

            if (!DarkModeToggle.Checked) { SettingsButton.BackColor = Color.FromArgb(224, 224, 224); }

        }

        private void ExitButton_Click(object sender, EventArgs e){

            Environment.Exit(0);

        }

        private void ExitButton_Click_1(object sender, EventArgs e){

            Environment.Exit(0);
        
        }

        private void BinaryInputTextBox_TextChanged(object sender, EventArgs e){

            //input = BinaryInputTextBox.Text;

            //BinaryOutputText.Text = input;

            ConvertBinary();

        }

        private void BinaryInputTextBox_Click(object sender, EventArgs e){

            if(BinaryInputTextBox.Text == " Input..."){

                BinaryInputTextBox.Text = string.Empty;

                return;

            }

            ConvertBinary();

        }

        private void BinaryInputTextBox_Leave(object sender, EventArgs e){

            if(BinaryInputTextBox.Text == string.Empty){

                BinaryInputTextBox.Text = " Input...";

                BinaryOutputText.Text = " Output...";

            }

        }

        private void BinaryToggle1_CheckedChanged(object sender, EventArgs e){

            toggle = BinaryToggle1.Checked;

            BinaryToggle2.Checked = !toggle;

            ConvertBinary();

        }

        private void BinaryToggle2_CheckedChanged(object sender, EventArgs e){

            toggle = BinaryToggle2.Checked;

            BinaryToggle1.Checked = !toggle;

            ConvertBinary();

        }

        private void DarkModeToggle_CheckedChanged(object sender, EventArgs e){

            ChangeTheme();

        }

        private void HexToggle1_CheckedChanged(object sender, EventArgs e){


            toggle = HexToggle1.Checked;

            HexToggle2.Checked = !toggle;

            ConvertHex();
        }

        private void HexToggle2_CheckedChanged(object sender, EventArgs e){

            toggle = HexToggle2.Checked;

            HexToggle1.Checked = !toggle;

            ConvertHex();

        }

        private void HexInputTextBox_TextChanged(object sender, EventArgs e){

            //input = HexInputTextBox.Text;

            //HexOutputTextBox.Text = input;

            ConvertHex();

        }

        private void HexInputTextBox_Click(object sender, EventArgs e){

            if (HexInputTextBox.Text == " Input..."){

                HexInputTextBox.Text = string.Empty;

                return;

            }

            ConvertHex();

        }

        private void HexInputTextBox_Leave(object sender, EventArgs e){

            if (HexInputTextBox.Text == string.Empty){

                HexInputTextBox.Text = " Input...";

                HexOutputTextBox.Text = " Output...";

            }

        }

        private void HexResetButton_Click(object sender, EventArgs e){

            ResetHex();

        }

        private void BinaryResetButton_Click(object sender, EventArgs e){

            ResetBinary();

        }

        private void HashToggle1_CheckedChanged(object sender, EventArgs e){

            toggle = HashToggle1.Checked;

            HashToggle2.Checked = !toggle;

            ConvertHash();

        }

        private void HashToggle2_Click(object sender, EventArgs e){

            toggle = HashToggle2.Checked;

            HashToggle1.Checked = !toggle;

            ConvertHash();

        }

        private void HashInputTextBox_Leave(object sender, EventArgs e){

            if (HashInputTextBox.Text == string.Empty){

                HashInputTextBox.Text = " Input...";

                HashOutputTextBox.Text = " Output...";

            }

        }

        private void HashInputTextBox_TextChanged(object sender, EventArgs e){

            //input = HashInputTextBox.Text;

            //HashOutputTextBox.Text = input;

            ConvertHash();

        }

        private void HashInputTextBox_Click(object sender, EventArgs e){

            if (HashInputTextBox.Text == " Input..."){

                HashInputTextBox.Text = string.Empty;

                return;

            }

            ConvertHash();

        }

        private void HashReset_Click(object sender, EventArgs e){

            ResetHash();

        }

        private void HomeButton_Click(object sender, EventArgs e){

            NavPanel.Height = HomeButton.Height;
            NavPanel.Top = HomeButton.Top;
            NavPanel.Left = HomeButton.Left;
            HomeButton.BackColor = Color.FromArgb(46, 51, 73);
            CategoryLabel.Text = "Home";
            SwitchPanel(HomePanel);

            if (!DarkModeToggle.Checked) { HomeButton.BackColor = Color.Silver; }

        }

        private void HomeButton_Leave(object sender, EventArgs e){

            HomeButton.BackColor = Color.FromArgb(24, 30, 54);

            if (!DarkModeToggle.Checked) { HomeButton.BackColor = Color.FromArgb(224, 224, 224); }

        }

    }

}
