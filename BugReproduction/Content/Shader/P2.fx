#if OPENGL
#define SV_POSITION POSITION
#define VS_SHADERMODEL vs_3_0
#define PS_SHADERMODEL ps_3_0
#else
#define VS_SHADERMODEL vs_4_0_level_9_1
#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

sampler TextureSampler : register(s0);

float2 RumbleVectorR;
float2 RumbleVectorG;
float2 RumbleVectorB;
struct VertexShaderOutput
{
	float4 Position : TEXCOORD0;
	float4 Color : COLOR0;
};

float4 RumblePS(VertexShaderOutput input) : COLOR
{
	return float4(1,1,1,1); // This should just return white pixel
//float value = (0.5 + (frac(sin(dot(input.Position.xy ,float2(12.9898,78.233))) * 43758.5453))*0.5);
//return float4(0, 1, 0, 1);
};

technique RetroDrawing
{
	pass P0
	{
		PixelShader = compile PS_SHADERMODEL RumblePS();
	}
};