Shader "Custom/AndrePortal"
{
    Properties{
        _MainTex("Texture", 2D) = "white" {}
        _DissolveAmount("Dissolve Amount", Range(0, 1)) = 0
        _DissolveStartPoint("Dissolve Start Point", Vector) = (0, 0, 0, 0)
    }

        SubShader{
            Tags { "RenderType" = "Opaque" }
            LOD 200

            CGPROGRAM
            #pragma surface surf Lambert

            sampler2D _MainTex;
            half _DissolveAmount;
            float4 _DissolveStartPoint;

            struct Input {
                float2 uv_MainTex;
            };

            void surf(Input IN, inout SurfaceOutput o) {
                // Calculate the distance from the dissolve start point
                float distanceFromStart = distance(_DissolveStartPoint.xyz, float3(IN.uv_MainTex, 0));

                // Calculate the dissolve factor based on the distance
                float dissolveFactor = smoothstep(0, _DissolveAmount, distanceFromStart);

                // Set the alpha channel based on the dissolve factor
                o.Alpha = 1 - dissolveFactor;

                // Sample the texture
                fixed4 c = tex2D(_MainTex, IN.uv_MainTex);

                // Apply the alpha value to the color
                c.rgb *= o.Alpha;

                // Set the output color
                o.Albedo = c.rgb;
            }
            ENDCG
        }
            FallBack "Diffuse"
}
