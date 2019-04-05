using Clockwork.Data.Entities;
using Clockwork.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clockwork.Data.Services
{
    public class DataServiceCurrentTimeQuery: IDataServiceCurrentTimeQuery
    {
        public CurrentTimeQuery Create(CurrentTimeQuery currentTimeQuery)
        {
            using (var context = new ClockworkContext())
            {
                context.CurrentTimeQueries.Add(currentTimeQuery);
                var count = context.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                foreach (var CurrentTimeQuery in context.CurrentTimeQueries)
                {
                    Console.WriteLine(" - {0}", CurrentTimeQuery.UTCTime);
                }
            }

            return currentTimeQuery;
        }
        
        public List<CurrentTimeQuery> Read()
        {
            var currentTimeQueries = new List<CurrentTimeQuery>();

            using (var context = new ClockworkContext())
            {
                currentTimeQueries = context.CurrentTimeQueries.ToList();
            }

            return currentTimeQueries;
        }
    }
}
