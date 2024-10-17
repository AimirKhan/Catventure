Shader "UI/Gradient"
{
    Properties
    {
        _ColorStart ("Color Start", Color) = (1,0,0,1)
        _ColorEnd ("Color End", Color) = (0,0,1,1)
    }
    SubShader
    {
        Tags
        {
            "Queue"="Overlay"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
        }
        Pass
        {
            Name "Gradient"
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            fixed4 _ColorStart;
            fixed4 _ColorEnd;

            v2f vert (appdata_t v)
            {
                v2f output;
                output.vertex = UnityObjectToClipPos(v.vertex);
                output.uv = v.uv;
                return output;
            }

            fixed4 frag (v2f input) : SV_Target
            {
                fixed4 color = lerp(_ColorStart, _ColorEnd, input.uv.y);
                return color;
            }
            ENDHLSL
        }
    }
    Fallback "UI/Default"
}
