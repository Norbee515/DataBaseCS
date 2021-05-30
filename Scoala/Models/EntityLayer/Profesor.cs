using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class Profesor : BasePropertyChanged
    {
        private string idProf;
        public string IdProf
        {
            get
            {
                return idProf;
            }
            set
            {
                idProf = value;
                NotifyPropertyChanged("IdProf");
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
        private int idMat;
        public int IdMat
        {
            get
            {
                return idMat;
            }
            set
            {
                idMat = value;
                NotifyPropertyChanged("IdMat");
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
        private string e_dirig;
        public string E_dirig
        {
            get
            {
                return e_dirig;
            }
            set
            {
                e_dirig = value;
                NotifyPropertyChanged("E_dirig");
            }
        }
        public override string ToString()
        {
            return Nume_pren;
        }
    }
}
