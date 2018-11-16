using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour {

  public Transform playertransform;
  public Transform enemytransform;
  public GameObject bullet;
  Vector2 Aimingdirection;

    // Use this for initialization
    void Start () {
        StartCoroutine("shoottimer");
    }
	
	// Update is called once per frame
	void Update () {
        Aimingdirection = new Vector2(playertransform.position.x - enemytransform.position.x, playertransform.position.y - enemytransform.position.y);
    }

    private IEnumerator shoottimer() {
        while (true) {
        yield return new WaitForSeconds(0.5f);
        GameObject TMPbullet = Instantiate(bullet, (enemytransform.position), Quaternion.identity);
        Rigidbody2D rb = TMPbullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Aimingdirection * 50);
            Destroy(TMPbullet, 2);
        }
    }
}