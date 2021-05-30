using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class Clasa : BasePropertyChanged
    {
        private int? idClasa;
        public int? IdClasa
        {
            get
            {
                return idClasa;
            }
            set
            {
                idClasa = value;
                NotifyPropertyChanged("IdClasa");
            }
        }
        private string grupa;
        public string Grupa
        {
            get
            {
                return grupa;
            }
            set
            {
                grupa = value;
                NotifyPropertyChanged("Grupa");
            }
        }
        private string profil;
        public string Profil
        {
            get
            {
                return profil;
            }
            set
            {
                profil = value;
                NotifyPropertyChanged("Profil");
            }
        }
        public override string ToString()
        {
            return Grupa+Profil;
        }
    }
}
