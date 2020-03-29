using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.ViewControllers;
using BS_Utils.Utilities;
using HMUI;
using static BeatSaberMarkupLanguage.Components.CustomListTableData;

namespace CustomMenuPointers.UI
{
    public class SelectionListViewController : BSMLResourceViewController
    {
        public override string ResourceName => Plugin.AssemblyName + ".UI.Views.SelectionListView.bsml";

        [UIComponent("selectionList")]
        public CustomListTableData customListTableData;

        protected override void DidActivate(bool firstActivation, ActivationType activationType)
        {
            base.DidActivate(firstActivation, activationType);

            if (firstActivation)
            {
                this.customListTableData.cellSize = 8.5f;

                // Create the Default Menu Pointer option
                var defaultPointersIcon = UIUtilities.LoadSpriteFromResources("CustomMenuPointers.Resources.DefaultPointers.png");
                var defaultMenuPointers = new CustomCellInfo(
                "Default",
                "Use the default menu pointers",
                defaultPointersIcon.texture);
                this.customListTableData.data.Add(defaultMenuPointers);

                // Create the Custom Saber option if available
                if (CustomSabersMod.instance.IsLoaded)
                {
                    var customSabersIcon = UIUtilities.LoadSpriteFromResources("CustomMenuPointers.Resources.CustomSaberIcon.png");
                    var currentCustomSaber = new CustomCellInfo(
                        "Custom Saber",
                        "Use the currently selected Custom Saber as Menu Pointers",
                        customSabersIcon.texture);
                    this.customListTableData.data.Add(currentCustomSaber);
                }
            }

            // Determine which cell to select
            if (ConfigOptions.instance.UsePointerType == PointerType.Default)
            {
                Logger.Info("Selected Default");
                this.customListTableData.tableView.ScrollToCellWithIdx(0, TableViewScroller.ScrollPositionType.Beginning, false);
                this.customListTableData.tableView.SelectCellWithIdx(0, false);
            }

            if (ConfigOptions.instance.UsePointerType == PointerType.Custom)
            {
                Logger.Info("Selected CustomSaber");
                this.customListTableData.tableView.ScrollToCellWithIdx(1, TableViewScroller.ScrollPositionType.Beginning, false);
                this.customListTableData.tableView.SelectCellWithIdx(1, false);
            }

            this.customListTableData.tableView.ReloadData();
        }

        [UIAction("selectionClick")]
        private void ClickedRow(TableView table, int row)
        {
            if (row == 0)
            {
                // Use Default Menu Pointers
                ConfigOptions.instance.UsePointerType = PointerType.Default;
            }

            if (row == 1)
            {
                // Use Custom Saber as Pointers
                ConfigOptions.instance.UsePointerType = PointerType.Saber;
            }

            CustomMenuPointers.instance.ShowMenuPointers();
        }
    }
}
