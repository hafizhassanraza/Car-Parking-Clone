	Shader "Car Parking/Mobile Water Color" 
	{
	Properties
	 {
		_Color ("Main Color", Color) = (1,1,1,1)
		_SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
		_Shininess ("Shininess", Range (0.01, 1)) = 0.078125
		_MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}
		_SpecTex ("_SpecTex", 2D) = "white" {}
		_Cube ("Cubemap", 2D) = "" {}
		_CubePower("CubePower",Float) = 3
		_WaveHeight("Wave Height",Float) = .07
		_WaveSpeed("Wave Speed",Float) = 14
		_WaveCount("Wave Count",Float) = 30


	}

SubShader {

	Tags { "RenderType"="Opaque" }


	CGPROGRAM

	#pragma surface surf BlinnPhong vertex:vert

	sampler2D _MainTex;
	sampler2D _SpecTex;
	half _Shininess;
	sampler2D _Cube;
	half _CubePower;
	half4 _Color;

	half _WaveHeight;
	half _WaveSpeed;
	half _WaveCount;

	struct Input {
		float2 uv_MainTex;
		float2 uv_SpecTex;
		float3 worldRefl;
		half3 vDir : TEXCOORD2;
	};

	void vert (inout appdata_full v, out Input o){   
	UNITY_INITIALIZE_OUTPUT(Input,o);
	    float phase = _Time * _WaveSpeed;
	    float offset = (v.vertex.x * (v.vertex.z * 0.2)) * _WaveCount;
	    v.vertex.y = sin(phase + offset) * _WaveHeight;

	     o.vDir = normalize( ObjSpaceViewDir(v.vertex) ).xzy;
	}

		void surf (Input IN, inout SurfaceOutput o) {
		
		half4 tex = tex2D(_MainTex, IN.uv_MainTex);
		half4 s_tex = tex2D(_SpecTex, IN.uv_SpecTex);

		half2 worldRefl = WorldReflectionVector (IN, o.normal);
		half2 R = IN.vDir - ( 2 * dot(IN.vDir, o.Normal )) * o.Normal;
	    half4 reflcol = tex2D (_Cube, R);

		o.Albedo = tex.rgb *_Color.rgb*4;

		o.Gloss = s_tex.rgb*tex.a*2;

		o.Specular = s_tex.rgb*_Shininess;   

		o.Emission = (reflcol.rgb*_CubePower)*s_tex.rgb;

		}

		ENDCG   
	}

	Fallback "Diffuse"
}
