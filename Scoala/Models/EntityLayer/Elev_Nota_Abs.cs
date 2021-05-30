using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class Elev_Nota_Abs : BasePropertyChanged
    {
        public Elev_Nota_Abs(string n,string d,string a)
        { this.data = d;
            this.nume = n;
            this.aux = a;
        }

        public Elev_Nota_Abs()
        {
        }

        private string data;
        public string Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                NotifyPropertyChanged("Data");
            }
        }
        private string nume;
        public string Nume
        {
            get
            {
                return nume;
            }
            set
            {
                nume = value;
                NotifyPropertyChanged("Nume");
            }
        }
        private string aux;
        public string Aux
        {
            get
            {
                return aux;
            }
            set
            {
                aux = value;
                NotifyPropertyChanged("Aux");
            }
        }
    }
}
