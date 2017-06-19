using System.Collections.Generic;
using System.Reflection;
using Acr.UserDialogs;
using Android.Content;
using MeusPedidos.Catalogo.Core.Application.ViewModels;
using MeusPedidos.Catalogo.Core.CrossCutting;
using MeusPedidos.Catalogo.Presentation.Droid.Startup;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform.Plugins;

namespace MeusPedidos.Catalogo.Presentation.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            UserDialogs.Init(() => Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity);

            return new AppStartup(IoC.Container);
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
        public override void LoadPlugins(IMvxPluginManager pluginManager)
        {
            pluginManager.EnsurePluginLoaded<MvvmCross.Plugins.Color.PluginLoader>();
            pluginManager.EnsurePluginLoaded<MvvmCross.Plugins.Messenger.PluginLoader>();
            pluginManager.EnsurePluginLoaded<MvvmCross.Plugins.DownloadCache.PluginLoader>();
            pluginManager.EnsurePluginLoaded<MvvmCross.Plugins.File.PluginLoader>();

            base.LoadPlugins(pluginManager);
        }

        protected override IEnumerable<Assembly> AndroidViewAssemblies => new List<Assembly>(base.AndroidViewAssemblies)
        {
            typeof(MvvmCross.Droid.Support.V7.RecyclerView.MvxRecyclerView).Assembly
        };

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            MvxAppCompatSetupHelper.FillTargetFactories(registry);

            base.FillTargetFactories(registry);
        }
    }
}
