//--------------------------------------------------------------
//
//                    Car Parking Kit
//          Writed by AliyerEdon in summer 2016
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This shader is for car back light intensity

Shader "Car Parking/Car BackLight" {
Properties {
	_MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}
	_Intensity("Light Intensity",Float) = 1
}
SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 200
	
CGPROGRAM
#pragma surface surf Lambert

sampler2D _MainTex;

fixed4 _Color;
half _Intensity;
struct Input {
	float2 uv_MainTex;
	float2 uv_Illum;
};

void surf (Input IN, inout SurfaceOutput o) {
	fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
	fixed4 c = tex;
	o.Albedo = c.rgb*_Intensity*3.4;
	o.Emission = c.rgb ;
}
ENDCG
} 
FallBack "Self-Illumin/VertexLit"
}
