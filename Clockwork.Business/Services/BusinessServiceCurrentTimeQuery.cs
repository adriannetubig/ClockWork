using System;
using System.Collections.Generic;
using AutoMapper;
using Clockwork.Business.Interfaces;
using Clockwork.Business.Models;
using Clockwork.Data.Interfaces;

namespace Clockwork.Business.Services
{
    public class BusinessServiceCurrentTimeQuery: IBusinessServiceCurrentTimeQuery
    {
        private readonly IDataServiceCurrentTimeQuery _iDataServiceCurrentTimeQuery;
        private readonly IMapper _mapper;
        public BusinessServiceCurrentTimeQuery(IDataServiceCurrentTimeQuery iDataServiceCurrentTimeQuery, IMapper mapper)
        {
            _iDataServiceCurrentTimeQuery = iDataServiceCurrentTimeQuery;
            _mapper = mapper;
        }

        public CurrentTimeQuery Read(string clientIp, string offSet)
        {

            var currentTimeQuery = new CurrentTimeQuery
            {
                ClientIp = clientIp
            };

            TimeSpan convertedOffSet;
            if (TimeSpan.TryParse(offSet, out convertedOffSet))
                currentTimeQuery.Offset = convertedOffSet;

            var currentTimeQueryEntity = _mapper.Map<Data.Entities.CurrentTimeQuery>(currentTimeQuery);
            currentTimeQueryEntity = _iDataServiceCurrentTimeQuery.Read(currentTimeQueryEntity);

            return _mapper.Map<CurrentTimeQuery>(currentTimeQueryEntity);
        }

        public List<CurrentTimeQuery> Read()
        {
            var currentTimeQueries = _iDataServiceCurrentTimeQuery.Read();

            return _mapper.Map<List<CurrentTimeQuery>>(currentTimeQueries);
        }
    }
}
