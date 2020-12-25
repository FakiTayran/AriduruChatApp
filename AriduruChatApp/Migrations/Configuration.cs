namespace AriduruChatApp.Migrations
{
    using AriduruChatApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AriduruChatApp.Models.UserDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AriduruChatApp.Models.UserDbContext context)
        {
            User user = new User { Id = 1, Password = "1234", UserSessionId = "", UserName = "admin" };
        }
    }
}
