using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Filmy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tyt = textBox4.Text;
            string rez = textBox5.Text;
            string data = dateTimePicker1.Text;
            string aktor = textBox3.Text;
            if (tyt.Length != 0 && rez.Length != 0 && data.Length != 0 && aktor.Length != 0)
            {
                DodDane(tyt, rez, data, aktor);
                textBox4.Text = "";
                textBox3.Text = "";
                textBox5.Text = "";
                dateTimePicker1.Text = "";
            }
            else
            {
                string message = "Dane są niekompletne";
                MessageBox.Show(message);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] linie = DoPliku();

            File.WriteAllLines("filmy.txt", linie);
        }

        private void DodDane(string tyt, string rez, string data, string aktor)
        {
            ListViewItem item = new ListViewItem(new string[] { tyt, rez, data, aktor });
            listView1.Items.Add(item);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ZPliku();
        }

        private void UsuwanieDanych()
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                listView1.Items.Remove(item);
            }
            listView1.Refresh();
        }

        private string[] DoPliku()
        {
            string[] linie = new string[listView1.Items.Count];
            int i = 0;

            foreach (ListViewItem item in listView1.Items)
            {
                linie[i] = "";
                for (int k = 0; k < item.SubItems.Count; k++)
                    linie[i] += item.SubItems[k].Text + "*";

                i++;
            }
            return linie;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ZPliku()
        {
            if (!File.Exists("filmy.txt"))
                return;

            string[] linie = File.ReadAllLines("filmy.txt");
            foreach (string linia in linie)
            {
                string[] temp = linia.Split('*');
                DodDane(temp[0], temp[1], temp[2], temp[3]);
            }
        }

        private void ZmnDanych()
        {
            string tyt = textBox4.Text;
            string rez = textBox3.Text;
            string data = dateTimePicker1.Text;
            string aktor = textBox5.Text;

            foreach (ListViewItem item in listView1.SelectedItems)
            {
                string[] linie = { tyt, rez, data, aktor };
                listView1.Items.Remove(item);
                listView1.Items.Add(Convert.ToString(linie));

            }
        }
    }
}
