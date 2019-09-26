using IPA.Loader;
using System.Reflection;
using UnityEngine;

namespace CustomMenuPointers
{
    public class CustomSabersMod : PersistentSingleton<CustomSabersMod>
    {

        public bool IsLoaded { get; private set; }
        public string CurrentSaberName => CustomSaber.Plugin._currentSaberName;


        private void Awake()
        {
            this.IsLoaded = IsCustomSabersLoaded();
        }

        public bool IsUsingDefaultSabers()
        {
            return !IsLoaded ||
                CustomSaber.Plugin._currentSaberName == null ||
                CustomSaber.Plugin._currentSaberName == "Default Sabers";
        }

        public AssetBundle GetCurrentDefaultSaberAssetBundle()
        {
            if (!IsLoaded) return null;

            // Get the Custom Saber AssetBundle
            var assembly = Assembly.GetAssembly(typeof(CustomSaber.CustomTrail));
            var type = assembly.GetType("CustomSaber.SaberLoader");
            MethodInfo getSaberAssetBundle = type.GetMethod("GetSaberAssetBundle", BindingFlags.Static | BindingFlags.Public);
            object assetBundleObj = getSaberAssetBundle.Invoke(null, new[] { CustomSaber.Plugin._currentSaberName });
            return assetBundleObj as AssetBundle;
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
