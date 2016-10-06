using UnityEngine;
using System.Collections;

public class ScrollBackground : MonoBehaviour {
	public float speed = 10f;

	MeshRenderer quadRenderer;

	void Start(){
		quadRenderer = GetComponent<MeshRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		Material mat = quadRenderer.material;

		Vector2 offset = mat.mainTextureOffset;

		offset.x += (Time.deltaTime / speed);

		mat.mainTextureOffset = offset;
	}
}
