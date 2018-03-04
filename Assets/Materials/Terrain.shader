 Shader "Custom/Terrain" 
 {
   Properties 
   {
     _MainTex ("Base (RGB)", 2D) = "white" {}
     _HeightMin ("Height Min", Float) = -1
     _HeightMax ("Height Max", Float) = 1
     _ColorMin ("Tint Color At Min", Color) = (0,0,0,1)
     _ColorMax ("Tint Color At Max", Color) = (1,1,1,1)
   }
  
   SubShader
   {
     Tags { "RenderType"="Opaque" }
  
     CGPROGRAM
     #pragma surface surf Lambert
  
     sampler2D _MainTex;
     fixed4 _ColorMin;
     fixed4 _ColorMax;
     float _HeightMin;
     float _HeightMax;
  
     struct Input
     {
       float2 uv_MainTex;
       float3 worldPos;
     };
  
     void surf (Input IN, inout SurfaceOutput o) 
     {
       half4 c = tex2D (_MainTex, IN.uv_MainTex);
       float h = (_HeightMax-IN.worldPos.y) / (_HeightMax-_HeightMin);
       fixed4 tintColor = lerp(_ColorMax.rgba, _ColorMin.rgba, h);
       o.Albedo = c.rgb * tintColor.rgb;
       o.Alpha = c.a * tintColor.a;
     }
     ENDCG
   } 
   Fallback "Diffuse"
 }