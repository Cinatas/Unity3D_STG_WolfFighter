Shader "Hidden/ScreenMelt"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_MeltTex("Melt Texture",2D) = "white"{}
		_Melt("Melt Intensity",Range(0,1)) = 0
		_MeltEdge("Melt Edge",2D) = "white"{}
		_ScreenMask("GameOver",2D) = "black"{}
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
			#pragma fragmentoption ARB_precision_hint_fastest
			#include "UnityCG.cginc"

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
			sampler2D _MeltTex;
			sampler2D _MeltEdge;
			sampler2D _ScreenMask;
			fixed _Melt;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				fixed4 clipTex = tex2D(_MeltTex,i.uv);
				fixed4 EdgeTex = tex2D(_MeltEdge,i.uv);
				fixed4 gameoverTex = tex2D(_ScreenMask,i.uv);
				fixed clipF = clipTex.r - _Melt + 0.05;

				if(clipF<0.05 && clipF>0){
					col = EdgeTex;
				}else if(clipF<=0){
					col = gameoverTex;
				}

				return col;
			}
			ENDCG
		}
	}
}
