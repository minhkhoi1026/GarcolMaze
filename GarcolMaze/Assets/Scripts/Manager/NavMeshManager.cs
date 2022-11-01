using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshManager : MonoBehaviour {
	NavMeshSurface2d surface2D;
	void Start() {
        surface2D = GetComponent<NavMeshSurface2d>();
    }

	void Update() {
        surface2D.UpdateNavMesh(surface2D.navMeshData);

    }
}
