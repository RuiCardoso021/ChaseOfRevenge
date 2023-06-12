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
            float _MotionBlurStrength; // Força do efeito de correr
            float _BlurAmount; // Quantidade de desfoque nas áreas laterais
            
            float4 frag (v2f i) : SV_Target
            {
                // Ler a cor original do pixel
                fixed4 col = tex2D(_MainTex, i.uv);
                
                // Calcular o vetor de deslocamento
                float2 displacement = i.uv * _MotionBlurStrength;
                
                // Aplicar o efeito de correr deslocando o UV
                float2 displacedUV = i.uv - displacement;
                
                // Calcular a distância do centro da tela
                float2 center = float2(0.5, 0.5); // Posição do centro da tela
                float distanceFromCenter = distance(i.uv, center);
                
                // Calcular o fator de desfoque com base na distância do centro
                float blurFactor = smoothstep(1.0 - _BlurAmount, 1.0, distanceFromCenter);
                
                // Ler a cor deslocada do pixel
                fixed4 displacedColor = tex2D(_MainTex, displacedUV);
                
                // Misturar as cores original e deslocada com base na força do efeito de correr e no fator de desfoque
                col = lerp(col, displacedColor, _MotionBlurStrength * blurFactor);
                
                return col;
            }
            ENDCG
        }
    }
}