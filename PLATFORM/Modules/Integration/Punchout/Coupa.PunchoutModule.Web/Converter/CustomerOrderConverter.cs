using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Domain.Commerce.Model;
using coreModel = VirtoCommerce.Domain.Order.Model;
using purchaseOrder = Coupa.PunchoutModule.Web.Model.PurchaseOrder;

namespace Coupa.PunchoutModule.Web.Converters
{
	public static class CustomerOrderConverter
	{
		public static coreModel.CustomerOrder ToCoreModel(this purchaseOrder.cXML purchaseOrder, string storeId, string catalogId)
		{
			var retVal = new coreModel.CustomerOrder();
			retVal.Number = purchaseOrder.Request.OrderRequest.OrderRequestHeader.orderID.ToString();
            retVal.CreatedDate = purchaseOrder.Request.OrderRequest.OrderRequestHeader.orderDate;
            retVal.Sum = purchaseOrder.Request.OrderRequest.OrderRequestHeader.Total.Money.Value;
            retVal.Currency = purchaseOrder.Request.OrderRequest.OrderRequestHeader.Total.Money.currency;
            retVal.CustomerId = purchaseOrder.Request.OrderRequest.OrderRequestHeader.Contact.Name.Value;
            retVal.StoreId = storeId;

            if (purchaseOrder.Request.OrderRequest.ItemOut != null)
				retVal.Items = purchaseOrder.Request.OrderRequest.ItemOut.Select(x => x.ToCoreModel(catalogId)).ToList();
            if (purchaseOrder.Request.OrderRequest.OrderRequestHeader.BillTo != null)
            {
                var billAddress = purchaseOrder.Request.OrderRequest.OrderRequestHeader.BillTo.Address.ToCoreModel();
                retVal.Addresses = new List<Address> { billAddress };
            }

            if (purchaseOrder.Request.OrderRequest.OrderRequestHeader.ShipTo != null)
            {
                var shipAddress = purchaseOrder.Request.OrderRequest.OrderRequestHeader.ShipTo.Address.ToCoreModel();
                if (retVal.Addresses == null)
                    retVal.Addresses = new List<Address> { shipAddress };
                else
                    retVal.Addresses.Add(shipAddress);
            }
            else
            {
                if (retVal.Addresses != null && retVal.Addresses.Any())
                    retVal.Addresses.First().AddressType = AddressType.BillingAndShipping;
            }

            return retVal;
		}


	}
}