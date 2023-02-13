Shader "Car Parking/Mobile Specular Detail" {
Properties {
	_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
	_Shininess ("Shininess", Range (0.01, 1)) = 0.078125
	_MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}
	_SpecTex ("_SpecTex", 2D) = "white" {}
	_DetailTex ("_DetailTex", 2D) = "white" {}
	_SpecularPower("Specular Power",Float) = 4
	_DiffusePower("Diffuse Power",Float) = 1.4
}

SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 200
	
CGPROGRAM
#pragma surface surf BlinnPhong vertex:vert 

sampler2D _MainTex;
sampler2D _SpecTex;
float _Shininess;
sampler2D _DetailTex;
float _SpecularPower;

float _DiffusePower;

struct Input {
	float2 uv_MainTex;
	float2 customUV;    
};
void vert (inout appdata_full v, out Input o) {
          UNITY_INITIALIZE_OUTPUT(Input,o);
          o.customUV = v.texcoord.xy * 7;
      }



void surf (Input IN, inout SurfaceOutput o) 
{
	fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);

	fixed4 s_tex = tex2D(_SpecTex, IN.uv_MainTex);

	fixed4 d_tex = tex2D(_DetailTex, IN.customUV);

	o.Albedo = tex.rgb *d_tex.rgb*_DiffusePower;

	o.Gloss = s_tex.rgb*tex.a*d_tex.rgb*_SpecularPower;

	o.Specular = s_tex.rgb*_Shininess;


}
ENDCG
}

Fallback "Diffuse"
}
