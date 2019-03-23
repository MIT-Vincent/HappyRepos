using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleActivity;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool a = true;
            char[] c = inputStrand.Text.ToCharArray();

            foreach (char n in c)
            {
                if ((n != 'A') && (n != 'G') && (n != 'C') && (n != 'T') && (n != '-') && (n != '5') && (n != '3')
                     && (n != '\''))
                {
                    MessageBox.Show("Invalid DNA Stream!", "Invalid Input -- Cannot Be Calculated!");
                    a = false;
                }
            }


            if (a == true)
            {
                DNAStuff dna = new DNAStuff(inputStrand.Text);
                groupBox1.Enabled = true;
                inputStrand.Text = "";
                dna.computeMT();
                dna.computeGC();
                if ((dna.Bp > 50) || (dna.Bp < 5))
                {
                    MessageBox.Show("Invalid Bases!", "Invalid Input -- Cannot Be Calculated!");
                    inputStrand1.Text = "Invalid Bases!";
                    MT.Text = "Invalid Bases!";
                    BP.Text = "Invalid Bases!";
                    GC.Text = "Invalid Bases!";
                    complimentaryStrand.Text = "Invalid Bases!";
                }
                else
                {
                    inputStrand1.Text = dna.Strand1;
                    MT.Text = dna.Mt.ToString() + "° C";
                    BP.Text = dna.Bp.ToString();
                    GC.Text = dna.Gc.ToString() + @"%";
                    complimentaryStrand.Text = dna.Strand2;
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Activity 3 - C# Application!", "ABOUT");
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("N/A", "N/A");
        }
    }
}
