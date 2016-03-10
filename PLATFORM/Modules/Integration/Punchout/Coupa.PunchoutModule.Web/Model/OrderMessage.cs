namespace Coupa.PunchoutModule.Web.Model.OrderMessage
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class cXML
    {

        private cXMLHeader headerField;

        private cXMLMessage messageField;

        private string payloadIDField;

        private string langField;

        private System.DateTime timestampField;

        private string versionField;

        /// <remarks/>
        public cXMLHeader Header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }

        /// <remarks/>
        public cXMLMessage Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string payloadID
        {
            get
            {
                return this.payloadIDField;
            }
            set
            {
                this.payloadIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime timestamp
        {
            get
            {
                return this.timestampField;
            }
            set
            {
                this.timestampField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLHeader
    {

        private cXMLHeaderFrom fromField;

        private cXMLHeaderTO toField;

        private cXMLHeaderSender senderField;

        /// <remarks/>
        public cXMLHeaderFrom From
        {
            get
            {
                return this.fromField;
            }
            set
            {
                this.fromField = value;
            }
        }

        /// <remarks/>
        public cXMLHeaderTO To
        {
            get
            {
                return this.toField;
            }
            set
            {
                this.toField = value;
            }
        }

        /// <remarks/>
        public cXMLHeaderSender Sender
        {
            get
            {
                return this.senderField;
            }
            set
            {
                this.senderField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLHeaderFrom
    {

        private cXMLHeaderFromCredential credentialField;

        /// <remarks/>
        public cXMLHeaderFromCredential Credential
        {
            get
            {
                return this.credentialField;
            }
            set
            {
                this.credentialField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLHeaderFromCredential
    {

        private object identityField;

        private string domainField;

        /// <remarks/>
        public object Identity
        {
            get
            {
                return this.identityField;
            }
            set
            {
                this.identityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string domain
        {
            get
            {
                return this.domainField;
            }
            set
            {
                this.domainField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLHeaderTO
    {

        private cXMLHeaderTOCredential credentialField;

        /// <remarks/>
        public cXMLHeaderTOCredential Credential
        {
            get
            {
                return this.credentialField;
            }
            set
            {
                this.credentialField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLHeaderTOCredential
    {

        private string identityField;

        private string domainField;

        /// <remarks/>
        public string Identity
        {
            get
            {
                return this.identityField;
            }
            set
            {
                this.identityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string domain
        {
            get
            {
                return this.domainField;
            }
            set
            {
                this.domainField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLHeaderSender
    {

        private cXMLHeaderSenderCredential credentialField;

        private object userAgentField;

        /// <remarks/>
        public cXMLHeaderSenderCredential Credential
        {
            get
            {
                return this.credentialField;
            }
            set
            {
                this.credentialField = value;
            }
        }

        /// <remarks/>
        public object UserAgent
        {
            get
            {
                return this.userAgentField;
            }
            set
            {
                this.userAgentField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLHeaderSenderCredential
    {

        private object identityField;

        private string domainField;

        /// <remarks/>
        public object Identity
        {
            get
            {
                return this.identityField;
            }
            set
            {
                this.identityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string domain
        {
            get
            {
                return this.domainField;
            }
            set
            {
                this.domainField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLMessage
    {

        private cXMLMessagePunchOutOrderMessage punchOutOrderMessageField;

        /// <remarks/>
        public cXMLMessagePunchOutOrderMessage PunchOutOrderMessage
        {
            get
            {
                return this.punchOutOrderMessageField;
            }
            set
            {
                this.punchOutOrderMessageField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLMessagePunchOutOrderMessage
    {

        private string buyerCookieField;

        private cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeader punchOutOrderMessageHeaderField;

        private cXMLMessagePunchOutOrderMessageItemIn[] itemInField;

        /// <remarks/>
        public string BuyerCookie
        {
            get
            {
                return this.buyerCookieField;
            }
            set
            {
                this.buyerCookieField = value;
            }
        }

        /// <remarks/>
        public cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeader PunchOutOrderMessageHeader
        {
            get
            {
                return this.punchOutOrderMessageHeaderField;
            }
            set
            {
                this.punchOutOrderMessageHeaderField = value;
            }
        }

        /// <remarks/>
        public cXMLMessagePunchOutOrderMessageItemIn[] ItemIn
        {
            get
            {
                return this.itemInField;
            }
            set
            {
                this.itemInField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeader
    {

        private cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTotal totalField;

        private cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderShipping shippingField;

        private cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTax taxField;

        private string operationAllowedField;

        /// <remarks/>
        public cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTotal Total
        {
            get
            {
                return this.totalField;
            }
            set
            {
                this.totalField = value;
            }
        }

        /// <remarks/>
        public cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderShipping Shipping
        {
            get
            {
                return this.shippingField;
            }
            set
            {
                this.shippingField = value;
            }
        }

        /// <remarks/>
        public cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTax Tax
        {
            get
            {
                return this.taxField;
            }
            set
            {
                this.taxField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string operationAllowed
        {
            get
            {
                return this.operationAllowedField;
            }
            set
            {
                this.operationAllowedField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTotal
    {

        private cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTotalMoney moneyField;

        /// <remarks/>
        public cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTotalMoney Money
        {
            get
            {
                return this.moneyField;
            }
            set
            {
                this.moneyField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTotalMoney
    {

        private string currencyField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string currency
        {
            get
            {
                return this.currencyField;
            }
            set
            {
                this.currencyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderShipping
    {

        private cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderShippingMoney moneyField;

        private cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderShippingDescription descriptionField;

        /// <remarks/>
        public cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderShippingMoney Money
        {
            get
            {
                return this.moneyField;
            }
            set
            {
                this.moneyField = value;
            }
        }

        /// <remarks/>
        public cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderShippingDescription Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderShippingMoney
    {

        private string currencyField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string currency
        {
            get
            {
                return this.currencyField;
            }
            set
            {
                this.currencyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderShippingDescription
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTax
    {

        private cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTaxMoney moneyField;

        private cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTaxDescription descriptionField;

        /// <remarks/>
        public cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTaxMoney Money
        {
            get
            {
                return this.moneyField;
            }
            set
            {
                this.moneyField = value;
            }
        }

        /// <remarks/>
        public cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTaxDescription Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTaxMoney
    {

        private string currencyField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string currency
        {
            get
            {
                return this.currencyField;
            }
            set
            {
                this.currencyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLMessagePunchOutOrderMessagePunchOutOrderMessageHeaderTaxDescription
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLMessagePunchOutOrderMessageItemIn
    {

        private cXMLMessagePunchOutOrderMessageItemInItemID itemIDField;

        private cXMLMessagePunchOutOrderMessageItemInItemDetail itemDetailField;

        private byte quantityField;

        /// <remarks/>
        public cXMLMessagePunchOutOrderMessageItemInItemID ItemID
        {
            get
            {
                return this.itemIDField;
            }
            set
            {
                this.itemIDField = value;
            }
        }

        /// <remarks/>
        public cXMLMessagePunchOutOrderMessageItemInItemDetail ItemDetail
        {
            get
            {
                return this.itemDetailField;
            }
            set
            {
                this.itemDetailField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte quantity
        {
            get
            {
                return this.quantityField;
            }
            set
            {
                this.quantityField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLMessagePunchOutOrderMessageItemInItemID
    {

        private string supplierPartIDField;

        private string supplierPartAuxiliaryIDField;

        /// <remarks/>
        public string SupplierPartID
        {
            get
            {
                return this.supplierPartIDField;
            }
            set
            {
                this.supplierPartIDField = value;
            }
        }

        /// <remarks/>
        public string SupplierPartAuxiliaryID
        {
            get
            {
                return this.supplierPartAuxiliaryIDField;
            }
            set
            {
                this.supplierPartAuxiliaryIDField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLMessagePunchOutOrderMessageItemInItemDetail
    {

        private cXMLMessagePunchOutOrderMessageItemInItemDetailUnitPrice unitPriceField;

        private cXMLMessagePunchOutOrderMessageItemInItemDetailDescription descriptionField;

        private string unitOfMeasureField;

        private cXMLMessagePunchOutOrderMessageItemInItemDetailClassification classificationField;

        private object manufacturerNameField;

        private byte leadTimeField;

        /// <remarks/>
        public cXMLMessagePunchOutOrderMessageItemInItemDetailUnitPrice UnitPrice
        {
            get
            {
                return this.unitPriceField;
            }
            set
            {
                this.unitPriceField = value;
            }
        }

        /// <remarks/>
        public cXMLMessagePunchOutOrderMessageItemInItemDetailDescription Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public string UnitOfMeasure
        {
            get
            {
                return this.unitOfMeasureField;
            }
            set
            {
                this.unitOfMeasureField = value;
            }
        }

        /// <remarks/>
        public cXMLMessagePunchOutOrderMessageItemInItemDetailClassification Classification
        {
            get
            {
                return this.classificationField;
            }
            set
            {
                this.classificationField = value;
            }
        }

        /// <remarks/>
        public object ManufacturerName
        {
            get
            {
                return this.manufacturerNameField;
            }
            set
            {
                this.manufacturerNameField = value;
            }
        }

        /// <remarks/>
        public byte LeadTime
        {
            get
            {
                return this.leadTimeField;
            }
            set
            {
                this.leadTimeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLMessagePunchOutOrderMessageItemInItemDetailUnitPrice
    {

        private cXMLMessagePunchOutOrderMessageItemInItemDetailUnitPriceMoney moneyField;

        /// <remarks/>
        public cXMLMessagePunchOutOrderMessageItemInItemDetailUnitPriceMoney Money
        {
            get
            {
                return this.moneyField;
            }
            set
            {
                this.moneyField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLMessagePunchOutOrderMessageItemInItemDetailUnitPriceMoney
    {

        private string currencyField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string currency
        {
            get
            {
                return this.currencyField;
            }
            set
            {
                this.currencyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLMessagePunchOutOrderMessageItemInItemDetailDescription
    {

        private string langField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLMessagePunchOutOrderMessageItemInItemDetailClassification
    {

        private string domainField;

        private uint valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string domain
        {
            get
            {
                return this.domainField;
            }
            set
            {
                this.domainField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public uint Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }


}