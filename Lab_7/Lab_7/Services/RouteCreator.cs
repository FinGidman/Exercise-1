using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab7.Models;
using Lab7.Services;

namespace Lab7.Services
{
    class RouteCreator
    {
        public static Route WithAllProperties()
        {
            return new Route(TestDataReader.GetData("DepartureCity"), TestDataReader.GetData("ArrivalCity"));
        }

        public static Route ArrivalBystationName()
        {
            return new Route(TestDataReader.GetData("DepartureCity"), TestDataReader.GetData("ArrivalStation"));
        }

        public static Route ArrivalByPostcode()
        {
            return new Route(TestDataReader.GetData("DepartureCity"), TestDataReader.GetData("ArrivalStationPostcode"));
        }

        public static Station InputStationName()
        {
            return new Station(TestDataReader.GetData("StationName"));
        }
    }
}
