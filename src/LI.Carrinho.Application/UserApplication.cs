using LI.Carrinho.Application.Interfaces;

namespace LI.Carrinho.Application
{
    public class UserApplication : IUserApplication
    {
        public bool CheckUser(string username, string password)
        {
            return username.Equals("JbLojaIntegrada") && password.Equals("1234");
        }
    }
}
