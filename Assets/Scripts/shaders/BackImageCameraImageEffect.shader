﻿Shader "Hidden/BackImageCameraImageEffect"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_MainColr("Color",Color)=(1,1,1,1)
		_LuminosityAmount("GrayScale Amount",Range(0.0,1)) = 1.0
	}
		SubShader
		{
			// No culling or depth
			Cull Off ZWrite Off ZTest Always

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"

				fixed _LuminosityAmount;

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			float4 _MainColor;
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				// just invert the colors
				
				col.rgb = col.rgb + _LuminosityAmount* _MainColor.rgb;
				return col;
			}
			ENDCG
		}
	}
}
