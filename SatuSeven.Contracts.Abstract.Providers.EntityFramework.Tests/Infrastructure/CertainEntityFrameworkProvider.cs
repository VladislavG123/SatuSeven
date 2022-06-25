using System;

namespace SatuSeven.Contracts.Abstract.Providers.EntityFramework.Tests.Infrastructure;

public class CertainEntityFrameworkProvider : EntityFrameworkProvider<TestApplicationContext, CertainEntity, Guid>
{
    public CertainEntityFrameworkProvider(TestApplicationContext context) : base(context)
    {
    }
}