Shader "Custom/Foreground" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
	[MaterialToggle] PixelSnap("Pixel snap", Float) = 0
		_ignore("Ignore", Range(0, 1)) = 0
	}
	SubShader {

		Tags
	{ 
		"RenderType" = "Transparent" 
		"Queue" = "Transparent+2" 
		"IgnoreProjector" = "True"
		"PreviewType" = "Plane"
		"CanUseSpriteAtlas" = "True"
	}
		LOD 200


		Cull Off
		Lighting Off

		ZWrite Off
		Blend One OneMinusSrcAlpha

		ZTest Always
		
		CGPROGRAM
#pragma surface surf Lambert vertex:vert nofog keepalpha
#pragma multi_compile _ PIXELSNAP_ON

		sampler2D _MainTex;
	fixed4 _Color;
	sampler2D _AlphaTex;
	float _AlphaSplitEnabled;
	float _ignore;


	struct Input
	{
		float2 uv_MainTex;
		fixed4 color;
	};

	void vert(inout appdata_full v, out Input o)
	{
#if defined(PIXELSNAP_ON)
		v.vertex = UnityPixelSnap(v.vertex);
#endif

		UNITY_INITIALIZE_OUTPUT(Input, o);
		o.color = v.color * _Color;
	}

	fixed4 SampleSpriteTexture(float2 uv)
	{
		fixed4 color = tex2D(_MainTex, uv);

#if UNITY_TEXTURE_ALPHASPLIT_ALLOWED
		if (_AlphaSplitEnabled)
		{
			color.a = tex2D(_AlphaTex, uv).r;
		}
#endif //UNITY_TEXTURE_ALPHASPLIT_ALLOWED

		return color;
	}

	void surf(Input IN, inout SurfaceOutput o)
	{
		fixed4 c = SampleSpriteTexture(IN.uv_MainTex) * IN.color;

		if(c.b >= _ignore && c.r >= _ignore && c.g >= _ignore)
		{
			c = float4(0, 0, 0, 0);
		}

		o.Albedo = c.rgb * c.a;
		o.Alpha = c.a;
	}
	ENDCG
	}
	FallBack "Diffuse"
}
