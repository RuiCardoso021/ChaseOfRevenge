Shader "Custom/DamageEffect"
{
    Properties
    {
        _MainTex("Base (RGB)", 2D) = "white" {}
        _DamageColor("Damage Color", Color) = (1, 0, 0, 1)
        _DamageRadius("Damage Radius", Range(0, 1)) = 0.1
        _DamageIntensity("Damage Intensity", Range(0, 1)) = 1
    }

        SubShader
        {
            Tags { "RenderType" = "Opaque" }
            LOD 100

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                float4 _DamageColor;
                float _DamageRadius;
                float _DamageIntensity;

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    fixed4 col = tex2D(_MainTex, i.uv);
                    float2 screenCenter = float2(0.5, 0.5);
                    float2 uvFromCenter = abs(i.uv - screenCenter);
                    float distanceFromCenter = max(uvFromCenter.x, uvFromCenter.y);
                    float damageFactor = smoothstep(_DamageRadius - 0.05, _DamageRadius + 0.05, distanceFromCenter);
                    fixed4 damageColor = lerp(col, _DamageColor, damageFactor * _DamageIntensity);
                    return damageColor;
                }
                ENDCG
            }
        }
}
