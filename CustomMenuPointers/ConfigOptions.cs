using BS_Utils.Utilities;

namespace CustomMenuPointers
{
    public enum PointerType
    {
        Default,
        Saber,
        Custom
    }

    public class ConfigOptions : PersistentSingleton<ConfigOptions>
    {
        public const string optionName = "CustomMenuPointers";
        public const string usePointerTypeName = "UsePointerType";
        public const string showLeftOptionName = "ShowLeftCustomMenuPointer";
        public const string showRightOptionName = "ShowRightCustomMenuPointer";

        private Config config;
        private bool showLeftCustomMenuPointer;
        private bool showRightCustomMenuPointer;
        private PointerType usePointerType;

        public PointerType UsePointerType
        {
            get
            {
                // Prevent using custom sabers if the mod isn't loaded
                return usePointerType == PointerType.Custom && CustomSabersMod.instance.IsUsingDefaultSabers()
                    ? PointerType.Default
                    : usePointerType;
            }
            set
            {
                usePointerType = value;
                this.config.SetInt(optionName, usePointerTypeName, (int)value);
            }
        }

        public bool ShowLeftCustomMenuPointer
        {
            get => showLeftCustomMenuPointer;
            set
            {
                this.showLeftCustomMenuPointer = value;
                this.config.SetBool(optionName, showLeftOptionName, value);
            }
        }

        public bool ShowRightCustomMenuPointer
        {
            get => showRightCustomMenuPointer;
            set
            {
                showRightCustomMenuPointer = value;
                this.config.SetBool(optionName, showRightOptionName, value);
            }
        }

        private void Awake()
        {
            // Initialize configuration options
            this.config = new Config(optionName);
            this.UsePointerType = (PointerType)this.config.GetInt(optionName, usePointerTypeName);
            this.ShowLeftCustomMenuPointer = this.config.GetBool(optionName, showLeftOptionName, false, true);
            this.ShowRightCustomMenuPointer = this.config.GetBool(optionName, showRightOptionName, false, true);
        }
    }
}
