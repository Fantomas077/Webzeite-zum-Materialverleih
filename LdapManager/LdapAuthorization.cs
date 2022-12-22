using System.DirectoryServices.Protocols;
using System.Net;

namespace BookingPlatform.LoginManager
{

   /* //Use this Class with this Code
      LdapAuthorization ldap = new LdapAuthorization("Login", "login-dc-01.login.htw-berlin.de");

      //Test mit deinem MatrNr und Passwort
      return ldap.ValidateByBind("MatrNr", "Password"); */

    public class LdapAuthorization
    {
        NetworkCredential? credential { get; set; }
        LdapConnection? connection { get; set; }

        private readonly LdapDirectoryIdentifier identifier;
        private readonly string domain;

        public LdapAuthorization(string domainPara, string url)
        {
            identifier = new LdapDirectoryIdentifier(url);
            this.domain = domainPara;
        }

        public bool ValidateByBind(string matNr, string password)
        {
            bool response = true;
            credential = new NetworkCredential(matNr, password, this.domain);
            this.connection = new LdapConnection(identifier, credential);
            try
            {
                connection.Bind();
            }
            catch (Exception)
            {
                response = false;
            }

            connection.Dispose();
            return response;
        }
    }
}
