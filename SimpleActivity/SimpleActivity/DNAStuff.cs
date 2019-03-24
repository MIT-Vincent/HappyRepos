using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleActivity
{
    public class DNAStuff
    {
        private double mt;
        private double cytinide;
        private double thymidine;
        private double adenosine;
        private double guanosine;
        private double bp;
        private double gc;
        private string strand1;
        private string strand2;
        public Exception incorrectStrand;
        private double h;
        private double s;
        private double A = -0.0108;
        private double R = 0.00199;
        private double Cc = 0.000000125;
        private double K = 0.05;
        private bool dnacheck = true;
        public double Mt { get => mt; set => mt = value; }
        public double Cytinide { get => cytinide; set => cytinide = value; }
        public double Thymidine { get => thymidine; set => thymidine = value; }
        public double Adenosine { get => adenosine; set => adenosine = value; }
        public double Guanosine { get => guanosine; set => guanosine = value; }
        public double Bp { get => bp; set => bp = value; }
        public double Gc { get => gc; set => gc = value; }
        public string Strand1 { get => strand1; set => strand1 = value; }
        public string Strand2 { get => strand2; set => strand2 = value; }
        public bool Dc { get => dnacheck; set => dnacheck = value; }

        public DNAStuff(string strand)
        {
            Strand1 = strand;
            try
            {
                if (formatStrand() == false)
                {
                    dnacheck = false;
                    throw incorrectStrand;
                }
                   
            }
            catch
            {
                MessageBox.Show("Strand must be in a 5' - 3' !");
            }
            getCompliment();
            
        }
             
        

        public void getCytinide()
        {
            char[] strando = Strand1.ToCharArray();
            foreach (char n in strando)
            {
                if (n == 'C')
                {
                    Cytinide++;
                    Bp++;
                }
            }
            
        }

        public void getThymidine()
        {
            char[] strando = Strand1.ToCharArray();
            foreach (char n in strando)
            {
                if (n == 'T')
                {
                    Thymidine++;
                    Bp++;
                }
            }
        }

        public void getAdenosine()
        {
            char[] strando = Strand1.ToCharArray();
            foreach (char n in strando)
            {
                if (n == 'A')
                {
                    Adenosine++;
                    Bp++;
                }
            }
        }

        public void getGuanosine()
        {
            char[] strando = Strand1.ToCharArray();
            foreach (char n in strando)
            {
                if (n == 'G')
                {
                    Guanosine++;
                    Bp++;
                }
            }
        }

        public void computeMT ()
        {
            getAdenosine();
            getCytinide();
            getGuanosine();
            getThymidine();
            if (Bp < 14)
            {
                Mt = 2 * (Adenosine + Thymidine) + 4 * (Cytinide + Guanosine) - 7;
            }
            else
                computeMT2();
        }
        public void computeGC ()
        {
            
                Gc = ((Guanosine + Cytinide) / Bp) * 100;
                Gc = Math.Round(Gc, 2);
            
        }
        public void getCompliment ()
        {
            char[] strando = Strand1.ToCharArray();

            for(int i = 0; i < strando.Length; i++)
            {
                if (strando[i] == 'C')
                {
                    strando[i] = 'G';
                    continue;
                }
                if (strando[i] == 'G')
                {
                    strando[i] = 'C';
                    continue;
                }
                if (strando[i] == 'A')
                {
                    strando[i] = 'T';
                    continue;
                }
                if (strando[i] == 'T')
                {
                    strando[i] = 'A';
                    continue;
                }
                if (strando[i] == '5')
                {
                    strando[i] = '3';
                    continue;
                }
                if (strando[i] == '3')
                {
                    strando[i] = '5';
                    continue;
                }

            }
            Strand2 = new string(strando);
        }

        public bool formatStrand()
        {
            string strandont = Strand1;
            if (strandont.StartsWith("5'-") == true)
            {
                strandont = strandont.Remove(0, 3);
                Strand1 = strandont;
            }
            if (strandont.EndsWith("-3'") == true)
            {
                strandont = strandont.Remove(strandont.Length - 3, 3);
                Strand1 = strandont;
            }
            if (strandont.StartsWith("5-") == true)
            {
                strandont = strandont.Remove(0, 2);
                Strand1 = strandont;
            }
            if (strandont.EndsWith("-3") == true)
            {
                strandont = strandont.Remove(strandont.Length - 2, 2);
                Strand1 = strandont;
            }
            if (strandont.StartsWith("5") == true)
            {
                strandont = strandont.Remove(0, 1);
                Strand1 = strandont;
            }
            if (strandont.EndsWith("3") == true)
            {
                strandont = strandont.Remove(strandont.Length - 1, 1);
                Strand1 = strandont;
            }
            if (strandont.StartsWith("3") == true)
            {
                return false;
            }
                return true;
        }

        public void computeMT2 ()
        {
            bool c = false;

            char[] n = Strand1.ToCharArray();
            // neighbors search method
            for (int i = 0; i < n.Length - 1;i++)
            {
                if (n[i+1]  == n[i])
                {
                    if ((n[i + 1] == 'T') || (n[i + 1] == 'A'))
                    {
                        h += -9.1;
                        s += -0.0240;
                    }
                    else
                    {
                        h += -11.0;
                        s += -0.0266;
                    }
                }

                if ((n[i+1] == 'A') && (n[i] == 'T'))
                {
                    if (c == false)
                    {
                        h += -6.0;
                        s += -0.0169;
                    }
                    else
                    {                     
                        h += -8.6;
                        s += -0.0239;
                    }
                }

                if ((n[i + 1] == 'T') && (n[i] == 'A'))
                {
                    if (c == false)
                    {
                        h += -6.0;
                        s += -0.0169;
                    }
                    else
                    {
                        h += -8.6;
                        s += -0.0239;
                    }
                }

                if ((n[i + 1] == 'G') && (n[i] == 'C'))
                {
                    if (c == false)
                    {
                        h += -11.1;
                        s += -0.0267;
                    }
                    else
                    {
                        h += -11.9;
                        s += -0.0278;
                    }
                }

                if ((n[i + 1] == 'C') && (n[i] == 'G'))
                {
                    if (c == false)
                    {
                        h += -11.9;
                        s += -0.0278;
                    }
                    else
                    {
                        h += -11.1;
                        s += -0.0267;
                    }
                }

                if ((n[i + 1] == 'G') && (n[i] == 'T'))
                { 
                        
                        if (c == false)
                        {
                            h += -5.8;
                            s += -0.0129;
                            c = true;
                            continue;
                        }
                        else
                        {
                            h += -6.5;
                            s += -0.0173;
                            c = false;
                            continue;
                        }
                }

                if ((n[i + 1] == 'G') && (n[i] == 'A'))
                {

                    if (c == false)
                    {
                        h += -7.8;
                        s += -0.0208;
                        c = true;
                        continue;
                    }
                    else
                    {
                        h += -5.6;
                        s += -0.0135;
                        c = false;
                        continue;
                    }
                }

                if ((n[i + 1] == 'C') && (n[i] == 'T'))
                {

                    if (c == false)
                    {
                        h += -5.6;
                        s += -0.0135;
                        c = true;
                        continue;
                    }
                    else
                    {
                        h += -7.8;
                        s += -0.0208;
                        c = false;
                        continue;
                    }
                }

                if ((n[i + 1] == 'C') && (n[i] == 'A'))
                {

                    if (c == false)
                    {
                        h += -6.5;
                        s += -0.0173;
                        c = true;
                        continue;
                    }
                    else
                    {
                        h += -5.8;
                        s += -0.0129;
                        c = false;
                        continue;
                    }
                }


                if ((n[i + 1] == 'A') && (n[i] == 'G'))
                {

                    if (c == false)
                    {
                        h += -7.8;
                        s += -0.0208;
                        c = true;
                        continue;
                    }
                    else
                    {
                        h += -5.6;
                        s += -0.0135;
                        c = false;
                        continue;
                    }
                }

                if ((n[i + 1] == 'A') && (n[i] == 'C'))
                {

                    if (c == false)
                    {
                        h += -6.5;
                        s += -0.0173;
                        c = true;
                        continue;
                    }
                    else
                    {
                        h += -5.8;
                        s += -0.0129;
                        c = false;
                        continue;
                    }
                }

                if ((n[i + 1] == 'T') && (n[i] == 'G'))
                {

                    if (c == false)
                    {
                        h += -5.8;
                        s += -0.0129;
                        c = true;
                        continue;
                    }
                    else
                    {
                        h += -6.5;
                        s += -0.0173;
                        c = false;
                        continue;
                    }
                }

                if ((n[i + 1] == 'T') && (n[i] == 'C'))
                {

                    if (c == false)
                    {
                        h += -5.6;
                        s += -0.0135;
                        c = true;
                        continue;
                    }
                    else
                    {
                        h += -7.8;
                        s += -0.0208;
                        c = false;
                        continue;
                    }
                }

            } // end of loop
            Mt = (h / (A + s + (R * (-15.8949520996)))) + (-273.15 + (16.6 * Math.Log10(K)));
        }
        
    }
    }

