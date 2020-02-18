using System;
using System.Collections.Generic;
using System.Text;

namespace KuuhakuFramework.AspNetCore.Models
{
    public interface IEntity
    {
        int Id { get; set; }
        string CreationUser { get; set; }
        string EditionUser { get; set; }
        DateTime? CreationDate { get; set; }
        DateTime? EditionDate { get; set; }
        string CreationIP { get; set; }
        string EditionIP { get; set; }
    }
}
