namespace PS2Outfit.Models
{
    using System;
    using PS2Outfit.Entities;
    using PS2Outfit.Enums;
    using PS2Outfit.Events;

    public class PlayerModel : NotifyPropertyChanged
    {
        private string handle;
        public string Handle {
            get {
                return handle;
            }
            set {
                handle = value;
                OnPropertyChanged("Handle");
            }
        }

        private string favoriteClass;
        public string FavoriteClass {
            get {
                return favoriteClass;
            }
            set {
                favoriteClass = value;
                OnPropertyChanged("FavoriteClass");
            }
        }

        private string favoriteVehicle;
        public string FavoriteVehicle {
            get {
                return favoriteVehicle;
            }
            set {
                favoriteVehicle = value;
                OnPropertyChanged("FavoriteVehicle");
            }
        }

        private DateTime joinDate;
        public DateTime JoinDate {
            get {
                return joinDate;
            }
            set {
                joinDate = value;
                OnPropertyChanged("JoinDate");
            }
        }

        private string server;
        public string Server {
            get {
                return server;
            }
            set {
                server = value;
                OnPropertyChanged("Server");
            }
        }

        private bool active;
        public bool Active {
            get {
                return active;
            }
            set {
                active = value;
                OnPropertyChanged("Active");
            }
        }

        private string rank;
        public string Rank {
            get {
                return rank;
            }
            set {
                rank = value;
                OnPropertyChanged("Rank");
            }
        }

        private int id;
        public int Id {
            get {
                return id;
            }
            set {
                id = value;
                OnPropertyChanged("PlayerId");
            }
        }

        public PlayerModel(PlayerEntity entity) {
            this.handle = entity.Handle;
            this.favoriteClass = entity.FavoriteClass;
            this.favoriteVehicle = entity.FavoriteVehicle;
            this.joinDate = entity.JoinDate;
            this.server = entity.Server;
            this.active = entity.Active;
            this.rank = entity.Rank;
            this.id = entity.Id;
        }
    }
}
