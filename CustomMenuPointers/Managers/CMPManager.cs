using System;
using System.Threading.Tasks;
using CustomMenuPointers.Configuration;
using SaberFactory;
using SaberFactory.Instances;
using SiraUtil.Tools.FPFC;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace CustomMenuPointers.Managers
{
    internal class CMPManager : IInitializable, IDisposable
    {
        // Fields for injection
        
        private readonly MenuSaberProvider _menuSaberProvider;
        private readonly PlayerDataModel _playerDataModel;
        private readonly MenuPlayerController _menuPlayerController;
        private readonly PluginConfig _config;
        private ColorScheme _colorScheme;
        private SaberInstance _leftSaber;
        private SaberInstance _rightSaber;
        private readonly IFPFCSettings _fpfc;

        public CMPManager(
            MenuSaberProvider menuSaberProvider,
            PlayerDataModel playerDataModel,
            MenuPlayerController menuPlayerController,
            PluginConfig config, IFPFCSettings fpfc)
        {
            _menuSaberProvider = menuSaberProvider;
            _playerDataModel = playerDataModel;
            _menuPlayerController = menuPlayerController;
            _config = config;
            _fpfc = fpfc;
        }

        public async void Initialize()
        {
            _menuSaberProvider.OnSaberVisibilityRequested += OnSaberVisibilityRequested;
            _colorScheme = _playerDataModel.playerData.colorSchemesSettings.GetSelectedColorScheme();
            await ToggleCustomMenuPointers(_config.CmpEnabled);
        }

        public async Task ToggleCustomMenuPointers(bool toggle)
        {
            ToggleHandles(!toggle);
            if (toggle) await CreateSaberColorScheme();
            else DestroySaber();
        }
        
        public void DestroyMeshOnly(bool visible)
        {
            ToggleHandle(_menuPlayerController.leftController, !visible);
            ToggleHandle(_menuPlayerController.rightController, !visible);
        }
        
        public async Task CreateSaberColorScheme()
        {
            if (_leftSaber != null && _rightSaber != null) return;
            if (_fpfc.Enabled) return;
            {
                _leftSaber = await _menuSaberProvider.CreateSaber(_menuPlayerController.leftController.transform, SaberType.SaberA, _colorScheme.saberAColor, true);
                _rightSaber = await _menuSaberProvider.CreateSaber(_menuPlayerController.rightController.transform, SaberType.SaberB, _colorScheme.saberBColor, true);
                DestroyCollider(_leftSaber.GameObject);
                DestroyCollider(_rightSaber.GameObject);
            }
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
            if (_leftSaber == null || _rightSaber == null) return;
                _leftSaber.Destroy();
                _rightSaber.Destroy();
                _leftSaber = null;
                _rightSaber = null;
        }

        private void ToggleHandles(bool visible)
        {
            ToggleHandle(_menuPlayerController.leftController, visible);
            ToggleHandle(_menuPlayerController.rightController, visible);
        }

        private void ToggleHandle(VRController controller, bool visible)
        {
            var handle = controller.transform.Find("MenuHandle");
            if (handle == null) return;
                handle.gameObject.SetActive(visible);
        }

        public async void ReloadModel()
        {
            if (!_config.CmpEnabled) return;
                DestroySaber();
            await CreateSaberColorScheme();
        }

        private void OnSaberVisibilityRequested(bool visible)
        {
            if (_leftSaber == null && _rightSaber == null) return;
            _leftSaber?.GameObject.SetActive(visible);
            _rightSaber?.GameObject.SetActive(visible);
            ToggleHandles(!visible);
        }

        public void Dispose()
        {
            _menuSaberProvider.OnSaberVisibilityRequested -= OnSaberVisibilityRequested;
        }
    }
}