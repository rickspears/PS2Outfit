namespace PS2Outfit.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Linq;
    using System.Windows.Input;
    using PS2Outfit.Commands;
    using PS2Outfit.Data.Services;
    using PS2Outfit.Entities;
    using PS2Outfit.Events;
    using PS2Outfit.Models;

    public class OutfitViewModel : NotifyPropertyChanged
    {
        #region Constructors
        public OutfitViewModel() {
            using (AppContext context = new AppContext()) {
                context.Players.Load();
                Outfit = GetPlayerCollection(context.Players.Local);
            }
        }
        #endregion

        #region Properties
        private ObservableCollection<PlayerModel> outfit;
        public ObservableCollection<PlayerModel> Outfit {
            get { return outfit; }
            set {
                outfit = value;
                OnPropertyChanged("Outfit");
            }
        }

        private PlayerModel selectedPlayer;
        public PlayerModel SelectedPlayer {
            get { return selectedPlayer; }
            set {
                selectedPlayer = value;
                OnPropertyChanged("selectedPlayer");
            }
        }
        #endregion

        #region Methods
        private ObservableCollection<PlayerModel> GetPlayerCollection(ICollection<PlayerEntity> entities) {
            ObservableCollection<PlayerModel> collection = new ObservableCollection<PlayerModel>();
            for (int i = 0; i < entities.Count; ++i) {
                PlayerModel model = new PlayerModel(entities.ElementAt(i));
                collection.Add(model);
            }
            return collection;
        }
        #endregion

        public void OnTargetUpdated(object sender, System.Windows.Data.DataTransferEventArgs args) { System.Windows.MessageBox.Show(selectedPlayer.FavoriteClass.ToString()); }

        #region Commands
        private void AddPlayerExecute(object arg) {
            using (var context = new AppContext()) {
                var player = context.Players.Create();

                player.Active = true;
                player.Handle = "Default";
                player.FavoriteClass = "Default";
                player.FavoriteVehicle = "Default";
                player.JoinDate = System.DateTime.Now;
                player.Rank = "Default";
                player.Server = "Default";

                context.Players.Add(player);
                context.SaveChanges();

                PlayerModel model = new PlayerModel(player);
                Outfit.Add(model);
            }

        }
        private bool CanAddPlayerExecute(object arg) {
            return true;
        }
        public ICommand AddPlayer {
            get { return new RelayCommand<object>(AddPlayerExecute, CanAddPlayerExecute); }
        }

        private void UpdatePlayerExecute(object arg) {
            using (AppContext context = new AppContext()) {
                PlayerEntity player = context.Players.First(x => x.Id == selectedPlayer.Id);
                context.Entry(player).CurrentValues.SetValues(selectedPlayer);
                context.SaveChanges();
                Outfit[Outfit.IndexOf(selectedPlayer)] = selectedPlayer;
            }
        }
        private bool CanUpdatePlayerExecute(object arg) {
            return true;
        }
        public ICommand UpdatePlayer {
            get { return new RelayCommand<object>(UpdatePlayerExecute, CanUpdatePlayerExecute); }
        }

        private void RemovePlayerExecute(object arg) {
            using (AppContext context = new AppContext()) {
                PlayerEntity player = context.Players.First(x => x.Id == selectedPlayer.Id);
                context.Players.Remove(player);
                context.SaveChanges();
                Outfit.Remove(selectedPlayer);
            }
        }
        private bool CanRemovePlayerExecute(object arg) {
            return selectedPlayer != null;
        }
        public ICommand RemovePlayer {
            get { return new RelayCommand<object>(RemovePlayerExecute, CanRemovePlayerExecute); }
        }

        #endregion
    }
}
