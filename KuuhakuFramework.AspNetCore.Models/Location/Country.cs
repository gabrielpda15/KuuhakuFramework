using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KuuhakuFramework.AspNetCore.Models.Location
{
    [Table("LOC_Country")]
    public class Country : BaseEntity
    {
        [Required]
        [StringLength(120)]
        [DataType("varchar")]
        public string Name { get; set; }

        [Required]
        [StringLength(2)]
        [DataType("varchar")]
        public string Code { get; set; }

        public virtual IList<Region> Regions { get; set; }
    }
}
