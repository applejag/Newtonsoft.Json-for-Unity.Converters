using System;

namespace Newtonsoft.Json.UnityConverters
{
    /// <summary>
    /// The attribute allows to hide JsonConverter from Json.Net converters settings
    /// and exclude it from auto sync process.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class HideInJsonConverterSettings : Attribute { }
}
