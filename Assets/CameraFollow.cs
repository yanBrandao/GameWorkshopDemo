using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform player;

	public float yMax;

	[SerializeField]
	private float yMin;

	[SerializeField]
	private float xMin;

	public float xMax;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3 (Mathf.Clamp (player.position.x, xMin, xMax), Mathf.Clamp (player.position.y, yMin, yMax), transform.position.z);
	}
}
