using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class Nota : BasePropertyChanged
    {
        private int idNota;
        public int IDNota
        {
            get
            {
                return idNota;
            }
            set
            {
                idNota = value;
                NotifyPropertyChanged("IDNota");
            }
        }

        private int idMaterie;
        public int IDMaterie
        {
            get
            {
                return idMaterie;
            }
            set
            {
                idMaterie = value;
                NotifyPropertyChanged("IDMaterie");
            }
        }

        private string idElev;
        public string IDElev
        {
            get
            {
                return idElev;
            }
            set
            {
                idElev = value;
                NotifyPropertyChanged("IDElev");
            }
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
        private string e_teza;
        public string E_teza
        {
            get
            {
                return e_teza;
            }
            set
            {
                e_teza = value;
                NotifyPropertyChanged("E_teza");
            }
        }
        private string nota_str;
        public string Nota_str
        {
            get
            {
                return nota_str;
            }
            set
            {
                nota_str = value;
                NotifyPropertyChanged("Nota_str");
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
        private string semestru;
        public string Semestru
        {
            get
            {
                return semestru;
            }
            set
            {
                semestru = value;
                NotifyPropertyChanged("Semestru");
            }
        }
        private DateTime dataD;
        public DateTime DataD
        {
            get
            {
                return dataD;
            }
            set
            {
                dataD = value;
                NotifyPropertyChanged("DataD");
            }
        }
    }
}
