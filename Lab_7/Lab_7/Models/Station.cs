using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.Models
{
    class Station
    {
        public string StationName { get; set; }

        public Station(string stationname)
        {
            StationName = stationname;
        }
    }
}
