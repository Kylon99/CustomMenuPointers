using System.Linq;
using UnityEngine;

namespace CustomMenuPointers
{
    public class CustomMenuPointers : PersistentSingleton<CustomMenuPointers>
    {
        private GameObject customSaberRoot;
        private GameObject leftSaber;
        private GameObject rightSaber;

        /// <summary>
        /// Shows the correct Menu Pointer as chosen by the options
        /// </summary>
        /// <param name="showMenuCore">Determines whether to replace in MenuCore or the 
        /// StandardGameplay scene when playing the game (for the pause menu)</param>
        public void ShowMenuPointers(bool showMenuCore = true)
        {
            switch (ConfigOptions.instance.UsePointerType)
            {
                case PointerType.Default:
                    // Use the in game default menu pointers and do not switch models
                    Logger.Info($"Using default menu pointers");
                    this.UseDefaultPointers();
                    return;

                case PointerType.Saber:
                    // Use the Custom Saber mod sabers
                    Logger.Info($"Using the selected custom saber as pointers");
                    this.ReplaceWithCustomSabersForScene(showMenuCore);
                    return;

                case PointerType.Custom:
                    // Use a custom menu pointer
                    // Do nothing for now as it's not implemented
                    Logger.Info($"Using a custom menu pointer");
                    return;
            }
        }

        /// <summary>
        /// This will try to undo any custom sabers or custom menu pointers and re-show the
        /// default menu pointers
        /// </summary>
        public void UseDefaultPointers()
        {
            this.UnloadEverything();

            Logger.Info("Using default menu pointers.");

            foreach (VRController controller in Resources.FindObjectsOfTypeAll<VRController>())
            {
                if (controller.name == "ControllerLeft")
                {
                    Logger.Info("Reverting Left Menu Pointer to default");
                    var menuHandle = controller.transform.Find("MenuHandle");
                    if (menuHandle != null)
                    {
                        menuHandle.gameObject.SetActive(true);
                    }
                }

                if (controller.name == "ControllerRight")
                {
                    Logger.Info("Reverting Right Menu Pointer to default");
                    var menuHandle = controller.transform.Find("MenuHandle");
                    if (menuHandle != null)
                    {
                        menuHandle.gameObject.SetActive(true);
                    }
                }
            }
        }

        /// <summary>
        /// This will replace the menu pointers with the currently selected custom sabers unless that
        /// mod is not loaded, or if the default sabers were selected.
        /// </summary>
        /// <param name="showMenuCore">Determines whether to replace in MenuCore or the 
        /// StandardGameplay scene when playing the game (for the pause menu)</param>
        public void ReplaceWithCustomSabersForScene(bool showMenuCore = true)
        {
            const string MenuCore = "MenuCore";
            const string StandardGameplay = "StandardGameplay";

            if (CustomSabersMod.instance.IsUsingDefaultSabers())
            {
                this.UseDefaultPointers();
                return;
            }

            this.UnloadEverything();

            Logger.Info($"Current Custom Saber: {CustomSabersMod.instance.CurrentSaberName}");

            // Get the sabers from the Custom Saber mod
            var loadedSaberRoot = CustomSabersMod.instance.GetCurrentDefaultSabers();
            if (loadedSaberRoot == null)
            {
                Logger.Error($"No _customsaber asset in the bundle from path: {CustomSabersMod.instance.CurrentSaberName}");
                return;
            }

            // Assign the sabers
            this.customSaberRoot = Instantiate(loadedSaberRoot);
            this.leftSaber = this.customSaberRoot.transform.Find("LeftSaber").gameObject;
            this.rightSaber = this.customSaberRoot.transform.Find("RightSaber").gameObject;

            this.leftSaber.SetActive(ConfigOptions.instance.ShowLeftCustomMenuPointer);
            this.rightSaber.SetActive(ConfigOptions.instance.ShowRightCustomMenuPointer);

            // Find all the VRControllers in all scenes
            var allControllers = Resources.FindObjectsOfTypeAll<VRController>();
            var leftControllers = allControllers.Where(c => c.name == "ControllerLeft").ToList();
            var rightControllers = allControllers.Where(c => c.name == "ControllerRight").ToList();

            // Choose which VRControllers to hook up to
            string sceneName = showMenuCore ? MenuCore : StandardGameplay;
            leftControllers.ForEach(c =>
            {
                if (c.gameObject.scene.name == sceneName)
                {
                    // Hook up saber
                    leftSaber.transform.parent = c.transform;
                    leftSaber.transform.position = c.transform.position;
                    leftSaber.transform.rotation = c.transform.rotation;

                    // Set the default menu pointer
                    var menuHandle = c.transform.Find("MenuHandle");
                    if (menuHandle != null)
                    {
                        menuHandle.gameObject.SetActive(!ConfigOptions.instance.ShowLeftCustomMenuPointer);
                    }
                }
            });

            rightControllers.ForEach(c =>
            {
                if (c.gameObject.scene.name == sceneName)
                {
                    // Hook up saber
                    rightSaber.transform.parent = c.transform;
                    rightSaber.transform.position = c.transform.position;
                    rightSaber.transform.rotation = c.transform.rotation;

                    // Set the default menu pointer
                    var menuHandle = c.transform.Find("MenuHandle");
                    if (menuHandle != null)
                    {
                        menuHandle.gameObject.SetActive(!ConfigOptions.instance.ShowRightCustomMenuPointer);
                    }
                }
            });
        }

        /// <summary>
        /// Unloads all current sabers and menu pointers
        /// </summary>
        private void UnloadEverything()
        {
            // Unload any possible Custom Menu Pointers
            // CustomMenuPointersAssetBundles.instance.UnloadCustomMenuPointersAssetBundles();

            // Stop using any Custom Sabers
            if (this.customSaberRoot != null)
            {
                Destroy(this.leftSaber);
                Destroy(this.rightSaber);
                Destroy(this.customSaberRoot);
            }
        }
    }
}
