using System;
using System.Collections.Generic;
using System.Text;

namespace AgencyVehicleManegmant
{
    [Serializable]
    public class Motorcycle : Vehicle
    {
        int enginePower;


        public int EnginePower
        {
            get
            {
                return this.enginePower;
            }
            set
            {
                this.enginePower = value;
            }
        }
        public Motorcycle(string company, string model, int yearOfProduction, string licenseNumber, int enginePower)
            : base(company, model, yearOfProduction, licenseNumber)
        {
            EnginePower = enginePower;
        }
        public Motorcycle()
        {

        }
        public override string ToString()
        {
            return string.Format("Motorcycle Type :" + "\n" + base.ToString() + "\nEngine Capacity: {0}", this.EnginePower);
        }
        public override string ForFile()
        {
            return string.Format("Motorcycle" + base.ForFile() + ":{0}", this.EnginePower);
        }
    }
}
