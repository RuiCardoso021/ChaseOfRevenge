Shader "Custom/hologram" {
    Properties{
        // holo
        _RimColor("Rim Color", Color) = (1, 1, 1, 1)
        _RimColor2("rim color2", Color) = (1,1,1,1)
        _Albedo("Albedo", 2D) = "defaulttexture" {}
        _Exponential("Exponential", Range(-5, 10)) = 1
        _Exponential2("Exponential2", Range(-5, 100)) = 1
        _Controlador("controlador", Range(-1, 1)) = 1

        //dissolve
        _DissolveTexture("Dissolve Texture", 2D) = "whitetexture" {}
        _DissolveAmount("Dissolve Amount", Range(0, 1)) = 0
    }

        SubShader{
            Tags { "RenderType" = "Opaque" }
            LOD 200

            CGPROGRAM
            #pragma surface surf Lambert alpha:fade

            struct Input {
                float2 uv_Albedo;
                float3 viewDir;
                float2 uv_Text;
            };

            // holo
            sampler2D _Albedo;
            float4 _RimColor;
            float4 _RimColor2;
            float _Exponential;
            float _Exponential2;
            float _Controlador;

            //dissolve
            sampler2D _DissolveTexture;
            float _DissolveAmount;

            void surf(Input IN, inout SurfaceOutput o) {
                // Sample the dissolve texture
                float dissolveValue = tex2D(_DissolveTexture, IN.uv_Albedo).r;

                // Calculate dissolve factor based on the dissolve amount and dissolve texture
                float dissolveFactor = step(dissolveValue, _DissolveAmount);

                // Calculate dot product
                float dotProduct = pow(1 - dot(normalize(IN.viewDir), o.Normal), _Exponential);
                float3 crossP = cross(normalize(IN.viewDir).xyz, o.Normal.xyz);

                // Apply colors and dissolve factor
                float3 rimColor = _RimColor.rgb * dotProduct;
                o.Emission = rimColor;
                o.Albedo = lerp(tex2D(_Albedo, IN.uv_Albedo).rgb, rimColor, dissolveFactor);
                o.Alpha = crossP * (1 - dissolveFactor);
            }

            ENDCG
        }
            FallBack "Diffuse"
}
