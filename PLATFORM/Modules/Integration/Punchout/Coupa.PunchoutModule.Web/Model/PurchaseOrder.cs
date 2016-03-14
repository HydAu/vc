namespace Coupa.PunchoutModule.Web.Model.PurchaseOrder
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class cXML
    {

        private cXMLHeader headerField;

        private cXMLRequest requestField;

        private string langField;

        private string payloadIDField;

        private System.DateTime timestampField;

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
        public cXMLRequest Request
        {
            get
            {
                return this.requestField;
            }
            set
            {
                this.requestField = value;
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

        private uint identityField;

        private string domainField;

        /// <remarks/>
        public uint Identity
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

        private string userAgentField;

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
        public string UserAgent
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

        private string[] identityField;

        private string domainField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Identity")]
        public string[] Identity
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
    public partial class cXMLRequest
    {

        private cXMLRequestOrderRequest orderRequestField;

        private string deploymentModeField;

        /// <remarks/>
        public cXMLRequestOrderRequest OrderRequest
        {
            get
            {
                return this.orderRequestField;
            }
            set
            {
                this.orderRequestField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string deploymentMode
        {
            get
            {
                return this.deploymentModeField;
            }
            set
            {
                this.deploymentModeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLRequestOrderRequest
    {

        private cXMLRequestOrderRequestOrderRequestHeader orderRequestHeaderField;

        private cXMLRequestOrderRequestItemOut[] itemOutField;

        /// <remarks/>
        public cXMLRequestOrderRequestOrderRequestHeader OrderRequestHeader
        {
            get
            {
                return this.orderRequestHeaderField;
            }
            set
            {
                this.orderRequestHeaderField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemOut")]
        public cXMLRequestOrderRequestItemOut[] ItemOut
        {
            get
            {
                return this.itemOutField;
            }
            set
            {
                this.itemOutField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLRequestOrderRequestOrderRequestHeader
    {

        private cXMLRequestOrderRequestOrderRequestHeaderTotal totalField;

        private cXMLRequestOrderRequestOrderRequestHeaderShipTo shipToField;

        private cXMLRequestOrderRequestOrderRequestHeaderBillTo billToField;

        private cXMLRequestOrderRequestOrderRequestHeaderContact contactField;

        private cXMLRequestOrderRequestOrderRequestHeaderComments commentsField;

        private ushort orderIDField;

        private System.DateTime orderDateField;

        private string typeField;

        /// <remarks/>
        public cXMLRequestOrderRequestOrderRequestHeaderTotal Total
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
        public cXMLRequestOrderRequestOrderRequestHeaderShipTo ShipTo
        {
            get
            {
                return this.shipToField;
            }
            set
            {
                this.shipToField = value;
            }
        }

        /// <remarks/>
        public cXMLRequestOrderRequestOrderRequestHeaderBillTo BillTo
        {
            get
            {
                return this.billToField;
            }
            set
            {
                this.billToField = value;
            }
        }

        /// <remarks/>
        public cXMLRequestOrderRequestOrderRequestHeaderContact Contact
        {
            get
            {
                return this.contactField;
            }
            set
            {
                this.contactField = value;
            }
        }

        /// <remarks/>
        public cXMLRequestOrderRequestOrderRequestHeaderComments Comments
        {
            get
            {
                return this.commentsField;
            }
            set
            {
                this.commentsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort orderID
        {
            get
            {
                return this.orderIDField;
            }
            set
            {
                this.orderIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime orderDate
        {
            get
            {
                return this.orderDateField;
            }
            set
            {
                this.orderDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLRequestOrderRequestOrderRequestHeaderTotal
    {

        private cXMLRequestOrderRequestOrderRequestHeaderTotalMoney moneyField;

        /// <remarks/>
        public cXMLRequestOrderRequestOrderRequestHeaderTotalMoney Money
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
    public partial class cXMLRequestOrderRequestOrderRequestHeaderTotalMoney
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
    public partial class cXMLRequestOrderRequestOrderRequestHeaderShipTo
    {

        private cXMLRequestOrderRequestOrderRequestHeaderShipToAddress addressField;

        /// <remarks/>
        public cXMLRequestOrderRequestOrderRequestHeaderShipToAddress Address
        {
            get
            {
                return this.addressField;
            }
            set
            {
                this.addressField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLRequestOrderRequestOrderRequestHeaderShipToAddress
    {

        private cXMLRequestOrderRequestOrderRequestHeaderShipToAddressName nameField;

        private cXMLRequestOrderRequestOrderRequestHeaderShipToAddressPostalAddress postalAddressField;

        private cXMLRequestOrderRequestOrderRequestHeaderShipToAddressEmail emailField;

        private string isoCountryCodeField;

        private ushort addressIDField;

        /// <remarks/>
        public cXMLRequestOrderRequestOrderRequestHeaderShipToAddressName Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public cXMLRequestOrderRequestOrderRequestHeaderShipToAddressPostalAddress PostalAddress
        {
            get
            {
                return this.postalAddressField;
            }
            set
            {
                this.postalAddressField = value;
            }
        }

        /// <remarks/>
        public cXMLRequestOrderRequestOrderRequestHeaderShipToAddressEmail Email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string isoCountryCode
        {
            get
            {
                return this.isoCountryCodeField;
            }
            set
            {
                this.isoCountryCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort addressID
        {
            get
            {
                return this.addressIDField;
            }
            set
            {
                this.addressIDField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLRequestOrderRequestOrderRequestHeaderShipToAddressName
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
    public partial class cXMLRequestOrderRequestOrderRequestHeaderShipToAddressPostalAddress
    {

        private string deliverToField;

        private string streetField;

        private string cityField;

        private string stateField;

        private string postalCodeField;

        private cXMLRequestOrderRequestOrderRequestHeaderShipToAddressPostalAddressCountry countryField;

        private string nameField;

        /// <remarks/>
        public string DeliverTo
        {
            get
            {
                return this.deliverToField;
            }
            set
            {
                this.deliverToField = value;
            }
        }

        /// <remarks/>
        public string Street
        {
            get
            {
                return this.streetField;
            }
            set
            {
                this.streetField = value;
            }
        }

        /// <remarks/>
        public string City
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public string State
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }

        /// <remarks/>
        public string PostalCode
        {
            get
            {
                return this.postalCodeField;
            }
            set
            {
                this.postalCodeField = value;
            }
        }

        /// <remarks/>
        public cXMLRequestOrderRequestOrderRequestHeaderShipToAddressPostalAddressCountry Country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLRequestOrderRequestOrderRequestHeaderShipToAddressPostalAddressCountry
    {

        private string isoCountryCodeField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string isoCountryCode
        {
            get
            {
                return this.isoCountryCodeField;
            }
            set
            {
                this.isoCountryCodeField = value;
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
    public partial class cXMLRequestOrderRequestOrderRequestHeaderShipToAddressEmail
    {

        private string nameField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
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
    public partial class cXMLRequestOrderRequestOrderRequestHeaderBillTo
    {

        private cXMLRequestOrderRequestOrderRequestHeaderBillToAddress addressField;

        /// <remarks/>
        public cXMLRequestOrderRequestOrderRequestHeaderBillToAddress Address
        {
            get
            {
                return this.addressField;
            }
            set
            {
                this.addressField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLRequestOrderRequestOrderRequestHeaderBillToAddress
    {

        private cXMLRequestOrderRequestOrderRequestHeaderBillToAddressName nameField;

        private cXMLRequestOrderRequestOrderRequestHeaderBillToAddressPostalAddress postalAddressField;

        private string isoCountryCodeField;

        private byte addressIDField;

        /// <remarks/>
        public cXMLRequestOrderRequestOrderRequestHeaderBillToAddressName Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public cXMLRequestOrderRequestOrderRequestHeaderBillToAddressPostalAddress PostalAddress
        {
            get
            {
                return this.postalAddressField;
            }
            set
            {
                this.postalAddressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string isoCountryCode
        {
            get
            {
                return this.isoCountryCodeField;
            }
            set
            {
                this.isoCountryCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte addressID
        {
            get
            {
                return this.addressIDField;
            }
            set
            {
                this.addressIDField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLRequestOrderRequestOrderRequestHeaderBillToAddressName
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
    public partial class cXMLRequestOrderRequestOrderRequestHeaderBillToAddressPostalAddress
    {

        private string deliverToField;

        private string streetField;

        private string cityField;

        private string stateField;

        private string postalCodeField;

        private cXMLRequestOrderRequestOrderRequestHeaderBillToAddressPostalAddressCountry countryField;

        private string nameField;

        /// <remarks/>
        public string DeliverTo
        {
            get
            {
                return this.deliverToField;
            }
            set
            {
                this.deliverToField = value;
            }
        }

        /// <remarks/>
        public string Street
        {
            get
            {
                return this.streetField;
            }
            set
            {
                this.streetField = value;
            }
        }

        /// <remarks/>
        public string City
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public string State
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }

        /// <remarks/>
        public string PostalCode
        {
            get
            {
                return this.postalCodeField;
            }
            set
            {
                this.postalCodeField = value;
            }
        }

        /// <remarks/>
        public cXMLRequestOrderRequestOrderRequestHeaderBillToAddressPostalAddressCountry Country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLRequestOrderRequestOrderRequestHeaderBillToAddressPostalAddressCountry
    {

        private string isoCountryCodeField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string isoCountryCode
        {
            get
            {
                return this.isoCountryCodeField;
            }
            set
            {
                this.isoCountryCodeField = value;
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
    public partial class cXMLRequestOrderRequestOrderRequestHeaderContact
    {

        private cXMLRequestOrderRequestOrderRequestHeaderContactName nameField;

        private cXMLRequestOrderRequestOrderRequestHeaderContactEmail emailField;

        private string roleField;

        /// <remarks/>
        public cXMLRequestOrderRequestOrderRequestHeaderContactName Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public cXMLRequestOrderRequestOrderRequestHeaderContactEmail Email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string role
        {
            get
            {
                return this.roleField;
            }
            set
            {
                this.roleField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLRequestOrderRequestOrderRequestHeaderContactName
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
    public partial class cXMLRequestOrderRequestOrderRequestHeaderContactEmail
    {

        private string nameField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
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
    public partial class cXMLRequestOrderRequestOrderRequestHeaderComments
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
    public partial class cXMLRequestOrderRequestItemOut
    {

        private cXMLRequestOrderRequestItemOutItemID itemIDField;

        private cXMLRequestOrderRequestItemOutItemDetail itemDetailField;

        private cXMLRequestOrderRequestItemOutDistribution distributionField;

        private cXMLRequestOrderRequestItemOutComments commentsField;

        private byte quantityField;

        private byte lineNumberField;

        /// <remarks/>
        public cXMLRequestOrderRequestItemOutItemID ItemID
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
        public cXMLRequestOrderRequestItemOutItemDetail ItemDetail
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
        public cXMLRequestOrderRequestItemOutDistribution Distribution
        {
            get
            {
                return this.distributionField;
            }
            set
            {
                this.distributionField = value;
            }
        }

        /// <remarks/>
        public cXMLRequestOrderRequestItemOutComments Comments
        {
            get
            {
                return this.commentsField;
            }
            set
            {
                this.commentsField = value;
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

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte lineNumber
        {
            get
            {
                return this.lineNumberField;
            }
            set
            {
                this.lineNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLRequestOrderRequestItemOutItemID
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
    public partial class cXMLRequestOrderRequestItemOutItemDetail
    {

        private cXMLRequestOrderRequestItemOutItemDetailUnitPrice unitPriceField;

        private cXMLRequestOrderRequestItemOutItemDetailDescription descriptionField;

        private string unitOfMeasureField;

        private cXMLRequestOrderRequestItemOutItemDetailClassification classificationField;

        /// <remarks/>
        public cXMLRequestOrderRequestItemOutItemDetailUnitPrice UnitPrice
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
        public cXMLRequestOrderRequestItemOutItemDetailDescription Description
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
        public cXMLRequestOrderRequestItemOutItemDetailClassification Classification
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
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLRequestOrderRequestItemOutItemDetailUnitPrice
    {

        private cXMLRequestOrderRequestItemOutItemDetailUnitPriceMoney moneyField;

        /// <remarks/>
        public cXMLRequestOrderRequestItemOutItemDetailUnitPriceMoney Money
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
    public partial class cXMLRequestOrderRequestItemOutItemDetailUnitPriceMoney
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
    public partial class cXMLRequestOrderRequestItemOutItemDetailDescription
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
    public partial class cXMLRequestOrderRequestItemOutItemDetailClassification
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

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLRequestOrderRequestItemOutDistribution
    {

        private cXMLRequestOrderRequestItemOutDistributionAccounting accountingField;

        private cXMLRequestOrderRequestItemOutDistributionCharge chargeField;

        /// <remarks/>
        public cXMLRequestOrderRequestItemOutDistributionAccounting Accounting
        {
            get
            {
                return this.accountingField;
            }
            set
            {
                this.accountingField = value;
            }
        }

        /// <remarks/>
        public cXMLRequestOrderRequestItemOutDistributionCharge Charge
        {
            get
            {
                return this.chargeField;
            }
            set
            {
                this.chargeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLRequestOrderRequestItemOutDistributionAccounting
    {

        private cXMLRequestOrderRequestItemOutDistributionAccountingSegment[] segmentField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Segment")]
        public cXMLRequestOrderRequestItemOutDistributionAccountingSegment[] Segment
        {
            get
            {
                return this.segmentField;
            }
            set
            {
                this.segmentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLRequestOrderRequestItemOutDistributionAccountingSegment
    {

        private string idField;

        private string descriptionField;

        private string typeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLRequestOrderRequestItemOutDistributionCharge
    {

        private cXMLRequestOrderRequestItemOutDistributionChargeMoney moneyField;

        /// <remarks/>
        public cXMLRequestOrderRequestItemOutDistributionChargeMoney Money
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
    public partial class cXMLRequestOrderRequestItemOutDistributionChargeMoney
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
    public partial class cXMLRequestOrderRequestItemOutComments
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



}