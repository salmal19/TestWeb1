using System;
using System.Data;

namespace TestWeb1.Models.Services.Infrastructure
{
    public interface IDatabaseAccessor
    {
         DataSet Query(FormattableString query);
    }
}