using System.Collections.Generic;
using VirtoCommerce.Platform.Core.Settings;

namespace Coupa.PunchoutModule.Web.Model
{
    public abstract class PunchoutGateway : IHaveSettings
    {
        public PunchoutGateway(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }
        public bool IsActive { get; set; }

        public abstract string PunchoutSetup(string request);

        /// <summary>
        /// Generate punchout order message from the cartId
        /// </summary>
        /// <param name="cartId">Cart Id</param>
        /// <returns>Serialized punchout order message</returns>
        public abstract string PunchoutOrderMessage(string quoteId);

        /// <summary>
        /// Create customer order from the provided serialized order data.
        /// </summary>
        /// <param name="customerOrderRequest">Serialized customer order object</param>
        /// <returns>Response</returns>
        public abstract string CreateOrder(string customerOrderRequest);

        #region IHaveSettings Members

        public ICollection<SettingEntry> Settings { get; set; }

        #endregion
    }
}
