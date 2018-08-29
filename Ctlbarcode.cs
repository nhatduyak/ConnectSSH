using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace WindowsFormsApplication2.Model
{
    public class Ctlbarcode
    {
        public int lenght=13;
        public string Store;
        public string Tranx;
        public string Register;
        public DateTime datetime;
        public Hashtable tbHeso;
        public int hangSoDate = 36161;
        public Ctlbarcode()
        {
            InitHeso();
        }
        public void InitHeso()
        {
            tbHeso = new Hashtable();
            tbHeso.Add("A", 0);
            tbHeso.Add("B", 1);
            tbHeso.Add("C", 2);
            tbHeso.Add("D", 3);
            tbHeso.Add("E", 4);
            tbHeso.Add("F", 5);
            tbHeso.Add("G", 6);
            tbHeso.Add("H", 7);
            tbHeso.Add("I", 8);
            tbHeso.Add("J", 9);
            tbHeso.Add("K", 10);
            tbHeso.Add("L", 11);
            tbHeso.Add("M", 12);
            tbHeso.Add("N", 13);
            tbHeso.Add("O", 14);
            tbHeso.Add("P", 15);
            tbHeso.Add("Q", 16);
            tbHeso.Add("R", 17);
            tbHeso.Add("S", 18);
            tbHeso.Add("T", 19);
            tbHeso.Add("U", 20);
            tbHeso.Add("V", 21);
            tbHeso.Add("W", 22);
            tbHeso.Add("X", 23);
            tbHeso.Add("Y", 24);
            tbHeso.Add("Z", 25);
            
        }
    }
}
