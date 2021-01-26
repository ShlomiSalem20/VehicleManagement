using System;
using System.Collections.Generic;
using System.Text;

namespace AgencyVehicleManegmant
{
    [Serializable]
    public class Vehicle : IComparable
    {
        string company;
        string manufacture;
        int yearOfProduction;
        string licenseNumber;

        #region Proprties
        public string Company
        {
            get
            {
                return this.company;
            }
            set
            {
                this.company = value;
            }
        }

        public string Manufacture
        {
            get
            {
                return this.manufacture;
            }
            set
            {
                this.manufacture = value;
            }
        }

        public int YearOfProduction
        {
            get
            {
                return this.yearOfProduction;
            }
            set
            {
                this.yearOfProduction = value;
            }
        }

        public string LicensENuumber
        {
            get
            {
                return this.licenseNumber;
            }
            set
            {
                this.licenseNumber = value;
            }
        }
        #endregion

        public Vehicle(string company, string model, int yearOfProduction, string licenseNumber)
        {
            Company = company;
            Manufacture = model;
            YearOfProduction = yearOfProduction;
            this.licenseNumber = licenseNumber;

        }
        public Vehicle()
        {

        }
        public override string ToString()
        {
            string P = string.Format("Company: {0}\nModel: {1}\nYear of production: {2}\nLicense Number: {3}", this.company, this.manufacture, this.yearOfProduction, this.licenseNumber);
            return P;

        }
        public virtual string ForFile()
        {
            return string.Format(":{0}:{1}:{2}:{3}", this.Company, this.Manufacture, this.YearOfProduction, this.licenseNumber);
        }
        public int CompareTo(object obj)
        {
            Vehicle vehicle = (Vehicle)obj;
            if (YearOfProduction > vehicle.YearOfProduction)
            {
                return -1;
            }
            if (YearOfProduction < vehicle.YearOfProduction)
            {
                return 1;
            }
            return 0;
        }
    }
}
