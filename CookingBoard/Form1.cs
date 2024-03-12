using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CookingBoard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string APIKey = "95ecd6fde2f74d90991724206034f04b";

        //https://docs.private-ai.com/fundamentals/getting-started/

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            if (comboBox2.SelectedIndex == 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    if (i == 10)
                    {
                        comboBox1.Items.Add(1 + "L");
                        break;
                    }
                    comboBox1.Items.Add(i + "00" + "ml");
                    
                }
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                for (int i = 1; i <= 9; i++)
                {
                    comboBox1.Items.Add(i);
                }
            }
        }
    }
}
