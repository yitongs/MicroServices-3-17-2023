using Microsoft.AspNetCore.Identity;

namespace Authentication.APILayer.Data
{
    public class HrmUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
