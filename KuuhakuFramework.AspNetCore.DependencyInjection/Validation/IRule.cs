using KuuhakuFramework.AspNetCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KuuhakuFramework.AspNetCore.DependencyInjection.Validation
{
    public interface IRule<TEntity> where TEntity : class, IEntity
    {
    }
}
