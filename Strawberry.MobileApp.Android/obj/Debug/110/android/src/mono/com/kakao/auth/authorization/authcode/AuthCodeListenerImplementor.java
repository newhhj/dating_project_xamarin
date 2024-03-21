package mono.com.kakao.auth.authorization.authcode;


public class AuthCodeListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.kakao.auth.authorization.authcode.AuthCodeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAuthCodeReceived:(ILcom/kakao/auth/authorization/AuthorizationResult;)V:GetOnAuthCodeReceived_ILcom_kakao_auth_authorization_AuthorizationResult_Handler:Com.Kakao.Auth.Authorization.Authcode.IAuthCodeListenerInvoker, Com.Kakao.Sdk.Auth\n" +
			"";
		mono.android.Runtime.register ("Com.Kakao.Auth.Authorization.Authcode.IAuthCodeListenerImplementor, Com.Kakao.Sdk.Auth", AuthCodeListenerImplementor.class, __md_methods);
	}


	public AuthCodeListenerImplementor ()
	{
		super ();
		if (getClass () == AuthCodeListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Kakao.Auth.Authorization.Authcode.IAuthCodeListenerImplementor, Com.Kakao.Sdk.Auth", "", this, new java.lang.Object[] {  });
	}


	public void onAuthCodeReceived (int p0, com.kakao.auth.authorization.AuthorizationResult p1)
	{
		n_onAuthCodeReceived (p0, p1);
	}

	private native void n_onAuthCodeReceived (int p0, com.kakao.auth.authorization.AuthorizationResult p1);

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
