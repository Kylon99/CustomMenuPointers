using System.Threading.Tasks;
using SaberFactory;
using UnityEngine;
using Zenject;

namespace CustomMenuPointers.MenuPointers
{
    public class CMPManager : IInitializable
    {
        private readonly MenuSaberProvider _menuSaberProvider;
        private readonly PlayerDataModel _playerDataModel;

        public CMPManager(MenuSaberProvider menuSaberProvider, PlayerDataModel playerDataModel)
        {
            _menuSaberProvider = menuSaberProvider;
            _playerDataModel = playerDataModel;
        }

        public async void Initialize()
        {
            // Create a red left saber
            _ = CreateSaberCustomColor(new Color(1,0,0), SaberType.SaberA);

            // Create a left saber with whatever your left user color is
            var secondSaber = await CreateSaberColorScheme(SaberType.SaberA);

            secondSaber.transform.position = new Vector3(-1, 0, 0);
        }

        /// <summary>
        /// Create the saber with a custom color
        /// </summary>
        public async Task<GameObject> CreateSaberCustomColor(Color color, SaberType saberType)
        {
            return await _menuSaberProvider.CreateSaber(parent: null, saberType: saberType, color: new Color(1, 0, 0), createTrail: true);
        }

        /// <summary>
        /// Create the saber with the color of the currently selected color scheme
        /// of the user
        /// </summary>
        public async Task<GameObject> CreateSaberColorScheme(SaberType saberType)
        {
            var colorScheme = _playerDataModel.playerData.colorSchemesSettings.GetSelectedColorScheme();
            var color = saberType == SaberType.SaberA ? colorScheme.saberAColor : colorScheme.saberBColor;

            return await _menuSaberProvider.CreateSaber(parent: null, saberType: saberType, color: color, createTrail: true);
        }
    }
}