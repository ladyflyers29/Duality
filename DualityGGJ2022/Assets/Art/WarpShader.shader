Shader "Unlit/WarpShader" {
    Properties {
        //_MainTex ("Texture", 2D) = "white" {}
        _FresnelExp ("FresnelExp", float) = 1
        _FresnelCenter ("FresnelCenter", float) = 1
        _FresnelEdge ("FresnelEdge", float) = 1
        [HDR]_CenterCol ("CenterCol", Color) = (1,1,1,1)
        [HDR]_EdgeCol ("EdgeCol", Color) = (1,1,1,1)
        _DarkCenter ("DarkCenter", float) = 0
    }
    SubShader {
        Tags { "RenderType"="Transparent" }
        LOD 100

        GrabPass {
            "_GrabTexture"
        }

        Pass {
            CGPROGRAM
// Upgrade NOTE: excluded shader from DX11; has structs without semantics (struct appdata members worldNormal)
#pragma exclude_renderers d3d11
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f {
                float4 vertex : SV_POSITION;
                float fresnel : TEXCOORD0;
                half4 wpos      : TEXCOORD1;
                half3 normal : NORMAL;
                half3 viewDir : TEXCOORD2;
                half4 screenPos : TEXCOORD3;
            };

            sampler2D _GrabTexture;
            float _FresnelExp;
            float _FresnelCenter;
            float4 _CenterCol;
            float _FresnelEdge;
            float4 _EdgeCol;
            float _DarkCenter;

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = normalize( mul( v.normal, (half3x3)unity_WorldToObject ) );
                o.wpos = mul( unity_ObjectToWorld, (v.vertex) );
                o.screenPos = ComputeScreenPos(o.vertex);
                o.viewDir = normalize(UnityWorldSpaceViewDir(o.wpos));
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                i.normal = normalize(i.normal);
                float fresnel = saturate( dot(i.normal, i.viewDir) );
                float fresnelWarp = pow( fresnel, _FresnelExp );
                float fresnelCenter = pow( fresnel, _FresnelCenter );
                float fresnelEdge = pow( fresnel, _FresnelEdge );

                float2 screenUV = i.screenPos.xy / i.screenPos.w;
			    half4 c = tex2D (_GrabTexture, screenUV + fresnelWarp);

                if (_DarkCenter > 0.5) {
                    c += (fresnelCenter * _CenterCol);
                }
                else {
                    c *= ( (1-fresnelCenter) * _CenterCol);
                }
                c += ((1-fresnelEdge) * _EdgeCol);
                return saturate(c);//fixed4( fresnel,0,0, 0 );
            }
            ENDCG
        }
    }
}
