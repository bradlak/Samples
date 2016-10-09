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
    public interface IDataProvider
    {
        IList<Owner> GetData();
    }
}