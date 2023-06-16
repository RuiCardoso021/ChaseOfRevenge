using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Blit : MonoBehaviour
{
    //public Shader damageShader;
    public static Damage_Blit Instance;
    public Color damageColor = Color.red;
    public float damageRadius = 1f;
    public float damageIntensity = 1f;

    public Material damageMaterial;

    private void Awake()
    {
        if (Instance != null) Destroy(Instance);
        else Instance = this;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
            // Aplica o shader na renderização da textura
            Graphics.Blit(source, destination, damageMaterial);
    }
}
