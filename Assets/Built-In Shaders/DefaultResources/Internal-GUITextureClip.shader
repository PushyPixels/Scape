
Shader "Hidden/Internal-GUITextureClip" 
{
	Properties { _MainTex ("Texture", Any) = "white" {} }

	SubShader {

		Tags { "ForceSupported" = "True" }

		Lighting Off 
		Blend SrcAlpha OneMinusSrcAlpha 
		Cull Off 
		ZWrite Off 
		Fog { Mode Off } 
		ZTest Always

		Pass {	
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata_t {
				float4 vertex : POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
				fixed4 color : COLOR;
				float2 texcoord : TEXCOORD0;
				float2 texgencoord : TEXCOORD1;
			};

			sampler2D _MainTex;
			sampler2D _GUIClipTexture;

			uniform float4 _MainTex_ST;
			uniform fixed4 _Color;
			uniform float4x4 _GUIClipTextureMatrix;
			
			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				float4 texgen = mul(UNITY_MATRIX_MV, v.vertex);
				o.texgencoord = mul(_GUIClipTextureMatrix, texgen);
				o.color = v.color;
				o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
				return o;
			}

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.texcoord) * i.color;
				col.a *= tex2D(_GUIClipTexture, i.texgencoord).a;
				return col;
			}
			ENDCG 
		}
	}
}
