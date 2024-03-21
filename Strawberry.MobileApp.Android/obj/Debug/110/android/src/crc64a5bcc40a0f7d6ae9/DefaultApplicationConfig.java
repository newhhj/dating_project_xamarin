package crc64a5bcc40a0f7d6ae9;


public class DefaultApplicationConfig
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.kakao.auth.IApplicationConfig
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getApplicationContext:()Landroid/content/Context;:GetGetApplicationContextHandler:Com.Kakao.Auth.IApplicationConfigInvoker, Com.Kakao.Sdk.Auth\n" +
			"";
		mono.android.Runtime.register ("Com.Kakao.Auth.DefaultApplicationConfig, Com.Kakao.Sdk.Auth", DefaultApplicationConfig.class, __md_methods);
	}


	public DefaultApplicationConfig ()
	{
		super ();
		if (getClass () == DefaultApplicationConfig.class)
			mono.android.TypeManager.Activate ("Com.Kakao.Auth.DefaultApplicationConfig, Com.Kakao.Sdk.Auth", "", this, new java.lang.Object[] {  });
	}


	public android.content.Context getApplicationContext ()
	{
		return n_getApplicationContext ();
	}

	private native android.content.Context n_getApplicationContext ();

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
