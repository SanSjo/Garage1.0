namespace Garage1._0
{
    public interface IHandler
    {
        void AddAirplane();
        void AddBoat();
        void AddBus();
        void AddCar();
        void AddMotorcycle();
        Vehicle AddVehicle();
        bool RegistrationNumber(Vehicle vehicle, string regNumber);
        void SeedData(Garage<Vehicle> filterGarage, int capacity);
    }
}