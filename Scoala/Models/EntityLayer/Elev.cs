using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class Elev:BasePropertyChanged
    {
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

        private string nume_pren;
        public string Nume_pren
        {
            get
            {
                return nume_pren;
            }
            set
            {
                nume_pren = value;
                NotifyPropertyChanged("Nume_pren");
            }
        }

        private string telefon;
        public string Telefon
        {
            get
            {
                return telefon;
            }
            set
            {
                telefon = value;
                NotifyPropertyChanged("Telefon");
            }
        }
        private string adresa;
        public string Adresa
        {
            get
            {
                return adresa;
            }
            set
            {
                adresa = value;
                NotifyPropertyChanged("Adresa");
            }
        }
        private int idCatalog;
        public int IdCatalog
        {
            get
            {
                return idCatalog;
            }
            set
            {
                idCatalog = value;
                NotifyPropertyChanged("IdCatalog");
            }
        }
        private int idUser;
        public int IDUser
        {
            get
            {
                return idUser;
            }
            set
            {
                idUser = value;
                NotifyPropertyChanged("IDUser");
            }
        }
        private string userN;
        public string UserN
        {
            get
            {
                return userN;
            }
            set
            {
                userN = value;
                NotifyPropertyChanged("UserN");
            }
        }
        private string passw;
        public string Passw
        {
            get
            {
                return passw;
            }
            set
            {
                passw = value;
                NotifyPropertyChanged("Passw");
            }
        }
        private Clasa clasa;
        public Clasa Clasa
        {
            get
            {
                return clasa;
            }
            set
            {
                clasa = value;
                NotifyPropertyChanged("Clasa");
            }
        }
        public override string ToString()
        {
            return Nume_pren;
        }
    }
}
