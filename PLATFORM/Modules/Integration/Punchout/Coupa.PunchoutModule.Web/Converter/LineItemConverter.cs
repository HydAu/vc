using purchaseOrder = Coupa.PunchoutModule.Web.Model.PurchaseOrder;
using coreModel = VirtoCommerce.Domain.Order.Model;

namespace Coupa.PunchoutModule.Web.Converters
{
	public static class CustomerOrderItemConverter
	{
		public static coreModel.LineItem ToCoreModel(this purchaseOrder.cXMLRequestOrderRequestItemOut orderItem, string catalogId)
		{
			var retVal = new coreModel.LineItem();
            retVal.Quantity = orderItem.quantity;
            retVal.Name = orderItem.ItemDetail.Description.Value;
            retVal.ProductId = orderItem.ItemID.SupplierPartID;
            retVal.Sku = orderItem.ItemID.SupplierPartID;
			retVal.Currency = orderItem.ItemDetail.UnitPrice.Money.currency;
            retVal.Price = orderItem.ItemDetail.UnitPrice.Money.Value;
            retVal.CatalogId = catalogId;
			return retVal;
		}


	}
}
