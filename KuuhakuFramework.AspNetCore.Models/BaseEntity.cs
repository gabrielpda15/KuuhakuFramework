using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KuuhakuFramework.AspNetCore.Models
{
    public class BaseEntity : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType("varchar")]
        [StringLength(50)]
        [ScaffoldColumn(false)]
        public string CreationUser { get; set; }

        [DataType("varchar")]
        [StringLength(50)]
        [ScaffoldColumn(false)]
        public string EditionUser { get; set; }

        [DataType("varchar")]
        [StringLength(50)]
        [ScaffoldColumn(false)]
        public string CreationIP { get; set; }

        [DataType("varchar")]
        [StringLength(50)]
        [ScaffoldColumn(false)]
        public string EditionIP { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? CreationDate { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? EditionDate { get; set; }
    }
}
