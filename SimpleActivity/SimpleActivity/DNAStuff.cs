using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
        public double Mt { get => mt; set => mt = value; }
        public double Cytinide { get => cytinide; set => cytinide = value; }
        public double Thymidine { get => thymidine; set => thymidine = value; }
        public double Adenosine { get => adenosine; set => adenosine = value; }
        public double Guanosine { get => guanosine; set => guanosine = value; }
        public double Bp { get => bp; set => bp = value; }
        public double Gc { get => gc; set => gc = value; }
        public string Strand1 { get => strand1; set => strand1 = value; }
        public string Strand2 { get => strand2; set => strand2 = value; }

        public DNAStuff(string strand)
        {
            Strand1 = strand;
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
            Mt = 2 * (Adenosine + Thymidine) + 4 * (Cytinide + Guanosine) - 7;
           
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
            }
            Strand2 = new string(strando);
        }
        
    }
    }

