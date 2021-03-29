using System.Collections.Generic;
using System.Collections.ObjectModel;
using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Wpf.Controls;
using SuperMarioRpg.Wpf.Main;
using SuperMarioRpg.Wpf.Menus.Status;
using SuperMarioRpg.Wpf.Overworld;

namespace SuperMarioRpg.Wpf.Menus.Root
{
    public class RootMenuViewModel : GameState
    {
        private readonly ObservableCollection<CharacterViewModel> _characters;
        private readonly ObservableCollection<string> _submenus;
        private string _selectedSubmenu;

        #region Creation

        public RootMenuViewModel(MainWindowViewModel game) : base(game)
        {
            _characters = new ObservableCollection<CharacterViewModel>();

            foreach (var character in GetCharacters())
                _characters.Add(new CharacterViewModel(character));

            PartyMembers = new ReadOnlyObservableCollection<CharacterViewModel>(_characters);

            _submenus = new ObservableCollection<string>();

            foreach (var submenu in GetSubmenus())
                _submenus.Add(submenu);

            Submenus = new ReadOnlyObservableCollection<string>(_submenus);
            
            ControlState = new ControlState
            {
                XCommand = new Command(ExitMenu)
            };
        }

        private void ExitMenu()
        {
            Game.SetGameState(new Field(Game));
        }

        public string SelectedSubmenu
        {
            get => _selectedSubmenu;
            set => SetProperty(ref _selectedSubmenu, value);
        }

        #endregion

        #region Public Interface

        public ReadOnlyObservableCollection<CharacterViewModel> PartyMembers { get; }
        public ReadOnlyObservableCollection<string> Submenus { get; }

        #endregion

        #region Private Interface

        private static IEnumerable<Character> GetCharacters()
        {
            var director = new Director();

            var builder = new NewCharacterBuilder();
            director.Configure(builder);
            yield return builder.Build();

            builder.For(CharacterTypes.Mallow);
            director.Configure(builder);
            yield return builder.Build();

            builder.For(CharacterTypes.Geno);
            director.Configure(builder);
            yield return builder.Build();
        }

        private static IEnumerable<string> GetSubmenus()
        {
            yield return "Item";
            yield return "Status";
            //yield return "Special";
            yield return "Equip";
            //yield return "Special Item";
            //yield return "Map";
        }

        #endregion
    }
}
