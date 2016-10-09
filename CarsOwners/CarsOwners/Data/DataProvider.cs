using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CarsOwners.Entities;

namespace CarsOwners.Data
{
    public class DataProvider : IDataProvider
    {
        Random rand;

        string[] names = new string[] { "Jan", "Maciej", "Stanis³aw", "Tomasz", "Pawe³", "£ukasz", "Rafa³" };
        string[] surnames = new string[] { "Kowalski", "Nowak", "Wójcik", "Ziêba", "¯ukowski", "D³ugosz", "B¹k" };
        string[] models = new string[] { "Mazda 323", "Honda Accord", "Ferrari Enzo","Ford Focus","Renault Megane","Opel Astra","Hyundai Getz","Polonez ATU" };

        int ownersCount = 10;
        int minCarsCount = 1;
        int maxCarsCount = 4;
        int maxMileage = 100000;
        int minHorsePower = 80;
        int maxHorsePower = 300;

        public DataProvider()
        {
            rand = new Random();
        }

        public IList<Owner> GetData()
        {
            List<Owner> owners = new List<Owner>();

            for (int i = 0; i < ownersCount; i++)
            {
                Owner owner = new Owner();
                owner.FirstName = names[rand.Next(names.Length)];
                owner.LastName = surnames[rand.Next(surnames.Length)];

                int carsNumber = rand.Next(minCarsCount, maxCarsCount + 1);

                for (int k = 0;  k < carsNumber;  k++)
                {
                    Car car = new Car();
                    car.Model = models[rand.Next(models.Length)];
                    car.Mileage = rand.Next(maxMileage);
                    car.ProductionYear = rand.Next(1995, DateTime.Now.Year + 1);
                    car.HorsePower = rand.Next(minHorsePower, maxHorsePower + 1);
                    owner.Cars.Add(car);
                }

                owners.Add(owner);
            }
            return owners;
        }
    }
}