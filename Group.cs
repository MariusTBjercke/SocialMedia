using System;
using System.Collections.Generic;

namespace SocialMedia
{
    internal class Group
    {
        public int Id { get; }
        public List<int> Members { get; } = new();
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

        public void ChangeName(string newName)
        {
            Name = newName;
        }
    }
}
