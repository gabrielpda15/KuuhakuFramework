using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KuuhakuFramework.AspNetCore.Models.Security
{
    public class Identity : IdentityUser<int>, IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Required]
        [DataType("varchar")]
        [StringLength(50)]
        public override string UserName { get; set; }

        [Required]
        [DataType("varchar")]
        [StringLength(80)]
        public override string Email { get; set; }

        [NotMapped]
        public string Password { get; set; }

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
