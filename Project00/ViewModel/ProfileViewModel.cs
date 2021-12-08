using Project00.DataAccess;
using Project00.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project00.ViewModel
{
    public class ProfileViewModel : ObservableCollection<Image>, INotifyPropertyChanged
    {
        public ProfileViewModel()
        {
            try
            {
                var re = (from a in NewData.NewPosts
                          where a.User == UserStore.ID
                          select a).ToList();
                foreach(var a in re)
                {
                    this.Add(new Image() { Img = a.Image, Id = a.User, Text = a.Text });
                }
            }
            catch (Exception ex) { }
        }

        public static void Remove(string user,string image, string text)
        {
            try
            {
                int pp2 = NewData.NewUsers.Single(x => x.Id == UserStore.ID).PostNum - 1;
                string image2 = "pack://application:,,,";
                NewPost newPost = NewData.NewPosts.Single(x => x.User == user &&
                x.Text == text && image2 + x.Image == image);
                NewData.NewPosts.Remove(newPost);
                NewData.Save();

                NewUser ne = NewData.NewUsers.Single(x => x.Id == UserStore.ID);
                ne.PostNum = pp2;
                NewData.Save();
            }
            catch (Exception ex) { }
        }
        public string Id
        {
            get { return UserStore.ID; }
        }
        public int PostNum
        {
            get
            {
                try
                {
                    NewUser newUser = NewData.NewUsers.Single(x => x.Id == UserStore.ID);
                    return newUser.PostNum;
                } catch(Exception ex) { }
                return 0;
            }
        }
        public int Follower 
        {
            get
            {
                try
                {
                    NewUser newUser = NewData.NewUsers.Single(x => x.Id == UserStore.ID);
                    return newUser.FollowerNum;
                }
                catch (Exception ex) { }
                return 0;
            }
        }
        public int Following
        {
            get
            {
                try
                {
                    NewUser newUser = NewData.NewUsers.Single(x => x.Id == UserStore.ID);
                    return newUser.FollowingNum;
                }
                catch (Exception ex) { }
                return 0;
            }
        }
        public string Name
        {
            get
            {
                try
                {
                    NewUser newUser = NewData.NewUsers.Single(x => x.Id == UserStore.ID);
                    return newUser.Name;
                }
                catch (Exception ex) { }
                return "none";
            }
        }
        public string Profile
        {
            get
            {
                try
                {
                    NewUser newUser = NewData.NewUsers.Single(x => x.Id == UserStore.ID);
                    return newUser.Profile;
                }
                catch (Exception ex) { }
                return "/Image/profileKey8.png";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this,
                new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class Image
    {
        public string Img { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }
    }
}
