using System;
using System.Collections.Generic;
using System.Text;

namespace AgencyVehicleManegmant
{
    [Serializable]
    public class Car : Vehicle
    {
        int engineCapacity;
        int numberOfDoors;

        public int EngineCapacityy
        {
            get
            {
                return this.engineCapacity;
            }
            set
            {
                this.engineCapacity = value;
            }
        }
        public int NumberOfDoors
        {
            get
            {
                return this.numberOfDoors;
            }
            set
            {
                this.numberOfDoors = value;
            }
        }
        public Car(string company, string model, int yearOfProduction, string licenseNumber, int engineCapcity, int doorsNumber)
            : base(company, model, yearOfProduction, licenseNumber)
        {
            EngineCapacityy = engineCapacity;
            NumberOfDoors = doorsNumber;
        }
        public Car()
        {

        }
        public override string ToString()
        {

            return string.Format("Car Type :" + "\n" + base.ToString() + "\nEngine Capacity: {0}\nDorrs Number is: {1}", this.engineCapacity, this.numberOfDoors);
        }
        public override string ForFile()
        {
            return string.Format("Car" + base.ForFile() + ":{0}:{1}", this.EngineCapacityy, this.NumberOfDoors);
        }
    }
}
