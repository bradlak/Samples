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
using Java.Lang;
using CarsOwners.Entities;

namespace CarsOwners.Infrastructure
{
    public class ExpandableCarsAdapter : BaseExpandableListAdapter
    {
        Activity context;
        public IList<Owner> data;

        public ExpandableCarsAdapter(Activity context, IList<Owner> data)
        {
            this.context = context;
            this.data = data;
        }

        public override int GroupCount
        {
            get
            {
                return data.Count();
            }
        }

        public override bool HasStableIds
        {
            get
            {
                return true;
            }
        }

        public override Java.Lang.Object GetChild(int groupPosition, int childPosition)
        {
            return childPosition;
        }

        public override long GetChildId(int groupPosition, int childPosition)
        {
            return childPosition;
        }

        public override int GetChildrenCount(int groupPosition)
        {
            return data[groupPosition].Cars.Count();
        }

        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            View childView = convertView;
            if(childView == null)
            {
                childView = context.LayoutInflater.Inflate(Resource.Layout.SingleCar, null);
            }

            var currentChild = data[groupPosition].Cars[childPosition];

            childView.FindViewById<TextView>(Resource.Id.modelTXT).Text = currentChild.Model;
            childView.FindViewById<TextView>(Resource.Id.mileageTXT).Text = currentChild.Mileage.ToString() + " km";
            childView.FindViewById<TextView>(Resource.Id.productionTXT).Text = currentChild.ProductionYear.ToString();

            SignPowerOfCar(childView.FindViewById<TextView>(Resource.Id.horsePowerTXT), currentChild.HorsePower);

            return childView;
        }

        public override Java.Lang.Object GetGroup(int groupPosition)
        {
            throw new NotImplementedException();
        }

        public override long GetGroupId(int groupPosition)
        {
            return groupPosition;
        }

        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            View groupView = convertView;
            if(groupView == null)
            {
                groupView = context.LayoutInflater.Inflate(Resource.Layout.OwnersGroup, null);
            }

            var currentGroup = data[groupPosition];

            groupView.FindViewById<TextView>(Resource.Id.OwnerName).Text = string.Format("{0} {1}", currentGroup.FirstName,  currentGroup.LastName);

            return groupView;
        }

        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            return true;
        }

        private void SignPowerOfCar(TextView view, int value)
        {
            string colorValue;
            if (value < 100) colorValue = context.Resources.GetString(Resource.Color.lowPower);
            else if (value < 170) colorValue = context.Resources.GetString(Resource.Color.mediumPower);
            else if (value < 240) colorValue = context.Resources.GetString(Resource.Color.hightPower);
            else colorValue = context.Resources.GetString(Resource.Color.ultraPower);

            view.Text = value.ToString() + " KM";
            view.SetTextColor(Android.Graphics.Color.ParseColor(colorValue));
        }
    }
}