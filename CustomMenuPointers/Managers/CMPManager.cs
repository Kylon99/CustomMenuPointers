using System.Threading.Tasks;
using CustomMenuPointers.Configuration;
using SaberFactory;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace CustomMenuPointers.Managers
{
    internal class CMPManager : IInitializable
    {
        // Fields for injection
        
        private readonly MenuSaberProvider _menuSaberProvider;
        private readonly PlayerDataModel _playerDataModel;
        private readonly MenuPlayerController _menuPlayerController;
        private readonly PluginConfig _config;
        private ColorScheme _colorScheme;
        private GameObject _leftSaber;
        private GameObject _rightSaber;

        public CMPManager(
            MenuSaberProvider menuSaberProvider,
            PlayerDataModel playerDataModel,
            MenuPlayerController menuPlayerController,
            PluginConfig config)
        {
            _menuSaberProvider = menuSaberProvider;
            _playerDataModel = playerDataModel;
            _menuPlayerController = menuPlayerController;
            _config = config;
        }

        public async void Initialize()
        {
            _colorScheme = _playerDataModel.playerData.colorSchemesSettings.GetSelectedColorScheme();
            await ToggleCustomMenuPointers(_config.CmpEnabled);
        }

        public async Task ToggleCustomMenuPointers(bool toggle)
        {
            ToggleMeshFilters(!toggle);
            if (toggle) await CreateSaberColorScheme();
            else DestroySaber();
        }
        
        public async Task CreateSaberColorScheme()
        {
            _leftSaber = await _menuSaberProvider.CreateSaber(_menuPlayerController.leftController.transform, SaberType.SaberA, _colorScheme.saberAColor, true);
            _rightSaber = await _menuSaberProvider.CreateSaber(_menuPlayerController.rightController.transform, SaberType.SaberB, _colorScheme.saberBColor, true);
            DestroyCollider(_leftSaber);
            DestroyCollider(_rightSaber);
        }

        private void DestroyCollider(GameObject gameObject)
        {
            foreach (Collider collider in gameObject.GetComponentsInChildren<Collider>())
            {
                Object.Destroy(collider);
            }
        }

        private void DestroySaber()
        {
            if(_leftSaber == null || _rightSaber == null) return;
            Object.Destroy(_leftSaber);
            Object.Destroy(_rightSaber);
        }

        private void ToggleMeshFilters(bool toggle)
        {
            foreach (MeshFilter meshFilter in
                _menuPlayerController.leftController.GetComponentsInChildren<MeshFilter>())
            {
                meshFilter.gameObject.SetActive(toggle);
            }
            foreach (MeshFilter meshFilter in _menuPlayerController.rightController.GetComponentsInChildren<MeshFilter>())
            {
                meshFilter.gameObject.SetActive(toggle);
            }
        }

        public async void ReloadModel()
        {
            DestroySaber();
            await CreateSaberColorScheme();
        }
    }
}