using System;

namespace MinhLam.Framework
{
    public interface IAppConfiguration
    {
        object GetConfigurationSetting(Type expectedType, string key);
    }
}
