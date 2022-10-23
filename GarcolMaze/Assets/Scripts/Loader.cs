using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Loader : MonoBehaviour {
	public GameObject gameManager;
	public GameObject soundManager;

	void Start() {
		if (GameManager.instance == null)
		{
			Instantiate(gameManager);
		}

		// TODO: add sound manager initialize here
	}
}
