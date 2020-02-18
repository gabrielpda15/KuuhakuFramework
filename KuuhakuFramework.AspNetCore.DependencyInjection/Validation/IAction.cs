using KuuhakuFramework.AspNetCore.Models;
using KuuhakuFramework.AspNetCore.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KuuhakuFramework.AspNetCore.DependencyInjection.Validation
{
    public interface IAction<TEntity> where TEntity : class, IEntity
    {
        TEntity Model { get; set; }


    }
}
