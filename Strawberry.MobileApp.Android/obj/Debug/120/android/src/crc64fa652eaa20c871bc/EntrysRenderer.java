package crc64fa652eaa20c871bc;


public class EntrysRenderer
	extends crc643f46942d9dd1fff9.EntryRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Strawberry.MobileApp.Droid.Renderers.EntrysRenderer, Strawberry.MobileApp.Android", EntrysRenderer.class, __md_methods);
	}


	public EntrysRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == EntrysRenderer.class) {
			mono.android.TypeManager.Activate ("Strawberry.MobileApp.Droid.Renderers.EntrysRenderer, Strawberry.MobileApp.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}


	public EntrysRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == EntrysRenderer.class) {
			mono.android.TypeManager.Activate ("Strawberry.MobileApp.Droid.Renderers.EntrysRenderer, Strawberry.MobileApp.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public EntrysRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == EntrysRenderer.class) {
			mono.android.TypeManager.Activate ("Strawberry.MobileApp.Droid.Renderers.EntrysRenderer, Strawberry.MobileApp.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}

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
