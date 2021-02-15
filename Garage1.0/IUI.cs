using System;

namespace Garage1._0
{
    public interface IUI 
    {
        string WrongInput(string message);
        void ExitGarage();
        string GetInput();
        void Print(string message);
        void PrintVehicle(Vehicle item);

    }
}