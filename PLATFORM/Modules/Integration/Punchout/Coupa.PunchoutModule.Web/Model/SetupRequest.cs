namespace Coupa.PunchoutModule.Web.Model.SetupRequest
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class cXML
    {

        private cXMLHeader headerField;

        private cXMLRequest requestField;

        private string payloadIDField;

        private System.DateTime timestampField;

        private string langField;

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

        private string identityField;

        private string sharedSecretField;

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
        public string SharedSecret
        {
            get
            {
                return this.sharedSecretField;
            }
            set
            {
                this.sharedSecretField = value;
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

        private cXMLRequestPunchOutSetupRequest punchOutSetupRequestField;

        /// <remarks/>
        public cXMLRequestPunchOutSetupRequest PunchOutSetupRequest
        {
            get
            {
                return this.punchOutSetupRequestField;
            }
            set
            {
                this.punchOutSetupRequestField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLRequestPunchOutSetupRequest
    {

        private string buyerCookieField;

        private cXMLRequestPunchOutSetupRequestExtrinsic[] extrinsicField;

        private cXMLRequestPunchOutSetupRequestContact contactField;

        private cXMLRequestPunchOutSetupRequestBrowserFormPost browserFormPostField;

        private string operationField;

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
        [System.Xml.Serialization.XmlElementAttribute("Extrinsic")]
        public cXMLRequestPunchOutSetupRequestExtrinsic[] Extrinsic
        {
            get
            {
                return this.extrinsicField;
            }
            set
            {
                this.extrinsicField = value;
            }
        }

        /// <remarks/>
        public cXMLRequestPunchOutSetupRequestContact Contact
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
        public cXMLRequestPunchOutSetupRequestBrowserFormPost BrowserFormPost
        {
            get
            {
                return this.browserFormPostField;
            }
            set
            {
                this.browserFormPostField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string operation
        {
            get
            {
                return this.operationField;
            }
            set
            {
                this.operationField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class cXMLRequestPunchOutSetupRequestExtrinsic
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
    public partial class cXMLRequestPunchOutSetupRequestContact
    {

        private cXMLRequestPunchOutSetupRequestContactName nameField;

        private string emailField;

        private string roleField;

        /// <remarks/>
        public cXMLRequestPunchOutSetupRequestContactName Name
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
        public string Email
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
    public partial class cXMLRequestPunchOutSetupRequestContactName
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
    public partial class cXMLRequestPunchOutSetupRequestBrowserFormPost
    {

        private string uRLField;

        /// <remarks/>
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }
    }


}