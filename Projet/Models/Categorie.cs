using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Categorie
    {
        private int _IdB;
        private string _NomB;

        public Categorie() { }

        public Categorie(string NomB,int IdB)
        {
            _IdB = IdB;
            _NomB = NomB;
        }

        public int IdB 
        {
            get { return _IdB; }
            set { _IdB = value; }
        }
        public string NomB
        {
            get { return _NomB; }
            set { _NomB = value; }
        }

    }
}