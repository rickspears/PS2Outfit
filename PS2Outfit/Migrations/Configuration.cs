namespace PS2Outfit.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PS2Outfit.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<PS2Outfit.Data.Services.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
                
        /*
        protected override void Seed(PS2Outfit.Data.Services.AppContext context)
        {
            context.Players.AddOrUpdate(d => d.Handle,
                    new PlayerEntity() { Handle = "Valiryon",
                                         FavoriteClass = "Infiltrator",
                                         FavoriteVehicle = "Mosquito",
                                         JoinDate = new DateTime(2012,11,20),
                                         Server = "Mattherson",
                                         Active = false,
                                         Rank = "Leader"},
                    new PlayerEntity() { Handle = "Philan",
                                         FavoriteClass = "Light Infantry",
                                         FavoriteVehicle = "Liberator",
                                         JoinDate = new DateTime(2012,11,21),
                                         Server = "Mattherson",
                                         Active = false,
                                         Rank = "Leader"}
                );
        }
         */
    }
}
