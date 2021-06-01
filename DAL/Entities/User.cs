using System.Collections.Generic;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace DAL.Entities
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<ReaderDiary> ReaderDiaries { get; set; } 
        public IEnumerable<Subscription> Subscriptions { get; set; }
    }
}