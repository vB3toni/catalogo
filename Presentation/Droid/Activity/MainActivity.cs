using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Views;
using MeusPedidos.Catalogo.Core.Application.ViewModels;
using MeusPedidos.Catalogo.Presentation.Droid.Components;
using MvvmCross.Droid.Support.V7.AppCompat;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace MeusPedidos.Catalogo.Presentation.Droid.Activity
{
    [Activity(Label = "Catálogo", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/AppTheme")]
    public class MainActivity : MvxAppCompatActivity<MainViewModel>
    {
        private Toolbar _tbMenu;
        private DrawerLayout _drawerLayout;
        private MyActionBarDrawerToggle _drawerToggle;
        private NavigationView _navigationFilter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.main);

            _tbMenu = FindViewById<Toolbar>(Resource.Id.main_tbmenu);

            SetSupportActionBar(_tbMenu);

            var servicoatualizacao = new ServicoAtualizacaoViewModel();

            servicoatualizacao.Notificacao += dto =>
            {
                NotificationBuilder.ShowNotification(this, dto);

                OnResume();
            };

            servicoatualizacao.IniciarDownloadDados();
        }

        protected override void OnStart()
        {
            base.OnStart();

            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.main_dlmenu);
            _drawerToggle = new MyActionBarDrawerToggle(this, _drawerLayout, _tbMenu, Resource.String.open_drawer, Resource.String.close_drawer);
            _drawerLayout.AddDrawerListener(_drawerToggle);

            _navigationFilter = FindViewById<NavigationView>(Resource.Id.main_nvfilter);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);

            _drawerToggle.SyncState();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            menu.Clear();

            MenuInflater.Inflate(Resource.Menu.menu_filter, menu);

            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_filter_categoria:
                    _drawerLayout.OpenDrawer(_navigationFilter);
                    break;
            }

            return true;
        }

        protected override void OnResume()
        {
            base.OnResume();

            ViewModel.CarregarCatalogoPromocao();
            
            ViewModel.CarregarFiltroCategoria();

            ViewModel.CarregarPoliticaDesconto();
        }

        //public override View OnCreateView(View parent, string name, Context context, IAttributeSet attrs)
        //{
        //    try
        //    {
        //        //var view = base.OnCreateView(parent, name, context, attrs);

        //        var viewFilter = FindViewById<LinearLayout>(Resource.Id.main_llfilter);

        //        _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.main_dlmenu);

        //        _navigationFilter = FindViewById<NavigationView>(Resource.Id.main_nvfilter);

        //        viewFilter.RemoveAllViewsInLayout();

        //        var view = this.BindingInflate(Resource.Layout.categoria_filter, viewFilter);

        //        return view;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }

            
        //}
    }

}

