using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EA.Common.Core
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.CreatedOn = DateTime.Now;
            this.UpdateOn = DateTime.Now;
            this.State = (int)EntityState.New;
        }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateOn { get; set; }

        [NotMapped]
        public int State { get; set; }

        public enum EntityState
        {
            New = 1,
            Update = 2,
            Delete = 3,
            Ignore = 4
        }
    }
}