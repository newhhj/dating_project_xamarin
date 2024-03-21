package crc648bfb30e6f00b1c88;


public class DefaultUnLinkResponseCallback
	extends com.kakao.usermgmt.callback.UnLinkResponseCallback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSessionClosed:(Lcom/kakao/network/ErrorResult;)V:GetOnSessionClosed_Lcom_kakao_network_ErrorResult_Handler\n" +
			"n_onSuccess:(Ljava/lang/Long;)V:GetOnSuccess_Ljava_lang_Long_Handler\n" +
			"";
		mono.android.Runtime.register ("Com.Kakao.Usermgmt.Callback.DefaultUnLinkResponseCallback, Com.Kakao.Sdk.Usermgmt", DefaultUnLinkResponseCallback.class, __md_methods);
	}


	public DefaultUnLinkResponseCallback ()
	{
		super ();
		if (getClass () == DefaultUnLinkResponseCallback.class)
			mono.android.TypeManager.Activate ("Com.Kakao.Usermgmt.Callback.DefaultUnLinkResponseCallback, Com.Kakao.Sdk.Usermgmt", "", this, new java.lang.Object[] {  });
	}


	public void onSessionClosed (com.kakao.network.ErrorResult p0)
	{
		n_onSessionClosed (p0);
	}

	private native void n_onSessionClosed (com.kakao.network.ErrorResult p0);


	public void onSuccess (java.lang.Long p0)
	{
		n_onSuccess (p0);
	}

	private native void n_onSuccess (java.lang.Long p0);

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
