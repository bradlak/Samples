using EFCoreTest.Data.Entities;
using System;
using System.Collections.Generic;

namespace EFCoreTest.Data.Providers
{
    public class SampleDataProvider
    {
        private Random random;

        public SampleDataProvider()
        {
            random = new Random();
        }

        public IEnumerable<Owner> GetSampleData()
        {
            return new List<Owner>()
            {
              new Owner()
              {
                Age = random.Next(20, 50),
                FirstName = "Stefan",
                LastName = "Kowalski",
                Cars = new List<Car>()
                {
                    new Car() {Brand = "Fiat", Model = "Panda", ProductionYear = 1998, HorsePower = 110 },
                    new Car() {Brand = "Honda", Model = "Civic", ProductionYear = 2011, HorsePower = 130 }
                }
            },
             new Owner()
            {
                Age = random.Next(20, 50),
                FirstName = "Jan",
                LastName = "Nowak",
                Cars = new List<Car>()
                {
                    new Car() {Brand = "Toyota", Model = "Auris", ProductionYear = 2014, HorsePower = 130 },
                    new Car() {Brand = "Polonez", Model = "Atu", ProductionYear = 1996, HorsePower = 80 }
                }
            }
            };
        }
    }
}