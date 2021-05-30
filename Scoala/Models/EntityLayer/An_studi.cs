using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class An_studi : BasePropertyChanged
    {
        private int? idAn;
        public int? IdAn
        {
            get
            {
                return idAn;
            }
            set
            {
                idAn = value;
                NotifyPropertyChanged("IdAn");
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
