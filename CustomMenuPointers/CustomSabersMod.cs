using CustomSaber.Settings;
using IPA.Loader;
using UnityEngine;

namespace CustomMenuPointers
{
    /// <summary>
    /// This class represents the interface to the Custom Saber MOD.  The MOD may not be available 
    /// in which case no methods will function properly and IsLoaded will report false.
    /// </summary>
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

        public GameObject GetCurrentDefaultSabers()
        {
            if (!IsLoaded) return null;

            // Return the sabers directly from the currently selected Custom Saber
            int index = CustomSaber.Utilities.SaberAssetLoader.SelectedSaber;
            var currentSaberData = CustomSaber.Utilities.SaberAssetLoader.CustomSabers[index];
            return currentSaberData.Sabers;
        }

        /// <summary>
        /// Checks whether the Custom Sabers mod is loaded or not.
        /// </summary>
        /// <remarks>
        /// This only needs to be called once on start as mods are not currently dynamically
        /// loaded or unloaded
        /// </remarks>
        /// <returns>True if the CustomSabers mod is loaded.  False otherwise</returns>
        private bool IsCustomSabersLoaded()
        {
            var pluginInfo = PluginManager.GetPlugin("Custom Sabers");
            if (pluginInfo == null) return false;

            return PluginManager.IsEnabled(pluginInfo);
        }
    }
}
