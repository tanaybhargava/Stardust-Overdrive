using UnityEngine;
using System.Collections;

public class ParentDetacher : MonoBehaviour {

	void Start () 
	{
		transform.DetachChildren ();
		Destroy (gameObject);
	}
}
