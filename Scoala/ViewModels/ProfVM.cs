using Scoala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoala.ViewModels
{
    class ProfVM
    {
        public static User CurrentUser { get; set; } = Functions.Help_Funct.CurrentUser;

    }
}
