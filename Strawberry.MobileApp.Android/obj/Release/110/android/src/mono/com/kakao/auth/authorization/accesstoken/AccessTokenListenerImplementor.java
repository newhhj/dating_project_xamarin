package mono.com.kakao.auth.authorization.accesstoken;


public class AccessTokenListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.kakao.auth.authorization.accesstoken.AccessTokenListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAccessTokenFailure:(Lcom/kakao/network/ErrorResult;)V:GetOnAccessTokenFailure_Lcom_kakao_network_ErrorResult_Handler:Com.Kakao.Auth.Authorization.Accesstoken.IAccessTokenListenerInvoker, Com.Kakao.Sdk.Auth\n" +
			"n_onAccessTokenReceived:(Lcom/kakao/auth/authorization/accesstoken/AccessToken;)V:GetOnAccessTokenReceived_Lcom_kakao_auth_authorization_accesstoken_AccessToken_Handler:Com.Kakao.Auth.Authorization.Accesstoken.IAccessTokenListenerInvoker, Com.Kakao.Sdk.Auth\n" +
			"";
		mono.android.Runtime.register ("Com.Kakao.Auth.Authorization.Accesstoken.IAccessTokenListenerImplementor, Com.Kakao.Sdk.Auth", AccessTokenListenerImplementor.class, __md_methods);
	}


	public AccessTokenListenerImplementor ()
	{
		super ();
		if (getClass () == AccessTokenListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Kakao.Auth.Authorization.Accesstoken.IAccessTokenListenerImplementor, Com.Kakao.Sdk.Auth", "", this, new java.lang.Object[] {  });
	}


	public void onAccessTokenFailure (com.kakao.network.ErrorResult p0)
	{
		n_onAccessTokenFailure (p0);
	}

	private native void n_onAccessTokenFailure (com.kakao.network.ErrorResult p0);


	public void onAccessTokenReceived (com.kakao.auth.authorization.accesstoken.AccessToken p0)
	{
		n_onAccessTokenReceived (p0);
	}

	private native void n_onAccessTokenReceived (com.kakao.auth.authorization.accesstoken.AccessToken p0);

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
