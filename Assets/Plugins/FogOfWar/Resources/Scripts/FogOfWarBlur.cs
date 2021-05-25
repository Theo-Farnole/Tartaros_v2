using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class FogOfWarBlur : MonoBehaviour
{
    [Range(0, 2)]
    public int downsample = 1;

    public enum BlurType
    {
        StandardGauss = 0,
        SgxGauss = 1,
    }

    [Range(0.0f, 10.0f)]
    public float blurSize = 1.0f;

    [Range(1, 4)]
    public int blurIterations = 1;

    public BlurType blurType = BlurType.StandardGauss;

    public Shader blurShader = null;
    private Material blurMaterial = null;

#pragma warning disable 414
    private bool supportHDRTextures = true;
    private bool supportDX11 = false;
#pragma warning restore 414

    private bool isSupported = true;


    private List<Material> createdMaterials = new List<Material>();

    protected void Start()
    {
        CheckResources();
    }

    void OnEnable()
    {
        blurShader = Shader.Find("Hidden/UltimateFogOfWar/FogBlur");
        isSupported = true;
    }

    void OnDestroy()
    {
        RemoveCreatedMaterials();
    }

    private void RemoveCreatedMaterials()
    {
        while (createdMaterials.Count > 0)
        {
            Material mat = createdMaterials[0];
            createdMaterials.RemoveAt(0);
#if UNITY_EDITOR
            DestroyImmediate(mat);
#else
                Destroy(mat);
#endif
        }
    }

    private bool CheckResources()
    {
        CheckSupport(false);
        
        blurMaterial = CheckShaderAndCreateMaterial(blurShader, blurMaterial);

        if (!isSupported)
            ReportAutoDisable();
            
        return isSupported;
    }

    private void OnDisable()
    {
        if (blurMaterial)
            DestroyImmediate(blurMaterial);
    }

    public void BlurImage(RenderTexture source, RenderTexture destination)
    {
        if (CheckResources() == false)
        {
            Graphics.Blit(source, destination);
            return;
        }

        float widthMod = 1.0f / (1.0f * (1 << downsample));

        blurMaterial.SetVector("_Parameter", new Vector4(blurSize * widthMod, -blurSize * widthMod, 0.0f, 0.0f));
        source.filterMode = FilterMode.Bilinear;

        int rtW = source.width >> downsample;
        int rtH = source.height >> downsample;

        // downsample
        RenderTexture rt = RenderTexture.GetTemporary(rtW, rtH, 0, source.format);

        rt.filterMode = FilterMode.Bilinear;
        Graphics.Blit(source, rt, blurMaterial, 0);

        var passOffs = blurType == BlurType.StandardGauss ? 0 : 2;

        for (int i = 0; i < blurIterations; i++)
        {
            float iterationOffs = (i * 1.0f);
            blurMaterial.SetVector("_Parameter", new Vector4(blurSize * widthMod + iterationOffs, -blurSize * widthMod - iterationOffs, 0.0f, 0.0f));

            // vertical blur
            RenderTexture rt2 = RenderTexture.GetTemporary(rtW, rtH, 0, source.format);
            rt2.filterMode = FilterMode.Bilinear;
            Graphics.Blit(rt, rt2, blurMaterial, 1 + passOffs);
            RenderTexture.ReleaseTemporary(rt);
            rt = rt2;

            // horizontal blur
            rt2 = RenderTexture.GetTemporary(rtW, rtH, 0, source.format);
            rt2.filterMode = FilterMode.Bilinear;
            Graphics.Blit(rt, rt2, blurMaterial, 2 + passOffs);
            RenderTexture.ReleaseTemporary(rt);
            rt = rt2;
        }

        Graphics.Blit(rt, destination);
        RenderTexture.ReleaseTemporary(rt);
    }

    private bool CheckSupport(bool needDepth)
    {
        isSupported = true;
        supportHDRTextures = SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGBHalf);
        supportDX11 = SystemInfo.graphicsShaderLevel >= 50 && SystemInfo.supportsComputeShaders;

        if (!SystemInfo.supportsImageEffects)
        {
            NotSupported();
            return false;
        }

        if (needDepth && !SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.Depth))
        {
            NotSupported();
            return false;
        }

        if (needDepth)
            GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
        
        return true;
    }

    private Material CheckShaderAndCreateMaterial(Shader s, Material m2Create)
    {
        if (!s)
        {
            Debug.Log("Missing shader in " + ToString());
            enabled = false;
            return null;
        }

        if (s.isSupported && m2Create && m2Create.shader == s)
            return m2Create;

        if (!s.isSupported)
        {
            NotSupported();
            Debug.Log("The shader " + s.ToString() + " on effect " + ToString() + " is not supported on this platform!");
            return null;
        }

        m2Create = new Material(s);
        createdMaterials.Add(m2Create);
        m2Create.hideFlags = HideFlags.DontSave;

        return m2Create;
    }

    private void NotSupported()
    {
        enabled = false;
        isSupported = false;
        return;
    }

    private void ReportAutoDisable()
    {
        Debug.LogWarning("The image effect " + ToString() + " has been disabled as it's not supported on the current platform.");
    }
}