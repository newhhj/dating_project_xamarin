package crc6432bce2f0029eae39;


public class InstallReferrerStateListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.android.installreferrer.api.InstallReferrerStateListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onInstallReferrerServiceDisconnected:()V:GetOnInstallReferrerServiceDisconnectedHandler:Com.Android.Installreferrer.Api.IInstallReferrerStateListenerInvoker, Xamarin.Android.Binding.InstallReferrer\n" +
			"n_onInstallReferrerSetupFinished:(I)V:GetOnInstallReferrerSetupFinished_IHandler:Com.Android.Installreferrer.Api.IInstallReferrerStateListenerInvoker, Xamarin.Android.Binding.InstallReferrer\n" +
			"";
		mono.android.Runtime.register ("Strawberry.MobileApp.Droid.InstallReferrerHelper.InstallReferrerStateListener, Strawberry.MobileApp.Android", InstallReferrerStateListener.class, __md_methods);
	}


	public InstallReferrerStateListener ()
	{
		super ();
		if (getClass () == InstallReferrerStateListener.class) {
			mono.android.TypeManager.Activate ("Strawberry.MobileApp.Droid.InstallReferrerHelper.InstallReferrerStateListener, Strawberry.MobileApp.Android", "", this, new java.lang.Object[] {  });
		}
	}


	public void onInstallReferrerServiceDisconnected ()
	{
		n_onInstallReferrerServiceDisconnected ();
	}

	private native void n_onInstallReferrerServiceDisconnected ();


	public void onInstallReferrerSetupFinished (int p0)
	{
		n_onInstallReferrerSetupFinished (p0);
	}

	private native void n_onInstallReferrerSetupFinished (int p0);

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
