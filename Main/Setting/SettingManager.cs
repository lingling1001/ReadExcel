using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class SettingManager : Singleton<SettingManager>
    {
        private ISettingable _setting;
        public void SetSettingInfo(ISettingable setting)
        {
            _setting = setting;
        }
        public string GetConfig(string key)
        {
            return _setting.GetConfig(key);
        }
        public void SetConfig(string key, string value)
        {
            _setting.SetConfig(key, value);
        }

    }
}