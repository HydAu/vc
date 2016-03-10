using System.Collections.Generic;
using System.IO;
using VirtoCommerce.Domain.Cart.Model;
using VirtoCommerce.Platform.Core.Settings;

namespace VirtoCommerce.Domain.Punchout.Model
{
    public abstract class PunchoutGateway: IHaveSettings
    {
        public PunchoutGateway(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public abstract string PunchoutSetup(string request);
        public abstract string PunchoutOrder(string cartId);

        #region IHaveSettings Members

        public ICollection<SettingEntry> Settings { get; set; }

        #endregion
    }
}
