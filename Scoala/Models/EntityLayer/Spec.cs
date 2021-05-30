using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class Spec : BasePropertyChanged
    {
        private int? idSpec;
        public int? IdSpec
        {
            get
            {
                return idSpec;
            }
            set
            {
                idSpec = value;
                NotifyPropertyChanged("IdSpec");
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
        public override string ToString()
        {
            return Nume;
        }
    }
}
