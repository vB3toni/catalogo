package md546f3dfcaeaa3c121b356f19fc3eea952;


public class CarrinhoCompraActivity
	extends md59eb8f433c94e7a6df253111f8a83a851.MvxAppCompatActivity_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("MeusPedidos.Catalogo.Presentation.Droid.Activity.CarrinhoCompraActivity, MeusPedidos.Catalogo.Presentation.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CarrinhoCompraActivity.class, __md_methods);
	}


	public CarrinhoCompraActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CarrinhoCompraActivity.class)
			mono.android.TypeManager.Activate ("MeusPedidos.Catalogo.Presentation.Droid.Activity.CarrinhoCompraActivity, MeusPedidos.Catalogo.Presentation.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
