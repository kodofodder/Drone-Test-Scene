using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrateDrone : MonoBehaviour {

	public GameObject drone;
	private bool startLeft = false;
	private bool startRight = false;
	public float calibUnit = 1f;
	public float unitsPerSec = 0.2f;
	Vector3 initialPosition;

	// Use this for initialization
	void Start () {
		initialPosition = drone.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            startLeft = true;
        }

		if (-(drone.transform.position.x-initialPosition.x) > calibUnit){
			startLeft = false;
			StartCoroutine(Wait());
		}

		if (drone.transform.position.x >= 0){
			startRight = false;
		}

		if (startLeft){
			drone.transform.Translate(Vector3.left * Time.deltaTime*unitsPerSec);
		}
		
		if (startRight){
			drone.transform.Translate(Vector3.right * Time.deltaTime*unitsPerSec);
		}
	}

	IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        startRight = true;
    }
}
