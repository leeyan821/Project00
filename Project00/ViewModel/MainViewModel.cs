using Project00.DataAccess;
using Project00.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project00.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public static string userId;

        public string UserId
        {
            get { return userId; }
            set { 
                userId = value;
                OnPropertyChanged("UserId");
            }
        }
        public static string SaveId()
        {
            return userId;
        }
        public string Profile
        {
            get
            {
                try
                {
                    NewUser newUser = NewData.NewUsers.Single(x => x.Id == userId);
                    return newUser.Profile;
                }
                catch (Exception ex) { }
                return "/Image/profileKey8.png";
            }
        }
        public static void Pluslike(string user,string img, string text)
        {
            try
            {
                string image2 = "pack://application:,,,";
                int num = (from a in NewData.NewPosts
                       where a.User == user && image2 + a.Image == img && a.Text == text
                       select a.Num).Single();
                NewAlarm newAlarm = new NewAlarm()
                {
                    Send = UserStore.ID,
                    Rec = user,
                    Kind = "like",
                    PostNum =num
                };
                NewData.NewAlarms.Add(newAlarm);
                NewData.Save();
            }catch(Exception ex) { }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
