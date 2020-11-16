using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Livre
    {
        private int _IdBk;
        private string _Nom;
        private string _Auteur;
        private string _date_edition;
        private double _Prix;
        private string _pthimg;
        private int _IdB;

        public Livre() { }

        public Livre(string Nom,string Auteur,string date_edition,double Prix,string pthimg,int IdB )
        {
            _Nom = Nom;
            _Auteur = Auteur;
            _date_edition = date_edition;
            _Prix = Prix;
            _pthimg = pthimg;
            _IdB = IdB;
        }

        public int IdBk
        {
            get { return _IdBk; }
            set { _IdBk = value; }
        }

        public string Nom
        {
            get { return _Nom; }
            set { _Nom = value; }
        }

        public string Auteur
        {
            get { return _Auteur; }
            set { _Auteur = value; }
        }

        public string date_edition
        {
            get { return _date_edition; }
            set { _date_edition = value; }
        }

        public double Prix
        {
            get { return _Prix; }
            set { _Prix = value; }
        }

        public string pthimg
        {
            get { return _pthimg; }
            set { _pthimg = value; }
        }

        public int IdB
        {
            get { return _IdB; }
            set { _IdB = value; }
        }


    }
}