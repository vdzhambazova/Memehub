﻿using MemeHub.Data;
using MemeHub.Models.Models;
using MemeHub.Services.Contracts;

namespace MemeHub.Services
{
    public class AccountService : Service, IAccountService
    {
        public void CreateUser(ApplicationUser user)
        {
            Poster poster = new Poster();
            ApplicationUser currentUser = this.Context.Users.Find(user.Id);
            poster.User = currentUser;
            this.Context.Posters.Add(poster);
            this.Context.SaveChanges();
        }

        public override MemeHubContext Context { get; set; }
    }
}
