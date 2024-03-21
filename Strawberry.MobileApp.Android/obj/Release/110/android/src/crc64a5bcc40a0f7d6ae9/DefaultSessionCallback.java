package crc64a5bcc40a0f7d6ae9;


public class DefaultSessionCallback
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.kakao.auth.ISessionCallback
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSessionOpenFailed:(Lcom/kakao/util/exception/KakaoException;)V:GetOnSessionOpenFailed_Lcom_kakao_util_exception_KakaoException_Handler:Com.Kakao.Auth.ISessionCallbackInvoker, Com.Kakao.Sdk.Auth\n" +
			"n_onSessionOpened:()V:GetOnSessionOpenedHandler:Com.Kakao.Auth.ISessionCallbackInvoker, Com.Kakao.Sdk.Auth\n" +
			"";
		mono.android.Runtime.register ("Com.Kakao.Auth.DefaultSessionCallback, Com.Kakao.Sdk.Auth", DefaultSessionCallback.class, __md_methods);
	}


	public DefaultSessionCallback ()
	{
		super ();
		if (getClass () == DefaultSessionCallback.class)
			mono.android.TypeManager.Activate ("Com.Kakao.Auth.DefaultSessionCallback, Com.Kakao.Sdk.Auth", "", this, new java.lang.Object[] {  });
	}


	public void onSessionOpenFailed (com.kakao.util.exception.KakaoException p0)
	{
		n_onSessionOpenFailed (p0);
	}

	private native void n_onSessionOpenFailed (com.kakao.util.exception.KakaoException p0);


	public void onSessionOpened ()
	{
		n_onSessionOpened ();
	}

	private native void n_onSessionOpened ();

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
