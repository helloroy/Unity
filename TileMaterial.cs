using UnityEngine;

/// <summary>
/// Runtime texture tiling and coloring.
/// </summary>

public class TileMaterial : MonoBehaviour
{
    public Color color = Color.white;
    public bool tileTexture = true;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_Color", color);
        if (tileTexture)
        {
            renderer.material.SetTextureScale("_MainTex", new Vector3(transform.localScale.x, transform.localScale.z, transform.localScale.z));
        }
    }
}