package crc648bfb30e6f00b1c88;


public class DefaultMeV2ResponseCallback
	extends com.kakao.usermgmt.callback.MeV2ResponseCallback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSuccess:(Lcom/kakao/usermgmt/response/MeV2Response;)V:GetOnSuccess_Lcom_kakao_usermgmt_response_MeV2Response_Handler\n" +
			"n_onSessionClosed:(Lcom/kakao/network/ErrorResult;)V:GetOnSessionClosed_Lcom_kakao_network_ErrorResult_Handler\n" +
			"n_onFailure:(Lcom/kakao/network/ErrorResult;)V:GetOnFailure_Lcom_kakao_network_ErrorResult_Handler\n" +
			"";
		mono.android.Runtime.register ("Com.Kakao.Usermgmt.Callback.DefaultMeV2ResponseCallback, Com.Kakao.Sdk.Usermgmt", DefaultMeV2ResponseCallback.class, __md_methods);
	}


	public DefaultMeV2ResponseCallback ()
	{
		super ();
		if (getClass () == DefaultMeV2ResponseCallback.class)
			mono.android.TypeManager.Activate ("Com.Kakao.Usermgmt.Callback.DefaultMeV2ResponseCallback, Com.Kakao.Sdk.Usermgmt", "", this, new java.lang.Object[] {  });
	}


	public void onSuccess (com.kakao.usermgmt.response.MeV2Response p0)
	{
		n_onSuccess (p0);
	}

	private native void n_onSuccess (com.kakao.usermgmt.response.MeV2Response p0);


	public void onSessionClosed (com.kakao.network.ErrorResult p0)
	{
		n_onSessionClosed (p0);
	}

	private native void n_onSessionClosed (com.kakao.network.ErrorResult p0);


	public void onFailure (com.kakao.network.ErrorResult p0)
	{
		n_onFailure (p0);
	}

	private native void n_onFailure (com.kakao.network.ErrorResult p0);

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
