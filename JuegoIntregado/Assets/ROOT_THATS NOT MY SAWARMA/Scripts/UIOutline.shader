Shader "UI/Outline"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _OutlineColor ("Outline Color", Color) = (1,1,0,1)
        _OutlineSize ("Outline Size", Float) = 2
    }

    SubShader
    {
        Tags { "Queue"="Transparent" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _OutlineColor;
            float _OutlineSize;

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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                float4 col = tex2D(_MainTex, i.uv);

                float alpha = col.a;

                float outline = 0;

                outline += tex2D(_MainTex, i.uv + float2(_OutlineSize/1000, 0)).a;
                outline += tex2D(_MainTex, i.uv - float2(_OutlineSize/1000, 0)).a;
                outline += tex2D(_MainTex, i.uv + float2(0, _OutlineSize/1000)).a;
                outline += tex2D(_MainTex, i.uv - float2(0, _OutlineSize/1000)).a;

                if (alpha < 0.1 && outline > 0.1)
                    return _OutlineColor;

                return col;
            }
            ENDCG
        }
    }
}
