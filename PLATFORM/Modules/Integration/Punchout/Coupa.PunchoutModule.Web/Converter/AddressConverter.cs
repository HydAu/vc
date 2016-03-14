using VirtoCommerce.Domain.Commerce.Model;
using purchaseOrder = Coupa.PunchoutModule.Web.Model.PurchaseOrder;

namespace Coupa.PunchoutModule.Web.Converters
{
    public static class AddressConverter
	{
		public static Address ToCoreModel(this purchaseOrder.cXMLRequestOrderRequestOrderRequestHeaderBillToAddress address)
		{
            var retVal = new Address();

            retVal.FirstName = address.PostalAddress.name;
            retVal.LastName = address.PostalAddress.DeliverTo;
            retVal.Line1 = address.PostalAddress.Street;
            retVal.CountryCode = address.isoCountryCode;
            retVal.CountryName = address.PostalAddress.Country.Value;
            retVal.City = address.PostalAddress.City;
            retVal.PostalCode = address.PostalAddress.PostalCode;
            retVal.AddressType = AddressType.Billing;

            return retVal;
        }

        public static Address ToCoreModel(this purchaseOrder.cXMLRequestOrderRequestOrderRequestHeaderShipToAddress address)
        {
            var retVal = new Address();

            retVal.FirstName = address.PostalAddress.name;
            retVal.LastName = address.PostalAddress.DeliverTo;
            retVal.Line1 = address.PostalAddress.Street;
            retVal.CountryCode = address.isoCountryCode;
            retVal.CountryName = address.PostalAddress.Country.Value;
            retVal.City = address.PostalAddress.City;
            retVal.PostalCode = address.PostalAddress.PostalCode;
            retVal.AddressType = AddressType.Shipping;
            retVal.Email = address.Email.Value;
            
            return retVal;
        }
    }
}