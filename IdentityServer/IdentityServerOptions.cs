namespace IdentityServer
{

    /// <summary>
    /// Identity server options.
    /// </summary>
    public class IdentityServerOptions
    {

        /// <summary>
        /// Gets or sets the issuer URI.
        /// </summary>
        public string IssuerUri
        {
            get;

            set;
        }


        /// <summary>
        /// Checks whether the issuer URI is specified or not.
        /// </summary>
        public bool HasIssuerUri
        {
            get
            {
                return !string.IsNullOrEmpty(IssuerUri);
            }
        }

    }
    
}
