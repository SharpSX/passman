using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace passMan
{
    public partial class Form1 : Form
    {

        int length = 16;

        bool inclLetters = true;
        bool inclNumbers = true;
        bool inclSpecials = false;

        bool idiotMode = true;

        List<String> chars = new List<String>();

        string title = "Passman | Password Generator";

        string letters = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
        string numbers = "1234567890";
        string specials = "!@#$%&/=£€";

        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            UpdateChars();
            Text = title;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = "";
            if (chars.Count == 0)
            {
                msgBox("Error", "You haven't selected any characters to include!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < length; i++)
            {
                result = result + chars[random.Next(chars.Count)];
            }
            Clipboard.SetText(result);
            if (idiotMode)
            {
                MessageBox.Show("Your new password is: " + result + Environment.NewLine + "The password was copied to your clipboard, you can paste it with CTRL+V", "Completed!");
            }
            else {
                Text = "Copied to clipboard!";
                timer1.Start();
            }
        }

        public void msgBox(string title, string message, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, buttons, icon);
        }

        public void UpdateChars()
        {
            chars = new List<string>();
            if (inclLetters)
            {
                foreach (char x in letters)
                {
                    chars.Add(x.ToString());
                }
            }
            if (inclNumbers)
            {
                foreach (char x in numbers)
                {
                    chars.Add(x.ToString());
                }
            }
            if (inclSpecials)
            {
                foreach (char x in specials) 
                {
                    chars.Add(x.ToString());
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            length = int.Parse(numericUpDown1.Value.ToString());

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            inclNumbers = checkBox1.Checked;
            UpdateChars();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            inclSpecials = checkBox2.Checked;
            UpdateChars();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            inclLetters = checkBox3.Checked;
            UpdateChars();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Text = title;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                idiotMode = !idiotMode;
                Text = "Set Simple Mode to: " + idiotMode;
                timer1.Start();
            }
        }

        public void EasterEgg() {
            msgBox("Easter Egg!", "Made by SharpSX & senge1337", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            EasterEgg();
        }
    }
}