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
            return new Route(TestDataReader.GetData("ManchesterPIC"), TestDataReader.GetData("LondonBFR"));
        }

        public static Route ArrivalBystationName()
        {
            return new Route(TestDataReader.GetData("ManchetserPIC"), TestDataReader.GetData("BirminghamMS"));
        }

        public static Route ArrivalByPostcode()
        {
            return new Route(TestDataReader.GetData("LondonALL"), TestDataReader.GetData("ManchesterPostCode"));
        }

        public static Station InputStationName()
        {
            return new Station(TestDataReader.GetData("LondonPAD"));
        }
    }
}
