using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.Models.EntityLayer
{
    class User: BasePropertyChanged
    {
        private int? idUser;
        public int? IDUser
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

        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                NotifyPropertyChanged("Username");
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }
        private string rol;
        public string Rol
        {
            get
            {
                return rol;
            }
            set
            {
                rol = value;
                NotifyPropertyChanged("Rol");
            }
        }
    }
}
