using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.ViewModels
{
    public class MainViewModel
    {

        public LoginViewModel LoginViewModel { get; set; }
        public User UserModel { get; set; }
    }
}
