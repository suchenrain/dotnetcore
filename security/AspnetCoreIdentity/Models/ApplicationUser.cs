using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AspnetCoreIdentity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string SkypeAccount { get; set; }
        public string LinkedinProfileLink { get; set; }
        public string TwitterHandler { get; set; }
    }
}
