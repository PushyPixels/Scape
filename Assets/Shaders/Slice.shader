﻿Shader "Example/Slices" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
      _BumpMap ("Bumpmap", 2D) = "bump" {}
      _Frequency ("Clip Frequency", Range(0,10)) = 5.0
      _Offset ("Clip Offset", Range(0,1)) = 0
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      Cull Off
      CGPROGRAM
      #pragma surface surf Lambert vertex:vert
      struct Input {
          float2 uv_MainTex;
          float2 uv_BumpMap;
          float3 worldPos;
          float3 objPos;
      };
      sampler2D _MainTex;
      sampler2D _BumpMap;
      float _Frequency;
      float _Offset;
      
      void vert (inout appdata_full v, out Input o) {
            UNITY_INITIALIZE_OUTPUT(Input,o);
            o.objPos = v.vertex;
      }
      
      void surf (Input IN, inout SurfaceOutput o) {
      
          clip (frac((IN.objPos.y+_Offset) * _Frequency) - 0.5);
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
          o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }
  