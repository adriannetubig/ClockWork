using System.Collections.Generic;
using Clockwork.Business.Models;

namespace Clockwork.Business.Interfaces
{
    public interface IBusinessServiceCurrentTimeQuery
    {
        CurrentTimeQuery Create(string clientIp);
        List<CurrentTimeQuery> Read();
    }
}
