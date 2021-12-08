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
    class SearchProViewModel : ObservableCollection<nImage>
    {
        private static string uid = MainViewModel.SaveId();
        public static string userId;
        public SearchProViewModel()
        {
            try
            {
                var re = (from a in NewData.NewPosts
                          where a.User == userId
                          select a).ToList();
                foreach (var a in re)
                {
                    this.Add(new nImage() { Img = a.Image, Id = a.User, Text = a.Text });
                }
            }
            catch(Exception ex) { }
        }
        public static void PlusAlarm()
        {
            NewAlarm newAlarm = new NewAlarm()
            {
                Send = UserStore.ID,
                Rec = userId,
                Kind = "follow",
                PostNum = 0
            };
            NewData.NewAlarms.Add(newAlarm);
            NewData.Save();
        }

        public string UId
        {
            get { return MainViewModel.SaveId(); }
        }

        public string Name 
        {
            get 
            {
                try
                {
                    NewUser newUser = NewData.NewUsers.Single(x => x.Id == MainViewModel.userId);
                    return newUser.Name;
                }
                catch (Exception ex) { }
                return "none";
            }
        }
        public int PostNum
        {
            get
            {
                try
                {
                    NewUser newUser = NewData.NewUsers.Single(x => x.Id == MainViewModel.userId);
                    return newUser.PostNum;
                }catch(Exception ex) { }
                return 0;
            }
        }
        public int Follower
        {
            get
            {
                try
                {
                    NewUser newUser = NewData.NewUsers.Single(x => x.Id == MainViewModel.userId);
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
                    NewUser newUser = NewData.NewUsers.Single(x => x.Id == MainViewModel.userId);
                    return newUser.FollowingNum;
                }
                catch (Exception ex) { }
                return 0;
            }
        }
        public string Profile
        {
            get
            {
                try
                {
                    NewUser newUser = NewData.NewUsers.Single(x => x.Id == MainViewModel.userId);
                    return newUser.Profile;
                }
                catch(Exception ex) { }
                return "/Image/profileKey8.png";
            }
        }
        public string Set
        {
            get
            {
                try
                {
                    NewUser newUser = NewData.NewUsers.Single(x => x.Id == MainViewModel.userId);

                    string result = "팔로우";
                    var re = (from a in NewData.NewFollows
                              where a.UserId == UserStore.ID
                              select a).ToList();
                    foreach (var a in re)
                    {
                        if (a.Following == MainViewModel.userId)
                            result = "언팔로우";
                    }
                    return result;
                }
                catch (Exception ex) { }
                return "팔로우";
            }
        }
        public static bool Re()
        {
            try
            {
                NewUser newUser = NewData.NewUsers.Single(x => x.Id == MainViewModel.userId);

                bool result = false;
                var re = (from a in NewData.NewFollows
                          where a.UserId == UserStore.ID
                          select a).ToList();
                foreach (var a in re)
                {
                    if (a.Following == MainViewModel.userId)
                        result = true;
                }
                return result;
            }
            catch (Exception ex) { }
            return false;
        }
        public static void ChangeF()
        {
            try
            {
                NewUser newUser = NewData.NewUsers.Single(x => x.Id == MainViewModel.userId);//상대
                NewUser newUser2 = NewData.NewUsers.Single(x => x.Id == UserStore.ID); //로그인중
                NewFollow newFollow = NewData.NewFollows.Single(x => x.UserId == UserStore.ID && x.Following == MainViewModel.userId);

                newUser.FollowerNum -= 1;
                newUser2.FollowingNum -= 1;
                NewData.Save();

                NewData.NewFollows.Remove(newFollow);
                NewData.Save();
            }catch (Exception ex) { }
        }
        public static void ChangeFo()
        {
            try
            {
                NewUser newuser = NewData.NewUsers.Single(x => x.Id == MainViewModel.userId);//상대
                NewUser newuser2 = NewData.NewUsers.Single(x => x.Id == UserStore.ID); //로그인중

                int fower = newuser.FollowerNum + 1;
               
                newuser.FollowerNum = fower;
                newuser2.FollowingNum += 1;
                NewData.Save();

                NewFollow newFollow1 = new NewFollow()
                {
                    UserId = UserStore.ID,
                    Following = MainViewModel.userId
                };
                NewData.NewFollows.Add(newFollow1);
                NewData.Save();
            }
            catch (Exception ex) { }
        }
    }
    public class nImage
    {
        public string Img { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }
    }
}
