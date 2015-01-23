Shader "ScreenSpaceGradientVerticalSpecular" {
Properties {
	_Color ("Top Color", Color) = (1,1,1,1)
	_Color2 ("Bottom Color", Color) = (1,1,1,1)
	_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
	_Shininess ("Shininess", Range (0.01, 1)) = 0.078125
}

SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 300
	
CGPROGRAM
#pragma surface surf BlinnPhong

sampler2D _MainTex;
fixed4 _Color;
fixed4 _Color2;
half _Shininess;

struct Input {
	float2 uv_MainTex;
	float4 screenPos;
};

void surf (Input IN, inout SurfaceOutput o) {
	float2 screenUV = IN.screenPos.xy / IN.screenPos.w;
	fixed4 c = lerp(_Color2, _Color, screenUV.y);
	o.Albedo = c.rgb;
	o.Alpha = c.a;
	o.Gloss = 1.0;
	o.Specular = _Shininess;
}
ENDCG
}

Fallback "VertexLit"
}
