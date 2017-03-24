using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InvertScript : MonoBehaviour {
    public GameObject cube;
	// Use this for initialization
	void Start () {
        Mesh mesh = cube.GetComponent<MeshFilter>().mesh;
        mesh.triangles = mesh.triangles.Reverse().ToArray();
        mesh.RecalculateNormals();
    }
}
