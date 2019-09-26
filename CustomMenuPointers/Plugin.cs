using CustomMenuPointers.UI;
using IPA;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CustomMenuPointers
{
    public class Plugin : IBeatSaberPlugin
    {
        public const string AssemblyName = "CustomMenuPointers";
        public const string GameCore = "GameCore";
        public const string MenuCore = "MenuCore";
        public const string StandardGameplay = "StandardGameplay";

        public string Name => AssemblyName;
        public string Version => "0.1";

        private CustomMenuPointersUI customMenuPointersUI;

        public void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
        {
            if (nextScene.name == GameCore)
            {
                CustomMenuPointers.instance.ShowMenuPointers(false);
            }

            if (nextScene.name == MenuCore)
            {
                CustomMenuPointers.instance.ShowMenuPointers(true);
                if (this.customMenuPointersUI == null)
                {
                    this.customMenuPointersUI = new GameObject(nameof(CustomMenuPointersUI)).AddComponent<CustomMenuPointersUI>();
                    this.customMenuPointersUI.AddUIElements();
                }
            }
        }

        public void OnApplicationQuit()
        {
        }

        public void OnApplicationStart()
        {
            PersistentSingleton<CustomSabersMod>.TouchInstance();
            PersistentSingleton<ConfigOptions>.TouchInstance();
            PersistentSingleton<CustomMenuPointers>.TouchInstance();
        }

        public void OnFixedUpdate()
        {
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {
        }

        public void OnSceneUnloaded(Scene scene)
        {
        }

        public void OnUpdate()
        {
        }

    }
}
