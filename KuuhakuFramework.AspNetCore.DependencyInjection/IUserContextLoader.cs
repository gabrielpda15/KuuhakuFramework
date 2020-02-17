using KuuhakuFramework.AspNetCore.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace KuuhakuFramework.AspNetCore.DependencyInjection
{
    public interface IUserContextLoader
    {
        void Load(IUserContext userContext);
    }
}
