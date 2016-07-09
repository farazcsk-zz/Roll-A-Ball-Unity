using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	private Rigidbody rb;
	private int count;
	public Text countText;
	public Text winText;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText();
		winText.text = "";
	}
	
	// // Update is called once per frame
	// void Update () {

	// }
	
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");	

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText();
        }
    }

	void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag ("Wall"))
		{
			count = count - 1;
			SetCountText();
		}
	}

	void SetCountText () 
	{
		countText.text = "Count: " + count.ToString ();

		if (count >= 47)
		{
			winText.text = "YOU WIN!";
		} else if (count < 0){
			winText.text = "YOU LOSE";
			Application.Quit();
		}
	}
}
