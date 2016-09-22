// Copyright (c) 2016 Jacob Maximilian Fober
//
// Licensed under the Creative Commons License,
// Attribution 4.0 International (CC BY 4.0) (the "License");
// you can use this file in compliance with the License.
// You may obtain a copy of the License at
//
// https://creativecommons.org/licenses/by/4.0/
//

//
// Spherical Perspective Shader in CgFx for Unity v0.8.2a
//

Shader "JMF/SphericalPerspective and Normal"
{
	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct v2f
			{
				float4 pos : SV_POSITION;
				fixed4 color : COLOR;
			};

			v2f vert ( appdata_base v )
			{
				v2f o;

				float4 vertPos = mul( UNITY_MATRIX_MV, v.vertex );
				float dist = distance( float4( 0.0f, -5.0f, 0.0f, 1.0f ), vertPos );

				if( vertPos.z > 0.0f )
				{
					vertPos.z = 4.0f * vertPos.z - dist; //Fulldome perspective
					//vertPos.z = 1.5f * vertPos.z - 0.5f * dist;

				} else {
					vertPos.z = -dist; //Fulldome perspective
					//vertPos.z = ( vertPos.z - dist ) * 0.5f;
				}

				o.pos = mul ( UNITY_MATRIX_P, vertPos );

				o.color.xyz = v.normal * 0.5f + 0.5f;
				o.color.w = 1.0f;
				return o;
			}

			fixed4 frag ( v2f i ) : SV_Target { return i.color; }
			ENDCG
		}
	}
}