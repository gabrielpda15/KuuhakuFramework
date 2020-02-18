using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KuuhakuFramework.AspNetCore.Models
{
    public class BaseEntityDescription : BaseEntity
    {
        [DataType("varchar")]
        [Required(ErrorMessage = "Description is required")]
        [StringLength(255, ErrorMessage = "Description must have a maximum of 255 characters")]
        public string Description { get; set; }
    }
}
