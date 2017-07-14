using EA.Common.Core;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EA.Common.Entities
{
    [Description("To store Employee information")]
    [Table("Employee")]
    public class Employee : BaseEntity
    {
        [Key]
        public long ID { get; set; }

        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string PhoneNo { get; set; }

        [MaxLength(50)]
        public string MobileNo { get; set; }
    }
}