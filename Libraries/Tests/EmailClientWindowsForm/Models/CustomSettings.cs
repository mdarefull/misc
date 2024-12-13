using MyEmailManager;
using System;

namespace EmailClientWindowsForm.Models
{
    public class CustomSettings : EmailSettings, ICloneable
    {
        private readonly string _settingsName;
        public CustomSettings(string settingsName)
        {
            _settingsName = settingsName;
        }

        public override string ToString()
        {
            return _settingsName;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}