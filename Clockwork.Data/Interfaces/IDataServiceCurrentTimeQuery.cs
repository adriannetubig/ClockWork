using Clockwork.Data.Entities;
using System.Collections.Generic;

namespace Clockwork.Data.Interfaces
{
    public interface IDataServiceCurrentTimeQuery
    {
        CurrentTimeQuery Read(CurrentTimeQuery currentTimeQuery);
        List<CurrentTimeQuery> Read();
    }
}
