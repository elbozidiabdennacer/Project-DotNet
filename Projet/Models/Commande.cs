using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Commande
    {

        private int _IdC;
        private int _IdBk;
        private int _quantite;
        private string _Date;

        public Commande() { }

        public Commande(int IdC,int IdBk,int quantite)
        {
            _IdBk = IdBk;
            _IdC = IdC;
            _quantite = quantite;
            _Date = DateTime.Now.ToString("dd MMMM yyyy hh:mm:ss tt");

        }

        public int IdC
        {
            get { return _IdC; }
            set { _IdC = value; }
        }

        public int IdBk
        {
            get { return _IdBk; }
            set { _IdBk = value; }
        }

        public int quantite
        {
            get { return _quantite; }
            set { _quantite = value; }
        }

        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

    }
}