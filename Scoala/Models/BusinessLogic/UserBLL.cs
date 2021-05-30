using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Scoala.Models.EntityLayer;
using Scoala.Models.DataLayer;
using System.Windows;
using Scoala.Views;
using System.Windows.Controls;
using Scoala.Functions;

namespace Scoala.Models.BusinessLogic
{
    class UserBLL
    {
        public ObservableCollection<User> UserList { get; set; }

        UserDAL userDAL = new UserDAL();

        public ObservableCollection<User> GetAllUsers()
        {
            return userDAL.GetAllUsers();
        }

        public void Login(User this_user)
        {
            int k = 0;
            foreach (User us in UserList)
            {
                if (us.Username == this_user.Username && us.Password == this_user.Password)
                {
                    Help_Funct.AbsList = null;
                    Help_Funct.CurrentUser = us;
                    k++;
                    if (us.Rol == "elev")
                    {
                        Window nou = new Elev_wind();
                        nou.Show();
                    }
                    else if (us.Rol == "admin")
                    {
                        Window nou = new AdminW();
                        nou.Show();
                    }
                    else 
                    {
                        MaterieDAL newmat = new MaterieDAL();
                        Functions.Help_Funct.CurrentProfMat = newmat.GetIdMatProfUser();
                        Window nou = new Prof_win();
                        nou.Show();
                    };
                        
                        break;
                }
            }
            if(k==0)
                MessageBox.Show("Username sau Password Gresit!");
        }
    }
}
