namespace CustomMenuPointers
{
    /// <summary>
    /// Holds the AssetBundles for all the custom menu pointers
    /// </summary>
    //public class CustomMenuPointersAssetBundles : PersistentSingleton<CustomMenuPointersAssetBundles>
    //{
    //    public readonly string customMenuPointerPath = Path.Combine(Application.dataPath, "../CustomMenuPointers/");
    //    public readonly string menuPointerExtension = "*.menupointer";

    //    private List<AssetBundle> customMenuPointerList;

    //    public void LoadCustomMenuPointersAssetBundles()
    //    {
    //        var menuPointerFileList = Directory.GetFiles(this.customMenuPointerPath, "*.menupointer", SearchOption.AllDirectories).ToList();
    //        customMenuPointerList = new List<AssetBundle>();
    //        foreach (string fileName in menuPointerFileList)
    //        {
    //            var assetBundle = AssetBundle.LoadFromFile(fileName);
    //            if (assetBundle != null)
    //            {
    //                customMenuPointerList.Add(assetBundle);
    //            }
    //        }
    //    }

    //    public void UnloadCustomMenuPointersAssetBundles()
    //    {
    //        if (this.customMenuPointerList == null) return;
    //        this.customMenuPointerList.ForEach(a => a.Unload(true));
    //    }
    //}
}
