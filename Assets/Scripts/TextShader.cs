using UnityEngine;

public class Custom3DTextShader : MonoBehaviour
{
    public Texture2D mainTexture;
    public Color textColor = Color.white;

    private Material material;

    private void Awake()
    {
        // Create a new material using the specified shader
        Shader shader = Shader.Find("Custom/3DText");
        material = new Material(shader);

        // Set the main texture property
        material.SetTexture("_MainTex", mainTexture);

        // Set the text color property
        material.SetColor("_Color", textColor);
    }

    private void OnRenderObject()
    {
        // Apply the material for rendering
        material.SetPass(0);

        // Render the object
        Graphics.DrawMeshNow(GetComponent<MeshFilter>().sharedMesh, transform.position, transform.rotation);
    }
}
