package crc64a5bcc40a0f7d6ae9;


public class DefaultSessionConfig
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.kakao.auth.ISessionConfig
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getApprovalType:()Lcom/kakao/auth/ApprovalType;:GetGetApprovalTypeHandler:Com.Kakao.Auth.ISessionConfigInvoker, Com.Kakao.Sdk.Auth\n" +
			"n_isSaveFormData:()Z:GetIsSaveFormDataHandler:Com.Kakao.Auth.ISessionConfigInvoker, Com.Kakao.Sdk.Auth\n" +
			"n_isSecureMode:()Z:GetIsSecureModeHandler:Com.Kakao.Auth.ISessionConfigInvoker, Com.Kakao.Sdk.Auth\n" +
			"n_isUsingWebviewTimer:()Z:GetIsUsingWebviewTimerHandler:Com.Kakao.Auth.ISessionConfigInvoker, Com.Kakao.Sdk.Auth\n" +
			"n_getAuthTypes:()[Lcom/kakao/auth/AuthType;:GetGetAuthTypesHandler:Com.Kakao.Auth.ISessionConfigInvoker, Com.Kakao.Sdk.Auth\n" +
			"";
		mono.android.Runtime.register ("Com.Kakao.Auth.DefaultSessionConfig, Com.Kakao.Sdk.Auth", DefaultSessionConfig.class, __md_methods);
	}


	public DefaultSessionConfig ()
	{
		super ();
		if (getClass () == DefaultSessionConfig.class)
			mono.android.TypeManager.Activate ("Com.Kakao.Auth.DefaultSessionConfig, Com.Kakao.Sdk.Auth", "", this, new java.lang.Object[] {  });
	}

	public DefaultSessionConfig (com.kakao.auth.AuthType[] p0)
	{
		super ();
		if (getClass () == DefaultSessionConfig.class)
			mono.android.TypeManager.Activate ("Com.Kakao.Auth.DefaultSessionConfig, Com.Kakao.Sdk.Auth", "Com.Kakao.Auth.AuthType[], Com.Kakao.Sdk.Auth", this, new java.lang.Object[] { p0 });
	}


	public com.kakao.auth.ApprovalType getApprovalType ()
	{
		return n_getApprovalType ();
	}

	private native com.kakao.auth.ApprovalType n_getApprovalType ();


	public boolean isSaveFormData ()
	{
		return n_isSaveFormData ();
	}

	private native boolean n_isSaveFormData ();


	public boolean isSecureMode ()
	{
		return n_isSecureMode ();
	}

	private native boolean n_isSecureMode ();


	public boolean isUsingWebviewTimer ()
	{
		return n_isUsingWebviewTimer ();
	}

	private native boolean n_isUsingWebviewTimer ();


	public com.kakao.auth.AuthType[] getAuthTypes ()
	{
		return n_getAuthTypes ();
	}

	private native com.kakao.auth.AuthType[] n_getAuthTypes ();

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
