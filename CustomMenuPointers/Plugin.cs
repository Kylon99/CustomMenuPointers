using BS_Utils.Utilities;
using CustomMenuPointers.UI;
using IPA;
using UnityEngine;

namespace CustomMenuPointers
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        public const string AssemblyName = "CustomMenuPointers";
        private CustomMenuPointersUI customMenuPointersUI;

        [OnStart]
        public void OnStart()
        {
            PersistentSingleton<CustomSabersMod>.TouchInstance();
            PersistentSingleton<ConfigOptions>.TouchInstance();
            PersistentSingleton<CustomMenuPointers>.TouchInstance();

            if (this.customMenuPointersUI == null) this.customMenuPointersUI = new GameObject(nameof(CustomMenuPointersUI)).AddComponent<CustomMenuPointersUI>();

            BSEvents.menuSceneLoadedFresh += this.OnMenuSceneLoadedFresh;
            BSEvents.menuSceneLoaded += this.OnMenuSceneLoaded;
            BSEvents.gameSceneLoaded += this.OnGameSceneLoaded;
        }

        private void OnMenuSceneLoadedFresh()
        {
            CustomMenuPointers.instance.ShowMenuPointers();
        }

        private void OnMenuSceneLoaded()
        {
            CustomMenuPointers.instance.ShowMenuPointers();
        }

        private void OnGameSceneLoaded()
        {
            CustomMenuPointers.instance.ShowMenuPointers(false);
        }
    }
}
