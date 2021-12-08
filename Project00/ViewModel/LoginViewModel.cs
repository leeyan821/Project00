using Project00.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project00.DataAccess;

namespace Project00.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        static string id;

        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        static string password;

        public string Password
        {
            get { return password; }
            set
            { 
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public static bool Contain()
        {
            List<User> users = UserStore.LoadUsers();
            bool re = false;

            if (users.Exists(x => x.Id == id && x.Password == password))
            {
                UserStore.ID = id;
                re = true;
            }
            return re;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
