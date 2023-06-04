using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateriarChanger : MonoBehaviour
{
    public Material newMaterial; //변경할 새로운 재질

    private void Start()
    {
        ChangeMaterial();
    }

    private void ChangeMaterial()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.material = newMaterial;
        }
    }
}
