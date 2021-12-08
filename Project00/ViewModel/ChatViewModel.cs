using Project00.DataAccess;
using Project00.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project00.ViewModel
{
    class ChatViewModel : ObservableCollection<UserList>
    {
        public ChatViewModel()
        {
            var re = NewData.NewUsers.Where(x => !x.Id.Contains(UserStore.ID));
            foreach(var a in re)
            {
                this.Add(new UserList() { Id = a.Id, Profile = a.Profile });
            }
        }
    } 
    public class UserList
    {
        public string Id { get; set; }
        public string Profile { get; set; }
    }
}
