Shader "Custom/GradientVerticalSpecularScliced" {
Properties {
	_Color ("Top Color", Color) = (1,1,1,1)
	_Color2 ("Bottom Color", Color) = (1,1,1,1)
	_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
	_Shininess ("Shininess", Range (0.01, 1)) = 0.078125
    _Frequency ("Clip Frequency", Range(0,10)) = 5.0
    _Offset ("Clip Offset", Range(0,1)) = 0
    _Percentage ("Fill Percentage", Range(1,0)) = 0.5
}

SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 300
	
CGPROGRAM
#pragma surface surf BlinnPhong vertex:vert

sampler2D _MainTex;
fixed4 _Color;
fixed4 _Color2;
half _Shininess;
      float _Frequency;
      float _Offset;
     float _Percentage;

struct Input {
	float2 uv_MainTex;
	float3 objPos;
};

      void vert (inout appdata_full v, out Input o) {
            UNITY_INITIALIZE_OUTPUT(Input,o);
            o.objPos = v.vertex;
      }

void surf (Input IN, inout SurfaceOutput o) {
    clip (frac((IN.objPos.y+_Offset) * _Frequency) - _Percentage);
	float2 screenUV = IN.objPos.xy;
	fixed4 c = lerp(_Color2, _Color, screenUV.y);
	o.Albedo = c.rgb;
	o.Alpha = c.a;
	o.Gloss = 1.0;
	o.Specular = _Shininess;
	o.Emission = c.rgb;
}
ENDCG
}

Fallback "VertexLit"
}
