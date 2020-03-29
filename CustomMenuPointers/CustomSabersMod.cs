using CustomSaber.Settings;
using IPA.Loader;
using UnityEngine;

namespace CustomMenuPointers
{
    public class CustomSabersMod : PersistentSingleton<CustomSabersMod>
    {

        public bool IsLoaded { get; private set; }
        public string CurrentSaberName => Configuration.CurrentlySelectedSaber;


        private void Awake()
        {
            this.IsLoaded = IsCustomSabersLoaded();
        }

        public bool IsUsingDefaultSabers()
        {
            return !IsLoaded ||
                this.CurrentSaberName == null ||
                this.CurrentSaberName == "Default Sabers";
        }

        public AssetBundle GetCurrentDefaultSaberAssetBundle()
        {
            if (!IsLoaded) return null;

            // Get the Custom Saber AssetBundle
            int index = CustomSaber.Utilities.SaberAssetLoader.SelectedSaber;
            var currentSaberData = CustomSaber.Utilities.SaberAssetLoader.CustomSabers[index];
            return currentSaberData.AssetBundle;
        }

        /// <summary>
        /// Checks whether the Custom Sabers mod is loaded or not.
        /// </summary>
        /// <remarks>
        /// This only needs to be called once on start as mods are not currently dynamically
        /// loaded or unloaded</remarks>
        /// <returns>True if the CustomSabers mod is loaded.  False otherwise</returns>
        private bool IsCustomSabersLoaded()
        {
            var stackTrace = new System.Diagnostics.StackTrace();

            var pluginInfo = PluginManager.GetPlugin("Custom Sabers");
            if (pluginInfo == null) return false;

            if (pluginInfo.Metadata != null) return PluginManager.IsEnabled(pluginInfo.Metadata);

            return false;
        }
    }
}
