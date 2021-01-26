using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace AgencyVehicleManegmant
{
    public class SortByCompany : IComparer<Vehicle>
    {
        public int Compare(Vehicle x, Vehicle y)
        {
            return x.Company.CompareTo(y.Company);
        }
    }
    public class VehicleManegmant
    {
        Vehicle vehicleTemp = new Vehicle();
        Car car = new Car();
        Truck truck = new Truck();
        Motorcycle motorcycle = new Motorcycle();
        static List<Vehicle> vehicleList = new List<Vehicle>();
        SortByCompany sort = new SortByCompany();
        static string filePath = "ArrayCars.txt";
        static string filePathStreamClass = "ArrayCarsStreamClass.txt";

        //CRUD
        //add and remove
        public void AddCars(Car car)
        {
            vehicleList.Add(car);
        }
        public void AddTruck(Truck truck)
        {
            vehicleList.Add(truck);
        }
        public void AddMotorcycle(Motorcycle motorcycle)
        {
            vehicleList.Add(motorcycle);
        }
        public void RemovVehicl(string inputUser)
        {
            for (int i = 0; i < vehicleList.Count; i++)
            {
                if (vehicleList[i].LicensENuumber == inputUser)
                {
                    vehicleList.Remove(vehicleList[i]);
                }
            }
        }

        //Writer and read form file

        public void WritToFile()
        {
            StreamWriter writer = new StreamWriter(filePathStreamClass);
            for (int i = 0; i < vehicleList.Count; i++)
            {
                writer.WriteLine(vehicleList[i].ForFile());
            }
            writer.Close();
        }
        public void ReadFromFile()
        {
            StreamReader reader = new StreamReader(filePathStreamClass);
            string str;
            string[] temp;
            while ((str = reader.ReadLine()) != null)
            {
                temp = str.Split(':');
                if (temp[0] == "Car")
                {
                    Car car = new Car();
                    car.Company = temp[1];
                    car.Manufacture = temp[2];
                    car.YearOfProduction = int.Parse(temp[3]);
                    car.LicensENuumber = temp[4];
                    car.EngineCapacityy = int.Parse(temp[5]);
                    car.NumberOfDoors = int.Parse(temp[6]);
                    vehicleList.Add(car);
                }
                if (temp[0] == "Truck")
                {
                    Truck truck = new Truck();
                    truck.Company = temp[1];
                    truck.Manufacture = temp[2];
                    truck.YearOfProduction = int.Parse(temp[3]);
                    truck.LicensENuumber = temp[4];
                    truck.Weight = temp[5];
                    vehicleList.Add(truck);
                }
                if (temp[0] == "Motorcycle")
                {
                    Motorcycle motorcycle = new Motorcycle();
                    motorcycle.Company = temp[1];
                    motorcycle.Manufacture = temp[2];
                    motorcycle.YearOfProduction = int.Parse(temp[3]);
                    motorcycle.LicensENuumber = temp[4];
                    motorcycle.EnginePower = int.Parse(temp[5]);
                    vehicleList.Add(motorcycle);
                }
            }
            reader.Close();
        }
        public void BinarySerialization()
        {
            FileStream file = null;
            if (File.Exists(filePath))
            {
                try
                {
                    file = File.Open(filePath, FileMode.Open, FileAccess.Write);
                    BinaryFormatter binary = new BinaryFormatter();
                    binary.Serialize(file, vehicleList);
                }
                catch (SerializationException e)
                {
                    string.Format(e.Message);
                }
                catch (Exception e)
                {

                    string.Format(e.Message);
                }
                finally
                {
                    file.Close();
                }

            }
            else
            {
                file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                BinaryFormatter binary = new BinaryFormatter();
                binary.Serialize(file, vehicleList);
            }

        }
        public void BianryDeserialize()
        {
            FileStream file = null;
            BinaryFormatter binary = new BinaryFormatter();
            if (File.Exists(filePath))
            {
                try
                {
                    file = File.Open(filePath, FileMode.Open, FileAccess.Read);
                    vehicleList = (List<Vehicle>)binary.Deserialize(file);
                }
                catch (SerializationException e)
                {
                    string.Format(e.Message);
                }
                catch (Exception e)
                {
                    string.Format(e.Message);
                }
                finally
                {
                    file.Close();
                }

            }
            else
            {
                string.Format("File does not exist");
            }

        }
        public void WritToFileUseChoise(string paht)
        {
            StreamWriter stream = new StreamWriter(paht);
            for (int i = 0; i < vehicleList.Count; i++)
            {
                stream.WriteLine(vehicleList[i].ForFile());
            }
            stream.Close();
        }
        public void BinarySerializtionUserChoise(string pahtBinary)
        {
            FileStream file = null;
            if (File.Exists(pahtBinary))
            {
                try
                {
                    file = File.Open(pahtBinary, FileMode.Open, FileAccess.Write);
                    BinaryFormatter binary = new BinaryFormatter();
                    binary.Serialize(file, vehicleList);
                }
                catch (SerializationException e)
                {
                    string.Format(e.Message);
                }
                catch (Exception e)
                {

                    string.Format(e.Message);
                }
                finally
                {
                    file.Close();
                }

            }
            else
            {
                file = new FileStream(pahtBinary, FileMode.Create, FileAccess.Write);
                BinaryFormatter binary = new BinaryFormatter();
                binary.Serialize(file, vehicleList);
            }

        }

        //show data on scren

        public List<Vehicle> PrintVehicle()
        {
            return vehicleList;
        }

        //saerching and more options

        public void FindVehicleWithWorrnty()
        {
            for (int i = 0; i < vehicleList.Count; i++)
            {
                Vehicle vehicleTemp = vehicleList[i] as Vehicle;
                bool worrnty = IsUnderWorrnty(vehicleTemp.YearOfProduction);
                if (worrnty == true)
                {
                    Console.WriteLine(vehicleTemp.ToString());
                }
            }
        }
        public List<Vehicle> SaerchingByCompany(string inpotUser)
        {
            List<Vehicle> FindVehicle = vehicleList.FindAll(vehicle => vehicle.Company == inpotUser);
            return FindVehicle;
        }
        public List<Vehicle> SaerchingByBrand(string inpotUser)
        {
            List<Vehicle> FindVehicle = vehicleList.FindAll(vehicle => vehicle.Manufacture == inpotUser);
            return FindVehicle;
        }
        public List<Vehicle> SaerchingByYears(int inpotUser)
        {
           List<Vehicle> FindVehicle = vehicleList.FindAll(vehicle => vehicle.YearOfProduction == inpotUser);
            return FindVehicle;
        }
        public Vehicle SaerchingByLicene(string inputUser)
        {
            Vehicle FindVehicle = vehicleList.Find(vehicle => vehicle.LicensENuumber == inputUser);
            return FindVehicle;
        }
        public static bool IsUnderWorrnty(int year)
        {
            DateTime date = DateTime.Now;
            DateTime dateTime = date.AddYears(-4);
            if (dateTime.Year <= year)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Sort options 

        public void SortVehicleByYear()
        {
            vehicleList.Sort();
            Console.WriteLine("Sort Succss");
        }
        public void SortVehicleByCompany()
        {
            vehicleList.Sort(sort);
            Console.WriteLine("Sort Succss");
        }
        public void SortVehicleByYearAndCompany()
        {
            vehicleList.Sort((x, y) => x.Company == y.Company ? x.CompareTo(y.YearOfProduction) : string.Compare(x.Company, y.Company));
            Console.WriteLine("Sort Succss");
        }

        //vehicle filds for update get from user input
        
            #region UpdateFilds

        public string GetCompany(string input)
        {
            return vehicleTemp.Company = input;
        }
        public string GetManufacture(string input)
        {
            return vehicleTemp.Manufacture = input;
        }
        public int GetYearOfProduction(int input)
        {
            return vehicleTemp.YearOfProduction = input;
        }

        //car filds for update get from user input

        public int GetEngineCapacity(int input)
        {
            return car.EngineCapacityy = input;
        }
        public int GetNumberOfDoors(int input)
        {
            return car.NumberOfDoors = input;
        }

        //truck filds for update get from user input
        public string GetWeight(string input)
        {
            return truck.Weight = input;
        }

        //motorcycle filds for update get from user input
        public int GetEnginePower(int input)
        {
            return motorcycle.EnginePower = input;
        }
        #endregion

        //summry

        public int GetCapcity()
        {
           return vehicleList.Count;
        }
        public void Items()
        {

        }

     

    }
}
