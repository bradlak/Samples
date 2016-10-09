using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CarsOwners.Data;
using CarsOwners.Infrastructure;
using CarsOwners.Entities;

namespace CarsOwners
{
    [Activity(Label = "CarsOwners", MainLauncher = true, Icon = "@drawable/carowner")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            IDataProvider provider = new DataProvider();

            var sampleData = provider.GetData();

            SetContentView(Resource.Layout.Main);


            var adapter = new ExpandableCarsAdapter(this, sampleData);
            var exListView = FindViewById<ExpandableListView>(Resource.Id.expandableListView);

            exListView.SetAdapter(adapter);
        }
    }
}

