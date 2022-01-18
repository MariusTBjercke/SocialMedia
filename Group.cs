using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia
{
    internal class Group
    {
        public int Id;
        public List<int> Members = new List<int>();
        public string Name;

        public Group(int id, string name)
        {
            Id = id;
            Name = name;
            Members.Add(App.CurrentUser.Id);
        }

        public void AddMember(int id)
        {
            Members.Add(id);
        }

        public void ShowMembers()
        {
            if (Members.Count > 0)
            {
                foreach (var member in Members)
                {
                    var index = App.Users.FindIndex(x => x.Id == member);
                    Console.WriteLine(App.Users[index]);
                }
            }
            else
            {
                // This message should not appear as the creator of the group should always be a member.
                Console.WriteLine("Denne gruppen er tom.");
            }
        }
    }
}
