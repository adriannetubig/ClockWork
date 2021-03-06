﻿using System.Collections.Generic;
using Clockwork.Business.Models;

namespace Clockwork.Business.Interfaces
{
    public interface IBusinessServiceCurrentTimeQuery
    {
        CurrentTimeQuery Read(string clientIp, string offSet);
        List<CurrentTimeQuery> Read();
    }
}
