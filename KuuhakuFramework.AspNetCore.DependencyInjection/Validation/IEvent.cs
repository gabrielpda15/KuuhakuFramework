using KuuhakuFramework.AspNetCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KuuhakuFramework.AspNetCore.DependencyInjection.Validation
{
    public interface IEvent<TAction, TEntity> 
        where TAction : class, IAction<TEntity>
        where TEntity : class, IEntity
    {
    }
}
