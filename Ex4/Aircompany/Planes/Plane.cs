using System.Collections.Generic;

namespace Aircompany.Planes
{
    public abstract class Plane
    {
        public string planeModel { get; private set; }
        public int maxPlaneSpeed { get; private set; }
        public int maxFlightDistance { get; private set; }
        public int maxLoadCapacity { get; private set; }

        public Plane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity)
        {
            planeModel = model;
            maxPlaneSpeed = maxSpeed;
            this.maxFlightDistance = maxFlightDistance;
            this.maxLoadCapacity = maxLoadCapacity;
        }

        public override string ToString()
        {
            return "Plane{" +
                "model='" + planeModel + '\'' +
                ", maxSpeed=" + maxPlaneSpeed +
                ", maxFlightDistance=" + maxFlightDistance +
                ", maxLoadCapacity=" + maxLoadCapacity +
                '}';
        }

        public override bool Equals(object obj)
        {
            var plane = obj as Plane;
            return plane != null &&
                   planeModel == plane.planeModel &&
                   maxPlaneSpeed == plane.maxPlaneSpeed &&
                   maxFlightDistance == plane.maxFlightDistance &&
                   maxLoadCapacity == plane.maxLoadCapacity;
        }

        public override int GetHashCode()
        {
            var hashCode = -1043886837;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(planeModel);
            hashCode = hashCode * -1521134295 + maxPlaneSpeed.GetHashCode();
            hashCode = hashCode * -1521134295 + maxFlightDistance.GetHashCode();
            hashCode = hashCode * -1521134295 + maxLoadCapacity.GetHashCode();
            return hashCode;
        }        

    }
}
