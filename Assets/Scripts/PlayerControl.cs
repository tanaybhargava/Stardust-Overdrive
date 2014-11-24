using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerControl : MonoBehaviour
{

	// Public Members
	public float speed;
	public float tilt;
	public Boundary boundary;
	
	public GameObject shot;

	public Transform shotSpawn;

	public float fireRate;

	public string playerNumber = "1";

	public GameObject playerExplosion;

	public TextMesh bulletText;

	public int initialBulletCount = 10;

	//Controls
	private string horizontal = "Horizontal";
	private string vertical = "Vertical";
	private string fire = "Fire";

	private float nextFire;

	private int bulletCount = 0;

	private int shotType;

	void Start()
	{
		// Set controls
		horizontal += playerNumber;
		vertical += playerNumber;
		fire += playerNumber;

		changeBulletCount (initialBulletCount);
	}
	
	void Update ()
	{
		if (Input.GetButton(fire) && Time.time > nextFire && bulletCount>0) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			audio.Play ();
			changeBulletCount(-1);
		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis (horizontal);
		float moveVertical = Input.GetAxis (vertical);
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * speed;
		
		rigidbody.position = new Vector3
			(
				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
				);
		
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, transform.position, transform.rotation);
			Done_GameController.instance.LevelFailed();
			Destroy (gameObject);
		}
	}

	void changeBulletCount(int add)
	{
		bulletCount += add;
		bulletText.text = bulletCount.ToString();
	}
}
