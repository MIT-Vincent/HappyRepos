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
                    MessageBox.Show("Invalid DNA Stream!", "Invalid Input!");
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
                inputStrand1.Text = dna.Strand1;
                MT.Text = dna.Mt.ToString() + "° C";
                BP.Text = dna.Bp.ToString();
                GC.Text = dna.Gc.ToString() + @"%";
            }
        }
    }
}
