using System.Threading.Tasks;
using SaberFactory;
using UnityEngine;
using Zenject;
using CustomMenuPointers.Configuration;
using Object = UnityEngine.Object;
using HarmonyLib;

namespace CustomMenuPointers.MenuPointers
{
    public class CMPManager : IInitializable
    {
        // Fields for injection
        
        private readonly MenuSaberProvider _menuSaberProvider;
        private readonly PlayerDataModel _playerDataModel;
        private readonly MenuPlayerController _menuPlayerController;
        private ColorScheme _colorScheme;
        private GameObject _leftSaber;
        private GameObject _rightSaber;

        public CMPManager(MenuSaberProvider menuSaberProvider, PlayerDataModel playerDataModel, MenuPlayerController menuPlayerController)
        {
            _menuSaberProvider = menuSaberProvider;
            _playerDataModel = playerDataModel;
            _menuPlayerController = menuPlayerController;
        }

        public async void Initialize()
        {
            _colorScheme = _playerDataModel.playerData.colorSchemesSettings.GetSelectedColorScheme();
            await ToggleCustomMenuPointers(PluginConfig.Instance.toggleCMP);
        }

        public async Task ToggleCustomMenuPointers(bool toggle)
        {
            ToggleMeshFilters(!toggle);
            if (toggle == true) await CreateSaberColorScheme();
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

        public async void reloadModel()
        {
            DestroySaber();
            await CreateSaberColorScheme();
        }
    }
}