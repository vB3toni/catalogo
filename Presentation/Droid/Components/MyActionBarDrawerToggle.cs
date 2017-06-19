using System;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;

namespace MeusPedidos.Catalogo.Presentation.Droid.Components
{
    public class MyActionBarDrawerToggle : ActionBarDrawerToggle
    {
        public MyActionBarDrawerToggle(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public MyActionBarDrawerToggle(Android.App.Activity activity, DrawerLayout drawerLayout, Toolbar toolbar, int openDrawerContentDescRes, int closeDrawerContentDescRes) : base(activity, drawerLayout, toolbar, openDrawerContentDescRes, closeDrawerContentDescRes)
        {
        }

        public MyActionBarDrawerToggle(Android.App.Activity activity, DrawerLayout drawerLayout, int openDrawerContentDescRes, int closeDrawerContentDescRes) : base(activity, drawerLayout, openDrawerContentDescRes, closeDrawerContentDescRes)
        {
        }

        public override void OnDrawerClosed(View drawerView)
        {
            var typeDrawerView = (int)drawerView.Tag;
            if (typeDrawerView == 0)
            {
                //left drawer
                base.OnDrawerClosed(drawerView);
            }
        }

        public override void OnDrawerOpened(View drawerView)
        {
            var typeDrawerView = (int)drawerView.Tag;
            if (typeDrawerView == 0)
            {
                //left drawer
                base.OnDrawerOpened(drawerView);
            }
        }

        public override void OnDrawerSlide(View drawerView, float slideOffset)
        {
            var typeDrawerView = (int)drawerView.Tag;
            if (typeDrawerView == 0)
            {
                //left drawer
                base.OnDrawerSlide(drawerView, slideOffset);
            }
        }
    }
}