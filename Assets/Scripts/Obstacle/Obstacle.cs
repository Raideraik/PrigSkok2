using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private MeshFilter[] _mesh;
    [SerializeField] private MeshRenderer[] _material;
    public void ChangeObstacle(Mesh mesh, Material[] material)
    {
        for (int i = 0; i < _mesh.Length; i++)
            _mesh[i].mesh = mesh;

        for (int i = 0; i < _material.Length; i++)
            _material[i].materials = material;
    }
}
