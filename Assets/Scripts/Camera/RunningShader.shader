Shader "Unlit/RunningShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _MotionBlurStrength ("Motion Blur Strength", Range(0, 1)) = 0.5 // Define a força do efeito de correr
        _BlurAmount ("Blur Amount", Range(0, 1)) = 0.5 // Define a quantidade de desfoque nas áreas laterais
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always
        
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
                float3 vertexWorldPos : TEXCOORD1;
            };
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.vertexWorldPos = mul(unity_ObjectToWorld, v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            sampler2D _MainTex;
            float _MotionBlurStrength; // Intensidade do efeito
            float _BlurAmount; // Quantidade de desfoque nas áreas laterais
            
            float4 frag (v2f i) : SV_Target
            {
                // Ler a cor original do pixel
                fixed4 col = tex2D(_MainTex, i.uv);
                
                // Calcular o vetor deslocamento multiplicando as coordenadas de textura pela intensidade do efeito
                float2 displacement = i.uv * _MotionBlurStrength;
                
                // Calcular as coordenadas de textura deslocadas (displacedUV) para aplicar o efeito de deslocamento
                float2 displacedUV = i.uv - displacement;
                
                // Posição do centro do ecra
                float2 center = float2(0.5, 0.5); 

                // Calcular a distância entre a coordenada atual e o centro
                float distanceFromCenter = distance(i.uv, center);
                
                // Aplicar um desfoque com base na distância ao centro
                float blurFactor = smoothstep(1.0 - _BlurAmount, 1.0, distanceFromCenter);
                
                // Obter a cor deslocada do pixel
                fixed4 displacedColor = tex2D(_MainTex, displacedUV);
                
                // Misturar as cores original e deslocada com base na intensidade do efeito de correr e desfoque calculado anteriormente
                col = lerp(col, displacedColor, _MotionBlurStrength * blurFactor);
                
                return col;
            }
            ENDCG
        }
    }
}