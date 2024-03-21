package crc648bfb30e6f00b1c88;


public class DefaultLogoutResponseCallback
	extends com.kakao.usermgmt.callback.LogoutResponseCallback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCompleteLogout:()V:GetOnCompleteLogoutHandler\n" +
			"";
		mono.android.Runtime.register ("Com.Kakao.Usermgmt.Callback.DefaultLogoutResponseCallback, Com.Kakao.Sdk.Usermgmt", DefaultLogoutResponseCallback.class, __md_methods);
	}


	public DefaultLogoutResponseCallback ()
	{
		super ();
		if (getClass () == DefaultLogoutResponseCallback.class)
			mono.android.TypeManager.Activate ("Com.Kakao.Usermgmt.Callback.DefaultLogoutResponseCallback, Com.Kakao.Sdk.Usermgmt", "", this, new java.lang.Object[] {  });
	}


	public void onCompleteLogout ()
	{
		n_onCompleteLogout ();
	}

	private native void n_onCompleteLogout ();

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
