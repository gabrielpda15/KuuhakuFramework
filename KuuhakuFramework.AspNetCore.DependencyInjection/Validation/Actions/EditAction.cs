using KuuhakuFramework.AspNetCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KuuhakuFramework.AspNetCore.DependencyInjection.Validation.Actions
{
    public class EditAction<TEntity> : IAction<TEntity> where TEntity : class, IEntity
    {
    }
}
