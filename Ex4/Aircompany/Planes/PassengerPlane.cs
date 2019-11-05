using System;

namespace Aircompany.Planes
{
    public class PassengerPlane : Plane
    {
        public int PassengerPlaneCapacity;

        public PassengerPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, int passengersCapacity)
            :base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            PassengerPlaneCapacity = passengersCapacity;
        }

        public override bool Equals(object obj)
        {
            var plane = obj as PassengerPlane;
            return plane != null &&
                   base.Equals(obj) &&
                   PassengerPlaneCapacity == plane.PassengerPlaneCapacity;
        }

        public override int GetHashCode()
        {
            var hashCode = 751774561;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + PassengerPlaneCapacity.GetHashCode();
            return hashCode;
        }

        public int PassengersCapacityIs()
        {
            return PassengerPlaneCapacity;
        }

       
        public override string ToString()
        {
            return base.ToString().Replace("}",
                    ", passengersCapacity=" + PassengerPlaneCapacity +
                    '}');
        }       
        
    }
}
