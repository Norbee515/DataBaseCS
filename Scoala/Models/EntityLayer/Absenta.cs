using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class Absenta:BasePropertyChanged
    {
        private int idAbsenta;
        public int IDAbsenta
        {
            get
            {
                return idAbsenta;
            }
            set
            {
                idAbsenta = value;
                NotifyPropertyChanged("IDAbsenta");
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
        private string e_motivbl;
        public string E_motivbl
        {
            get
            {
                return e_motivbl;
            }
            set
            {
                e_motivbl = value;
                NotifyPropertyChanged("E_motivbl");
            }
        }
        private string e_motiv;
        public string E_motiv
        {
            get
            {
                return e_motiv;
            }
            set
            {
                e_motiv = value;
                NotifyPropertyChanged("E_motiv");
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
