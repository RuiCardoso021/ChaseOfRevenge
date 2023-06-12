Shader "ShaderByCardoso/BlinkingRotatingShader"
{
    Properties
    {
        _MainTex("Main Texture", 2D) = "white" {}
        _Color("Primary Color", Color) = (1, 1, 1, 1)
        _Color2("Secoundary Color", Color) = (1, 1, 1, 1)
        _BlinkSpeed("Blink Speed", Range(0, 200)) = 50
        _RotationSpeed("Rotation Speed", Range(0, 50)) = 10
        _WaveFrequency("Wave Frequency", Range(0, 100)) = 50
        _WaveAmplitude("Wave Amplitude", Range(0, 1)) = 0.1
    }

        SubShader
        {
            Tags { "RenderType" = "Opaque" }
            Cull Back
            Lighting Off

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
                float4 _Color;
                float4 _Color2;
                float _BlinkSpeed;
                float _RotationSpeed;
                float _WaveFrequency;
                float _WaveAmplitude;

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);

                    // Aplica efeito de ondulação aos vértices
                    float wave = sin(_Time * _WaveFrequency + v.vertex.y) * _WaveAmplitude;
                    o.vertex.y += wave;

                    // Apply rotation to UV coordinates using _Time
                    float rotationAngle = _Time * _RotationSpeed;
                    float2 center = 0.5;
                    float2 rotatedUV = float2(cos(rotationAngle), sin(rotationAngle)) * (v.uv - center) + center;

                    o.uv = rotatedUV;
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    fixed4 texColor = tex2D(_MainTex, i.uv);
                    fixed4 finalColor = texColor * _Color;

                    // Piscar usando o tempo (_BlinkSpeed)
                    float blink = frac(_Time * _BlinkSpeed);
                    if (blink > 0.5)
                        finalColor = texColor * _Color2;
                   
                    // Mantém a transparência original da textura
                    finalColor.a = texColor.a; 

                    return finalColor;
                }
                ENDCG
            }
        }
}
