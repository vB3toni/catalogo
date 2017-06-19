using Android.App;
using Android.OS;
using MeusPedidos.Catalogo.Core.Application.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace MeusPedidos.Catalogo.Presentation.Droid.Activity
{
    [Activity(Label = "Carrinho", Theme = "@style/AppTheme")]
    public class CarrinhoCompraActivity : MvxAppCompatActivity<CarrinhoCompraViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.carrinho);
        }
    }
}