using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BodyPart
{
	public string name;
	public float volume;
	public float mass;

	public string printProperties()
	{
		return name+":"+" Volume = "+volume+" , Mass = "+mass;
	}

}

public class MeshVolume : MonoBehaviour {

	public float totalMass;
	
	void Start () 
	{
		List<BodyPart> bodyPartList = new List<BodyPart> ();

		MeshFilter[] meshFilters = transform.GetComponentsInChildren<MeshFilter> ();

		float totalVolume = 0;

		foreach(MeshFilter meshFilter in meshFilters)
		{
			BodyPart part = new BodyPart();
			part.name = meshFilter.transform.name;
			part.volume = VolumeOfMesh(meshFilter.mesh);
			totalVolume += part.volume;

			bodyPartList.Add(part);
		}

		float totalDensity = totalMass / totalVolume;

		Debug.Log ("Total Mass = "+totalMass);
		Debug.Log ("Total Density = "+totalDensity);
		Debug.Log ("Total Volume = "+totalVolume);


		foreach(BodyPart part in bodyPartList)
		{
			part.mass = part.volume * totalDensity;
			Debug.Log(part.printProperties());
		}

	}
	
	private float SignedVolumeOfTriangle(Vector3 p1, Vector3 p2, Vector3 p3)
	{
		float v321 = p3.x * p2.y * p1.z;
		float v231 = p2.x * p3.y * p1.z;
		float v312 = p3.x * p1.y * p2.z;
		float v132 = p1.x * p3.y * p2.z;
		float v213 = p2.x * p1.y * p3.z;
		float v123 = p1.x * p2.y * p3.z;
		
		return (1.0f / 6.0f) * (-v321 + v231 + v312 - v132 - v213 + v123);
	}
	
	private float VolumeOfMesh(Mesh mesh)
	{
		float volume = 0;
		
		Vector3[] vertices = mesh.vertices;
		int[] triangles = mesh.triangles;
		
		for (int i = 0; i < mesh.triangles.Length-2; i += 3)
		{
			Vector3 p1 = vertices[triangles[i + 0]];
			Vector3 p2 = vertices[triangles[i + 1]];
			Vector3 p3 = vertices[triangles[i + 2]];
			volume += SignedVolumeOfTriangle(p1, p2, p3);
		}
		
		return Mathf.Abs(volume);
	}



}
