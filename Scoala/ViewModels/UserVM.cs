using Scoala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Scoala.Models.BusinessLogic;
using System.Collections.ObjectModel;
using Scoala.ViewModels.Commands;

namespace Scoala.ViewModels
{
    class UserVM : BasePropertyChanged
    {
        UserBLL userBLL = new UserBLL();

        public UserVM()
        {
            UsersList = userBLL.GetAllUsers();
        }
        

        public ObservableCollection<User> UsersList
        {
            get
            {
                return userBLL.UserList;
            }
            set
            {
                userBLL.UserList = value;
            }
        }
        private ICommand loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new RelayCommand<User>(userBLL.Login);   
                }
                return loginCommand;
            }
        }

    }
}
