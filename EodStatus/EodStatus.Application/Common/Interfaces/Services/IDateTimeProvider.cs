using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EodStatus.Application.Common.Interfaces.Services
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}