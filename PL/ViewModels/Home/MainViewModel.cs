using PL.ViewModels.User;

namespace PL.ViewModels.Home
{
    public class MainViewModel
    {

        public LoginViewModel LoginViewModel { get; set; }
        public DAL.Entities.User UserModel { get; set; }
    }
}
