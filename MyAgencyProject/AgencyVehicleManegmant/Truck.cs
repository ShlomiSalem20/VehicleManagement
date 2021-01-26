using System;
using System.Collections.Generic;
using System.Text;

namespace AgencyVehicleManegmant
{
    [Serializable]
    public class Truck : Vehicle
    {
        string weight;

        public string Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                this.weight = value;
            }
        }
        public Truck(string company, string model, int yearOfProduction, string licenseNumber, string weight)
            : base(company, model, yearOfProduction, licenseNumber)
        {
            Weight = weight;
        }
        public Truck()
        {

        }
        public override string ToString()
        {
            return string.Format("Truck Type :" + "\n" + base.ToString() + "\nWeight: {0}", this.Weight);
        }
        public override string ForFile()
        {
            return string.Format("Truck" + base.ForFile() + ":{0}", this.Weight);
        }
    }
}
