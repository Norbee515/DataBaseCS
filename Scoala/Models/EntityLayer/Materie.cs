using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class Materie : BasePropertyChanged
    {
        private int? idMaterie;
        public int? IdMaterie
        {
            get
            {
                return idMaterie;
            }
            set
            {
                idMaterie = value;
                NotifyPropertyChanged("IdMaterie");
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

        private bool are_teza;
        public bool Are_teza
        {
            get
            {
                return are_teza;
            }
            set
            {
                are_teza = value;
                NotifyPropertyChanged("Are_teza");
            }
        }
        private string are_tezaS;
        public string Are_tezaS
        {
            get
            {
                return are_tezaS;
            }
            set
            {
                are_tezaS = value;
                NotifyPropertyChanged("Are_tezaS");
            }
        }
        public override string ToString()
        {
            return Nume;
        }
    }
}
