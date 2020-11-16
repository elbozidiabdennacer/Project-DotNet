using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet.Models
{
    public class getCommande
    {
        private string _NomC;
        private string _PrenomC;
        private string _EmailC;
        private string _AddresseC;
        private string _TeleC;

        private string _NomBk;
        private int _IdBk;
        private string _date;


        public string Nom
        {
            get { return _NomC; }
            set { _NomC = value; }
        }

        public string Prenom
        {
            get { return _PrenomC; }
            set { _PrenomC = value; }
        }

        public string Email
        {
            get { return _EmailC; }
            set { _EmailC = value; }
        }

        public string Addresse
        {
            get { return _AddresseC; }
            set { _AddresseC = value; }
        }

        public string Tele
        {
            get { return _TeleC; }
            set { _TeleC = value; }
        }

        public string NomBk
        {
            get { return _NomBk; }
            set { _NomBk = value; }
        }

        public int IdBk
        {
            get { return _IdBk; }
            set { _IdBk = value; }
        }

        public string date
        {
            get { return _date; }
            set { _date = value; }
        }
    }
}