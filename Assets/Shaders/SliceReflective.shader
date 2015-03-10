Shader "Custom/ReflectiveSpecularScliced" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
	_Shininess ("Shininess", Range (0.01, 1)) = 0.078125
	_ReflectColor ("Reflection Color", Color) = (1,1,1,0.5)
	_MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}
	_Cube ("Reflection Cubemap", Cube) = "_Skybox" { TexGen CubeReflect }
    _Frequency ("Clip Frequency", Range(0,10)) = 5.0
    _Offset ("Clip Offset", Range(0,1)) = 0
    _Percentage ("Fill Percentage", Range(1,0)) = 0.5
}
SubShader {
	LOD 300
	Tags { "RenderType"="Opaque" }
	Cull Off

CGPROGRAM
#pragma surface surf BlinnPhong vertex:vert
#pragma target 4.0

sampler2D _MainTex;
samplerCUBE _Cube;

fixed4 _Color;
fixed4 _ReflectColor;
half _Shininess;
float _Frequency;
float _Offset;
float _Percentage;

struct Input {
	float2 uv_MainTex;
	float3 worldRefl;
	float3 objPos;
};

      void vert (inout appdata_full v, out Input o) {
            UNITY_INITIALIZE_OUTPUT(Input,o);
            o.objPos = v.vertex;
      }

void surf (Input IN, inout SurfaceOutput o) {
	clip (frac((IN.objPos.y+_Offset) * _Frequency) - _Percentage);
	fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
	fixed4 c = tex * _Color;
	o.Albedo = c.rgb;
	o.Gloss = tex.a;
	o.Specular = _Shininess;
	
	fixed4 reflcol = texCUBE (_Cube, IN.worldRefl);
	reflcol *= tex.a;
	o.Emission = reflcol.rgb * _ReflectColor.rgb;
	o.Alpha = reflcol.a * _ReflectColor.a;
}
ENDCG
}

FallBack "Reflective/VertexLit"
}