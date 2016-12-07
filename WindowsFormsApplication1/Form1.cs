using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        MethodChains MC = new MethodChains();
        CombinedMethod CM = new CombinedMethod();
        IdentifierTableList ITL = new IdentifierTableList();
        List<string>[,] identifierTable = new List<string>[200, 200];

        int[] hashTable = new int[101];
        int[] hashTable2 = new int[101];
        string[] idnt = new string[200];
        Char[] pwdChars = new Char[36] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public Form1()
        {
            InitializeComponent();
            ITL.list = new List<IdentifierTable>();

            for(int i = 0; i < 100; i++)
            {
                hashTable[i] = -1;
                hashTable2[i] = -1;
            }

            for (int i = 0; i < 200; i++)
            {
                string s = "";

                for (int j = 0; j < r.Next(1, 32); j++)
                {
                    s = s + pwdChars[r.Next(1, 35)];
                }

                panel3.Visible = false;

                dataGridView1.Rows.Clear();
                listBox1.Items.Clear();

                MC.Entry(s, ITL.list, hashTable);
                CM.Entry(s, identifierTable, hashTable2);

                for (int j = 0; j < ITL.list.Count; j++)
                {
                    dataGridView1.Rows.Add(ITL.list[j].item, ITL.list[j].link);
                }

                for (int j = 0; j < identifierTable.GetLength(0); j++)
                {
                    string TextAdd = "";

                    for (int l = 0; l < identifierTable.GetLength(1); l++)
                    {
                        if (identifierTable[j, l] != null)
                        {
                            TextAdd += identifierTable[j, l][0] + " ";
                        }
                    }

                    listBox1.Items.Add(TextAdd);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;

            dataGridView1.Rows.Clear();
            listBox1.Items.Clear();

            MC.Entry(textBox1.Text, ITL.list, hashTable);
            CM.Entry(textBox1.Text, identifierTable, hashTable2);

            for(int i = 0; i < ITL.list.Count; i++)
            {
                dataGridView1.Rows.Add(ITL.list[i].item, ITL.list[i].link);
            }

            for(int i = 0; i < identifierTable.GetLength(0); i++)
            {
                string TextAdd = "";

                for(int j = 0; j < identifierTable.GetLength(1); j++)
                {
                    if (identifierTable[i, j] != null)
                    {
                        TextAdd += identifierTable[i, j][0] + " ";
                    }
                }

                listBox1.Items.Add(TextAdd);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            label5.Text = MC.Search(textBox2.Text, ITL.list, hashTable);
            label6.Text = CM.Search(textBox2.Text, identifierTable, hashTable2);
            label8.Text = MC.Сomparisons.ToString();
            label9.Text = CM.Сomparisons.ToString();
            label12.Text = MC.ElapsedTime;
            label11.Text = CM.ElapsedTime;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CM.Entry(textBox1.Text, identifierTable, hashTable2);
        }
    }
}
