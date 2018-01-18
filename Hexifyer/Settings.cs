using System.Configuration;

namespace Hexifyer.Properties {
    internal sealed partial class Settings {        
        public Settings() { }

        [UserScopedSetting]
        [DefaultSettingValue("")]
        public string LastPath {
            get { return (string)this["LastPath"]; }
            set { this["LastPath"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("false")]
        public bool NoNewFile {
            get { return (bool)this["NoNewFile"]; }
            set { this["NoNewFile"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("false")]
        public bool LowerToUpper {
            get { return (bool)this["LowerToUpper"]; }
            set { this["LowerToUpper"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("false")]
        public bool CloseApp {
            get { return (bool)this["CloseApp"]; }
            set { this["CloseApp"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("false")]
        public bool Dehexify {
            get { return (bool)this["Dehexify"]; }
            set { this["Dehexify"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("1")]
        public int ByteAllign {
            get { return (int)this["ByteAllign"]; }
            set { this["ByteAllign"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("16")]
        public int HexAllign {
            get { return (int)this["HexAllign"]; }
            set { this["HexAllign"] = value; }
        }
    }
}
