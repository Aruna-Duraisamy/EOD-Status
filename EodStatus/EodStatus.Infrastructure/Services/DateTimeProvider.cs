using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EodStatus.Application.Common.Interfaces.Services;

namespace EodStatus.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}