using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Sistema.Models
{
    public class AuthenticatedUserModel
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime ExpiresIn { get; set; }

        public ICollection<string> AccessGroups { get; set; }

        public AuthenticatedUserModel()
        {
            this.AccessGroups = (ICollection<string>)new List<string>();
        }

        public string ToJSON()
        {
            return new JavaScriptSerializer().Serialize((object)this);
        }

        public static AuthenticatedUserModel GetFromJSON(string jsonUser)
        {
            return new JavaScriptSerializer().Deserialize(jsonUser, typeof(AuthenticatedUserModel)) as AuthenticatedUserModel;
        }

    }
}
