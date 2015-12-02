using UnityEngine;
using System.Collections;

public class AttachCamera : MonoBehaviour
{
	Transform myTransform;
	public Transform target;
	public Vector3 offset = new Vector3(5, 10, -10);
	Camera camera;

	
	void Start()
	{
		myTransform = this.transform;
	}
	
	void Update()
	{
		if (target != null)
		{
			myTransform.position = target.position + offset;
			myTransform.LookAt(target.position, Vector3.up);
			Ray ray = camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
			RaycastHit hit;
		}

	}



}
