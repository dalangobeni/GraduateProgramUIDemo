using Abp.AspNetCore;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Backend
{
    [DependsOn(typeof(AbpAspNetCoreModule))]
    public class BackEndModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
