using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAgencyProject
{
    public enum VehicleTypes
    {
        Car = 1,
        Truck = 2,
        Motorcycle = 3,
        Exit = 4,
    }
    enum MainMenu
    {
        InsertAndRemoveVehicle = 1,
        PreintVehicle = 2,
        PrintSpecificVehicle = 3,
        SaveAndOpenOptions = 4,
        SearchingOptions = 5,
        SortVehicleOptions = 6,
        UpdatVehicle = 7,
        Exit = 8,
    }
    enum InsertAndRemoveVehicle
    {
        InsertVehicle = 1,
        InsertOnlyOneVehicle = 2,
        RemoveVehicles = 3,
        RemoveOnlyOneVehicle = 4,
        Exit = 5,
    }
    enum ShowVehicle
    {
        PrintCar = 1,
        PreintTruks = 2,
        PreintMotorcycle = 3,
        Exit = 4,
    }
    enum SearchOptions
    {
        SearchWorrntyVehcle = 1,
        SearchByLicensNumber = 2,
        SearcByCompany = 3,
        SearchByModel = 4,
        SaerchVehiclByYears = 5,
        Exit = 6,
    }
    enum SortedVehicle
    {
        SortByYear = 1,
        SortByCompany = 2,
        SortByYearAndCompany = 3,
        Exit = 4,
    }
    enum SaveAndReadOptions
    {
        SaveToFileByStreaWriter = 1,
        SaveToFileByBinarySerialization = 2,
        ReadFromFileByStreamRedar = 3,
        ReadFromFileByBianryDeserialize = 4,
        CreateNewFile = 5,
        Exit = 6,
    }
}
