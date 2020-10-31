Shader "Scrolling shader"
{
	Properties
	{
		_Texture0("Texture 0", 2D) = "white" {}
		_Vector0("Vector 0", Vector) = (0,3,0,0)
		_Float0("Float 0", Range( 0 , 1)) = 0.5
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard alpha:fade keepalpha noshadow exclude_path:deferred 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _Texture0;
		uniform float2 _Vector0;
		uniform float4 _Texture0_ST;
		uniform float _Float0;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv0_Texture0 = i.uv_texcoord * _Texture0_ST.xy + _Texture0_ST.zw;
			float2 panner3 = ( 1.0 * _Time.y * _Vector0 + uv0_Texture0);
			float4 tex2DNode9 = tex2D( _Texture0, panner3 );
			o.Albedo = tex2DNode9.rgb;
			o.Emission = ( tex2DNode9 * float4(0.5,0.5,0.5,0.5) ).rgb;
			o.Alpha = _Float0;
		}

		ENDCG
	}
}
