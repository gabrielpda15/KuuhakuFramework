using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KuuhakuFramework.AspNetCore.Models.Location
{
    [Table("LOC_City")]
    public class City : BaseEntity
    {
        [Required]
        [StringLength(120)]
        [DataType("varchar")]
        public string Name { get; set; }
        public virtual int RegionId { get; set; }
        public virtual int CountryId { get; set; }
    }
}
