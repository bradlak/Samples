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

namespace CarsOwners.Entities
{
    public class Car
    {
        public string Model { get; set; }
        public int Mileage { get; set; }
        public int ProductionYear { get; set; }
        public int HorsePower { get; set; }
    }
}