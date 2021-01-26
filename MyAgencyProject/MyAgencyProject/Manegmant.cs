using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgencyVehicleManegmant;

namespace MyAgencyProject
{
    public class Manegmant
    {
        static VehicleManegmant manegmantList = new VehicleManegmant();
        //create object

        static public Vehicle GetVehicleFromUser(Vehicle vehicle)
        {
            Vehicle vehicleTemp;
            Console.WriteLine("Pleals enter Company");
            vehicle.Company = Console.ReadLine();
            Console.WriteLine("Please enter Model");
            vehicle.Manufacture = Console.ReadLine();
            Console.WriteLine("Please enter Year of Produaction");
            vehicle.YearOfProduction = IsOkNumber(Console.ReadLine());
            do
            {
                Console.WriteLine("Please enter License Number");
                vehicle.LicensENuumber = Console.ReadLine();
                vehicleTemp = manegmantList.SaerchingByLicene(vehicle.LicensENuumber);
                if (vehicleTemp != null)
                {
                    Console.WriteLine("There is already number like this");
                }
            } while (vehicleTemp != null);

            return vehicle;
        }
        static public Car GetCarFromUser()
        {
            Car car = new Car();
            GetVehicleFromUser(car);
            Console.WriteLine("Please Enter Number Of Doors");
            car.NumberOfDoors = IsOkNumber(Console.ReadLine());
            Console.WriteLine("Please Enter Engin Capcity");
            car.EngineCapacityy = IsOkNumber(Console.ReadLine());
            Console.WriteLine("************************************");

            return car;
        }
        static public Truck GetTruckFromUser()
        {
            Truck truck = new Truck();
            GetVehicleFromUser(truck);
            Console.WriteLine("Please Enter Weight");
            truck.Weight = Console.ReadLine();
            Console.WriteLine("************************************");

            return truck;
        }
        static public Motorcycle GetMotorcycleFromUser()
        {
            Motorcycle motorcycle = new Motorcycle();
            GetVehicleFromUser(motorcycle);
            Console.WriteLine("Please Enter The Engine Capacity");
            motorcycle.EnginePower = IsOkNumber(Console.ReadLine());
            Console.WriteLine("************************************");

            return motorcycle;
        }

        //add to the list object

        static void AddCarsFromUser()
        {
            Console.WriteLine("How Many Cars Do you Want To Add");
            int inputUser = IsOkNumber(Console.ReadLine());
            for (int i = 0; i < inputUser; i++)
            {
                manegmantList.AddCars(GetCarFromUser());
            }
        }
        static void AddTruckFromUser()
        {
            Console.WriteLine("How many Trucks do you want to add ?");
            int inputUsre = IsOkNumber(Console.ReadLine());
            for (int i = 0; i < inputUsre; i++)
            {
                manegmantList.AddTruck(GetTruckFromUser());
            }
        }
        static void AddMotorcycleFromUser()
        {
            Console.WriteLine("How many Motorcycles do you want to add ?");
            int inputUsre = IsOkNumber(Console.ReadLine());
            for (int i = 0; i < inputUsre; i++)
            {
                manegmantList.AddMotorcycle(GetMotorcycleFromUser());
            }
        }

        //------------------------------

        static VehicleTypes PrintManuAddVehiclesChoiceUser()
        {
            VehicleTypes types;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Tools.DesinColor("*In Any Time if you want to go Out prees =>*out*<=", ConsoleColor.Red);
            Console.WriteLine("\n\nChoose an option:");
            Console.WriteLine("Press Number 1: To Add Cars");
            Console.WriteLine("Press Number 2: To Add Trucks");
            Console.WriteLine("Press Number 3: To Add Motorcycle");
            Console.WriteLine("Press Number 4: To Return Back To Manu");
            Enum.TryParse(Console.ReadLine(), out types);
            return types;
        }
        static void SwichAddVehicles(ValueType type)
        {
            switch (type)
            {
                case VehicleTypes.Car:
                    AddCarsFromUser();
                    Tools.DesinColor("Everything was inserted, Please Press any key to continu !", ConsoleColor.Green);
                    break;
                case VehicleTypes.Truck:
                    AddTruckFromUser();
                    Tools.DesinColor("Everything was inserted, Please Press any key to continu !", ConsoleColor.Green);
                    break;
                case VehicleTypes.Motorcycle:
                    AddMotorcycleFromUser();
                    Tools.DesinColor("Everything was inserted, Please Press any key to continu !", ConsoleColor.Green);
                    break;
                case VehicleTypes.Exit:
                    break;
                default:
                    Tools.DesinColor("Wrong Choice Please Select Again", ConsoleColor.Red);
                    Console.ReadKey();
                    break;
            }
        }
        static void LoopAddVehiclesManenmant()
        {
            VehicleTypes choice;
            do
            {
                choice = PrintManuAddVehiclesChoiceUser();
                SwichAddVehicles(choice);
            } while (choice != VehicleTypes.Exit);
        }
        static void SwichAddOneVehicle(ValueType type)
        {
            switch (type)
            {
                case VehicleTypes.Car:
                    manegmantList.AddCars(GetCarFromUser());
                    Tools.DesinColor("Everything was inserted, Please Press any key to continu !", ConsoleColor.Green);
                    Console.ReadKey();
                    break;
                case VehicleTypes.Truck:
                    manegmantList.AddTruck(GetTruckFromUser());
                    Tools.DesinColor("Everything was inserted, Please Press any key to continu !", ConsoleColor.Green);
                    Console.ReadKey();
                    break;
                case VehicleTypes.Motorcycle:
                    manegmantList.AddMotorcycle(GetMotorcycleFromUser());
                    Tools.DesinColor("Everything was inserted, Please Press any key to continu !", ConsoleColor.Green);
                    Console.ReadKey();
                    break;
                case VehicleTypes.Exit:
                    break;
                default:
                    Tools.DesinColor("Wrong Choice Please Select Again", ConsoleColor.Red);
                    Console.ReadKey();
                    break;
            }
        }
        static void LoopAddOneVehicleManegmant()
        {
            VehicleTypes choice;
            do
            {
                choice = PrintManuAddVehiclesChoiceUser();
                SwichAddOneVehicle(choice);
            } while (choice != VehicleTypes.Exit);
        }
        //remove object form list


        static void RemovVehicl()
        {
            Console.WriteLine("Please enter Vehicle number");
            manegmantList.RemovVehicl(Console.ReadLine());
            Tools.DesinColor("The Vehcle was remove", ConsoleColor.Green);
        }

        //Show data on scren 

        static ShowVehicle PrintManuPrintVehiclChoice()
        {
            ShowVehicle show;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("Press Number 1: To See Only Cars");
            Console.WriteLine("Press Number 2: To See Only Trucks");
            Console.WriteLine("Press Number 3: To See Only Motorcycle");
            Console.WriteLine("Press Number 4: To back To Mneu");
            Enum.TryParse(Console.ReadLine(), out show);
            return show;
        }
        static void SwichPrintVehiclsChoice(ShowVehicle vehicle)
        {
            switch (vehicle)
            {
                case ShowVehicle.PrintCar:
                    GetPrintCar();
                    Console.ReadKey();
                    break;
                case ShowVehicle.PreintTruks:
                    GetPrintTruck();
                    Console.ReadKey();
                    break;
                case ShowVehicle.PreintMotorcycle:
                    GetPrintMotorcycle();
                    Console.ReadKey();
                    break;
                case ShowVehicle.Exit:
                default:
                    Tools.DesinColor("Wrong Choice Please Select Again", ConsoleColor.Red);
                    break;
            }
        }
        static void LoopPrintVehicleManegmant()
        {
            ShowVehicle show;
            do
            {
                show = PrintManuPrintVehiclChoice();
                SwichPrintVehiclsChoice(show);
            } while (show != ShowVehicle.Exit);
        }
        static void PrintVehicleToConsole()
        {
            foreach (Vehicle vehicle in manegmantList.PrintVehicle())
            {
                Console.WriteLine("**********************");
                Console.WriteLine(vehicle.ToString());
                Console.WriteLine("**********************");
            }
        }
        static void GetPrintCar()
        {
            foreach (Vehicle vehicle in manegmantList.PrintVehicle())
            {
                if (vehicle is Car)
                {
                    Console.WriteLine("**********************");
                    Console.WriteLine(vehicle.ToString());
                    Console.WriteLine("**********************");
                }
            }
        }
        static void GetPrintTruck()
        {
            foreach (Vehicle vehicle in manegmantList.PrintVehicle())
            {
                if (vehicle is Truck)
                {
                    Console.WriteLine("**********************");
                    Console.WriteLine(vehicle.ToString());
                    Console.WriteLine("**********************");
                }
            }
        }
        static void GetPrintMotorcycle()
        {
            foreach (Vehicle vehicle in manegmantList.PrintVehicle())
            {
                if (vehicle is Motorcycle)
                {
                    Console.WriteLine("**********************");
                    Console.WriteLine(vehicle.ToString());
                    Console.WriteLine("**********************");
                }
            }
        }

        //main manu options

        public void MainMenu()
        {
            string select = null;
            do
            {
                Console.Clear();
                Console.WriteLine("                                 ****************************");
                Console.WriteLine("                                 *   Vehicle App Manegmant  *");
                Console.WriteLine("                                 ****************************");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("Press Number 1: To insret And remove vehcle");
                Console.WriteLine("Press Number 2: To see all the vehicle");
                Console.WriteLine("Press Number 3: To see spacific vehicle");
                Console.WriteLine("Press Number 4: To Write and open file options");
                Console.WriteLine("Press Number 5: To saerching options");
                Console.WriteLine("Press Number 6: To sort options");
                Console.WriteLine("Press Number 7: To Update car");
                Console.WriteLine("Press Number 8: To exit");
                select = Console.ReadLine();

                switch (select)
                {
                    case "1":
                        LoopInsertAndRemoveVehicle();
                        break;
                    case "2":
                        PrintVehicleToConsole();
                        Console.ReadKey();
                        break;
                    case "3":
                        LoopPrintVehicleManegmant();
                        break;
                    case "4":
                        LoopSaveReadFromFileManegmant();
                        break;
                    case "5":
                        LoopSearchingOptionsManegmant();
                        break;
                    case "6":
                        LoopSortedVehicle();
                        break;
                    case "7":
                        UpdateManegmante();
                        break;
                    case "8":
                        Console.WriteLine("Good Bey");
                        break;
                    default:
                        Console.WriteLine("Wrong Choic select agien please");
                        Console.ReadKey();
                        break;
                }
            } while (select != "8");
        }

        static InsertAndRemoveVehicle PrintManuInsertAndRemoveVehicles()
        {
            InsertAndRemoveVehicle insertAndRemoveVehicle;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
            Tools.DesinColor("*In Any Time if you want to go Out prees =>*out*<=", ConsoleColor.Red);
            Console.WriteLine("\n\nChoose an option:");
            Console.WriteLine("Press Number 1: To Insert Vehicle");
            Console.WriteLine("Press Number 2: To Insert Only One Vehicle");
            Console.WriteLine("Press Number 3: To Remove Vehicles");
            Console.WriteLine("Press Number 4: To Remove Only One Vehicle");
            Console.WriteLine("Press Number 5: To back To Mneu");
            Enum.TryParse(Console.ReadLine(), out insertAndRemoveVehicle);
            return insertAndRemoveVehicle;
        }
        static void SwichInsertAndRemoveVehicle(InsertAndRemoveVehicle insertAndRemoveVehicle)
        {
            switch (insertAndRemoveVehicle)
            {
                case InsertAndRemoveVehicle.InsertVehicle:
                    LoopAddVehiclesManenmant();
                    break;
                case InsertAndRemoveVehicle.InsertOnlyOneVehicle:
                    LoopAddOneVehicleManegmant();
                    break;
                case InsertAndRemoveVehicle.RemoveVehicles:
                    Console.WriteLine("sadsadsadsad");
                    break;
                case InsertAndRemoveVehicle.RemoveOnlyOneVehicle:
                    RemovVehicl();
                    break;
                case InsertAndRemoveVehicle.Exit:
                    break;
                default:
                    Tools.DesinColor("Wrong Choice Please Select Agian", ConsoleColor.Red);
                    break;
            }
        }
        static void LoopInsertAndRemoveVehicle()
        {
            InsertAndRemoveVehicle insertAndRemove;
            do
            {
                insertAndRemove = PrintManuInsertAndRemoveVehicles();
                SwichInsertAndRemoveVehicle(insertAndRemove);
            } while (insertAndRemove != InsertAndRemoveVehicle.Exit);
        }

        //Save And Read and read options

        static void UseCreateFile()
        {
            string choice;
            do
            {
                Console.Clear();
                Console.WriteLine("Press Number 1: To Create With StreamWriter");
                Console.WriteLine("Press Number 2: To Create With BinaryFormtter");
                Console.WriteLine("Press Number 3: To Exit");
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("Please Enter The Path Here");
                    string pathStream = Console.ReadLine();
                    manegmantList.WritToFileUseChoise(pathStream);
                }
                if (choice == "2")
                {
                    Console.WriteLine("Please Enter The Path Here");
                    string pathBinary = Console.ReadLine();
                    manegmantList.BinarySerializtionUserChoise(pathBinary);
                }
            } while (choice != "3");
        }
        static SaveAndReadOptions PrintManuSaveAndReadOptions()
        {
            SaveAndReadOptions options;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("Press Number 1: To Save With Stream Writer");
            Console.WriteLine("Press Number 2: To Save With Binary Serialization");
            Console.WriteLine("Press Number 3: To Open File By Stream Reader");
            Console.WriteLine("Press Number 4: To Open File By Bianry Deserialize");
            Console.WriteLine("Press Number 5: To Create New File");
            Console.WriteLine("Press Number 6: To Exit");
            Enum.TryParse(Console.ReadLine(), out options);
            return options;
        }
        static void SwichSaveAndReadOptionChoice(SaveAndReadOptions options)
        {
            switch (options)
            {
                case SaveAndReadOptions.SaveToFileByStreaWriter:
                    manegmantList.WritToFile();
                    Tools.DesinColor("The data was saved to the file By Stream Writer", ConsoleColor.Green);
                    Console.ReadKey();
                    break;
                case SaveAndReadOptions.SaveToFileByBinarySerialization:
                    NoteForUser();
                    break;
                case SaveAndReadOptions.ReadFromFileByStreamRedar:
                    manegmantList.ReadFromFile();
                    Tools.DesinColor("The data was loaded By Stream Reder", ConsoleColor.Green);
                    Console.ReadKey();
                    break;
                case SaveAndReadOptions.ReadFromFileByBianryDeserialize:
                    manegmantList.BianryDeserialize();
                    Tools.DesinColor("The data was loaded By Bianry Deserialze", ConsoleColor.Green);
                    Console.ReadKey();
                    break;
                case SaveAndReadOptions.CreateNewFile:
                    UseCreateFile();
                    break;
                case SaveAndReadOptions.Exit:
                    break;
                default:
                    Tools.DesinColor("Wrong Number Please Select Again", ConsoleColor.Red);
                    break;
            }
        }
        static void LoopSaveReadFromFileManegmant()
        {
            SaveAndReadOptions save;
            do
            {
                save = PrintManuSaveAndReadOptions();
                SwichSaveAndReadOptionChoice(save);
            } while (save != SaveAndReadOptions.Exit);
        }

        //Sort function

        static SortedVehicle PrintSortedVehicleManu()
        {
            SortedVehicle sorted;
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("Press Number 1: To Sorted By Year");
            Console.WriteLine("Press Number 2: To Sorted By Company");
            Console.WriteLine("Press Number 3: To Sorted By Year And Company");
            Console.WriteLine("Press Number 4: To Exit");
            Enum.TryParse(Console.ReadLine(), out sorted);
            return sorted;
        }
        static void SwichSortedVehicleChoice(SortedVehicle sorted)
        {
            switch (sorted)
            {
                case SortedVehicle.SortByYear:
                    manegmantList.SortVehicleByYear();
                    Tools.DesinColor("The Vehicle Is Sort By Year", ConsoleColor.Green);
                    break;
                case SortedVehicle.SortByCompany:
                    manegmantList.SortVehicleByCompany();
                    Tools.DesinColor("The Vehicle Is Sort By Company", ConsoleColor.Green);
                    break;
                case SortedVehicle.SortByYearAndCompany:
                    manegmantList.SortVehicleByYearAndCompany();
                    Tools.DesinColor("The Vehicle Is Sort By Year And Company", ConsoleColor.Green);
                    break;
                case SortedVehicle.Exit:
                    break;
                default:
                    Tools.DesinColor("Wrong Number Please Try Again", ConsoleColor.Red);
                    break;
            }
        }
        static void LoopSortedVehicle()
        {
            SortedVehicle sorted;
            do
            {
                sorted = PrintSortedVehicleManu();
                SwichSortedVehicleChoice(sorted);
            } while (sorted != SortedVehicle.Exit);
        }

        //saech options

        static SearchOptions PrintSearchOptionManu()
        {
            SearchOptions option;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("Press Number 1: To Search Vehicle Warranty");
            Console.WriteLine("Press Number 2: To Search Vehice By Licens Number");
            Console.WriteLine("Press Number 3: To Search Vehicl By Company");
            Console.WriteLine("Press Number 4: To Search Vehicl By Model");
            Console.WriteLine("Press Number 5: To Saerch Vehicl By Years");
            Console.WriteLine("Press Number 6: To Exit");
            Enum.TryParse(Console.ReadLine(), out option);
            return option;
        }
        static void SwichSearchingChoiceOptions(SearchOptions search)
        {
            switch (search)
            {
                case SearchOptions.SearchWorrntyVehcle:
                    manegmantList.FindVehicleWithWorrnty();
                    Console.ReadKey();
                    break;
                case SearchOptions.SearchByLicensNumber:
                    manegmantList.SaerchingByLicene(Console.ReadLine());
                    Console.ReadKey();
                    break;
                case SearchOptions.SearcByCompany:
                    manegmantList.SaerchingByCompany(Console.ReadLine());
                    Console.ReadKey();
                    break;
                case SearchOptions.SearchByModel:
                    manegmantList.SaerchingByBrand(Console.ReadLine());
                    Console.ReadKey();
                    break;
                case SearchOptions.SaerchVehiclByYears:
                    manegmantList.SaerchingByYears(IsOkNumber(Console.ReadLine()));
                    break;
                case SearchOptions.Exit:
                    break;
                default:
                    Tools.DesinColor("Wrong Number Please Selct Again", ConsoleColor.Red);
                    break;
            }
        }
        static void LoopSearchingOptionsManegmant()
        {
            SearchOptions options;
            do
            {
                options = PrintSearchOptionManu();
                SwichSearchingChoiceOptions(options);
            } while (options != SearchOptions.Exit);
        }

        //Update function

        static Truck UpdateTruck(Truck truck)
        {
            string select = null;
            do
            {
                Console.Clear();
                Console.WriteLine("Press Number 1: To chang Company");
                Console.WriteLine("Press Number 2: To chang Model");
                Console.WriteLine("Press Number 3: To chang Year Of Production");
                Console.WriteLine("Press Number 4: To chang Weigt");
                Console.WriteLine("Press Number 5: To back to the Menu");
                select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                        Console.WriteLine("Please Enter Company");
                        truck.Company = Console.ReadLine();
                        Tools.DesinColor("The Company was cange", ConsoleColor.Green);
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("Please Enter Model");
                        truck.Manufacture = Console.ReadLine();
                        Tools.DesinColor("The Model was cange", ConsoleColor.Green);
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("Please Enter Year Of Production ");
                        truck.YearOfProduction = IsOkNumber(Console.ReadLine());
                        Tools.DesinColor("The Year Of Production was cange", ConsoleColor.Green);
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Please enter Weight");
                        truck.Weight = Console.ReadLine();
                        Tools.DesinColor("The Weight was change", ConsoleColor.Green);
                        Console.ReadKey();
                        break;
                    case "5":
                        break;
                    default:
                        Tools.DesinColor("Wrong number please selecte agine", ConsoleColor.Red);
                        Console.ReadKey();
                        break;
                }
            } while (select != "5");

            return truck;
        }
        static Motorcycle UpdateMotorcycle(Motorcycle motorcycle)
        {
            string select = null;
            do
            {
                Console.Clear();
                Console.WriteLine("Press Number 1: To chang Company");
                Console.WriteLine("Press Number 2: To chang Model");
                Console.WriteLine("Press Number 3: To chang Yea Of Production");
                Console.WriteLine("Press Number 4: To chang engine capacity");
                Console.WriteLine("Press Number 5: To back to the Menu");


                select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                        Console.WriteLine("Pleals enter Company");
                        motorcycle.Company = Console.ReadLine();
                        Tools.DesinColor("The Company was cange", ConsoleColor.Green);
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("Please enter Model");
                        motorcycle.Manufacture = Console.ReadLine();
                        Tools.DesinColor("The Model was cange", ConsoleColor.Green);
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("Please Enter Year Of Production");
                        motorcycle.YearOfProduction = IsOkNumber(Console.ReadLine());
                        Tools.DesinColor("The Year Of Production was cange", ConsoleColor.Green);
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Please Enter Engine Capcity");
                        motorcycle.EnginePower = IsOkNumber(Console.ReadLine());
                        Tools.DesinColor("The Engine Capacity was cange", ConsoleColor.Green);
                        Console.ReadKey();
                        break;
                    case "5":
                        break;
                    default:
                        Tools.DesinColor("Wrong number please selecte agine", ConsoleColor.Red);
                        Console.ReadKey();
                        break;
                }
            } while (select != "5");

            return motorcycle;
        }
        static Car UpdateCar(Car car)
        {
            string select = null;
            do
            {
                Console.Clear();
                Console.WriteLine("Press Number 1: To chang Company");
                Console.WriteLine("Press Number 2: To chang Manufacture");
                Console.WriteLine("Press Number 3: To chang Year Of Production");
                Console.WriteLine("Press Number 4: To chang Engine Capacity");
                Console.WriteLine("Press Number 5: To chang Number Of Doors ");
                Console.WriteLine("Press Number 6: To back to the Menu");
                select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                        Console.WriteLine("Pleals enter Company");
                        car.Company = Console.ReadLine();
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("Pleals enter Manufacture");
                        car.Manufacture = Console.ReadLine();
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("Pleals enter Year Of Production");
                        car.YearOfProduction = IsOkNumber(Console.ReadLine());
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Pleals enter Engine Capacity");
                        car.EngineCapacityy = IsOkNumber(Console.ReadLine());
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.WriteLine("Pleals enter Number Of Doors");
                        car.NumberOfDoors = IsOkNumber(Console.ReadLine());
                        Console.ReadKey();
                        break;
                    case "6":
                        break;
                    default:
                        Tools.DesinColor("Wrong Number Please Select Agian", ConsoleColor.Red);
                        break;
                }
            } while (select != "6");
            return car;
        }
        static void UpdateVehicle(Vehicle vehicle)
        {
            if (vehicle is Car)
            {
                UpdateCar(vehicle as Car);
            }
            if (vehicle is Truck)
            {
                UpdateTruck(vehicle as Truck);
            }
            if (vehicle is Motorcycle)
            {
                UpdateMotorcycle(vehicle as Motorcycle);
            }
        }
        static void UpdateManegmante()
        {
            Console.WriteLine("Please enter the licens number for the car that you want to chang");
            string inputCarFromUser = Console.ReadLine();
            Vehicle vehicle = manegmantList.SaerchingByLicene(inputCarFromUser);
            UpdateVehicle(vehicle);
        }

        //function

        static void NoteForUser()
        {
            Tools.DesinColor("Note That You Need To Load From The File Withe Binary Desrilaz Befor You Save Vehicle",ConsoleColor.Red);
            Console.WriteLine("\nPress Number 1: To Continued");
            Console.WriteLine("Press Number 2: To Back And Load");
            string inputUser = Console.ReadLine();
            if (inputUser == "1")
            {
                manegmantList.BinarySerialization();
                Tools.DesinColor("The data was saved to the file By Binart Serialzation", ConsoleColor.Green);
                Console.ReadKey();
            }
        }
        public static int IsOkNumber(string inputUser)
        {
            bool succss = true;
            int outPut;

            do
            {
                succss = int.TryParse(inputUser, out outPut);
                if (succss == true)
                {
                    return outPut;
                }
                else
                {
                    Console.WriteLine("Wrong Input Please Try Agian !");
                }
                inputUser = Console.ReadLine();
            } while (succss == false);
            return outPut;
        }
    }
}

