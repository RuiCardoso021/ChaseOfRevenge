Shader "Custom/AndrePortal"
{
    Properties
    {
        _Color("Color", Color) = (1, 1, 1, 1)
        _MainTex("Texture", 2D) = "white" {}
        _DissolveAmount("Dissolve Amount", Range(0, 1)) = 0
        _DissolveStartPoint("Dissolve Start Point", Vector) = (0, 0, 0, 0)
        _OtherTex("Other Texture", 2D) = "white" {}
    }

        SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 200
        Cull Off

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        sampler2D _OtherTex;
        half _DissolveAmount;
        float4 _DissolveStartPoint;
        fixed4 _Color;

        struct Input
        {
            float2 uv_MainTex;
            float3 worldPos;
        };

        void surf(Input IN, inout SurfaceOutput o)
        {
            // Calculate distance from the dissolve start point
            float distanceFromStart = distance(_DissolveStartPoint.xyz, float3(IN.uv_MainTex, 0));

            // Calculate dissolve factor based on the distance
            float dissolveFactor = smoothstep(0, _DissolveAmount, distanceFromStart);

            // Sample the dissolve texture and the other texture
            fixed4 dissolveTexColor = tex2D(_MainTex, IN.uv_MainTex);
            fixed4 otherTexColor = tex2D(_OtherTex, IN.uv_MainTex);

            // Mix the colors based on the dissolve factor
            fixed4 mixedColor = lerp(dissolveTexColor, otherTexColor, dissolveFactor);

            // Set the final color and alpha
            o.Albedo = mixedColor.rgb;
            o.Alpha = mixedColor.a * (1 - dissolveFactor);

            // Calculate emission based on dissolve value
            half dissolve_value = dissolveTexColor.r;
            clip(dissolve_value - _DissolveAmount);
            o.Emission = fixed3(1, 1, 1) * step(dissolve_value - _DissolveAmount, 0.05f);

            // Apply texture to the mixed color
            o.Albedo *= mixedColor.rgb;
        }
        ENDCG
    }

        FallBack "Diffuse"
}
