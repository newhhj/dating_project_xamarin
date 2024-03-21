package crc64a5bcc40a0f7d6ae9;


public class DefaultKakaoAdapter
	extends com.kakao.auth.KakaoAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getApplicationConfig:()Lcom/kakao/auth/IApplicationConfig;:GetGetApplicationConfigHandler\n" +
			"n_getSessionConfig:()Lcom/kakao/auth/ISessionConfig;:GetGetSessionConfigHandler\n" +
			"";
		mono.android.Runtime.register ("Com.Kakao.Auth.DefaultKakaoAdapter, Com.Kakao.Sdk.Auth", DefaultKakaoAdapter.class, __md_methods);
	}


	public DefaultKakaoAdapter ()
	{
		super ();
		if (getClass () == DefaultKakaoAdapter.class)
			mono.android.TypeManager.Activate ("Com.Kakao.Auth.DefaultKakaoAdapter, Com.Kakao.Sdk.Auth", "", this, new java.lang.Object[] {  });
	}

	public DefaultKakaoAdapter (com.kakao.auth.AuthType[] p0)
	{
		super ();
		if (getClass () == DefaultKakaoAdapter.class)
			mono.android.TypeManager.Activate ("Com.Kakao.Auth.DefaultKakaoAdapter, Com.Kakao.Sdk.Auth", "Com.Kakao.Auth.AuthType[], Com.Kakao.Sdk.Auth", this, new java.lang.Object[] { p0 });
	}


	public com.kakao.auth.IApplicationConfig getApplicationConfig ()
	{
		return n_getApplicationConfig ();
	}

	private native com.kakao.auth.IApplicationConfig n_getApplicationConfig ();


	public com.kakao.auth.ISessionConfig getSessionConfig ()
	{
		return n_getSessionConfig ();
	}

	private native com.kakao.auth.ISessionConfig n_getSessionConfig ();

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
