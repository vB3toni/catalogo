package md59e947013b368879c6e5c6378203f2e1b;


public class AtualizacaoService
	extends android.app.Service
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:()V:GetOnCreateHandler\n" +
			"n_onBind:(Landroid/content/Intent;)Landroid/os/IBinder;:GetOnBind_Landroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("MeusPedidos.Catalogo.Presentation.Droid.Service.AtualizacaoService, MeusPedidos.Catalogo.Presentation.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AtualizacaoService.class, __md_methods);
	}


	public AtualizacaoService () throws java.lang.Throwable
	{
		super ();
		if (getClass () == AtualizacaoService.class)
			mono.android.TypeManager.Activate ("MeusPedidos.Catalogo.Presentation.Droid.Service.AtualizacaoService, MeusPedidos.Catalogo.Presentation.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate ()
	{
		n_onCreate ();
	}

	private native void n_onCreate ();


	public android.os.IBinder onBind (android.content.Intent p0)
	{
		return n_onBind (p0);
	}

	private native android.os.IBinder n_onBind (android.content.Intent p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
