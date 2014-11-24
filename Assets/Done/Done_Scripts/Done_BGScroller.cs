using UnityEngine;
using System.Collections;

public class Done_BGScroller : MonoBehaviour
{
	public float tileSizeZ;

	private Vector3 startPosition;
	private float scrollSpeed = -4;

	void Start ()
	{
		startPosition = transform.position;
		scrollSpeed += (scrollSpeed * Application.loadedLevel/FMG.Constants.totalLevelCount);

	}

	void Update ()
	{
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
		transform.position = startPosition + Vector3.forward * newPosition;
	}
}