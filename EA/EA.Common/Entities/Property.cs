using EA.Common.Core;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace EA.Common.Entities
{
    [Table("Property")]
    [Description("To store Property information")]
    public class Property : BaseEntity
    {
        [Key]
        public int ID { get; set; }
        public string PropertyType { get; set; }
        public string PropertyName { get; set; }
    }
}