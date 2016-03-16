using System.Collections.Generic;

namespace VirtoCommerce.SearchModule.Data.Providers.ElasticsearchNest
{
    public class NestDocument : Dictionary<string, object>
    {
        public object Id
        {
            get
            {
                if (ContainsKey("__key"))
                    return this["__key"];

                return null;
            }
            set
            {
                if (ContainsKey("__key"))
                    this["__key"] = value;
                else
                    Add("__key", value);
            }
        }
    }
}
