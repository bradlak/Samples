using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarsOwners.Entities;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CarsOwners.Entities
{
    public class Owner
    {
        public Owner()
        {
            Cars = new List<Car>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<Car> Cars { get; set; }
    }
}