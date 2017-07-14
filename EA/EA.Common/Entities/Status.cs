using EA.Common.Core;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EA.Common.Entities
{
    [Description("To store status")]
    [Table("Status")]
    public class Status : BaseEntity
    {
        [Key]
        public int ID { get; set; }

        public string Description { get; set; }
    }
}