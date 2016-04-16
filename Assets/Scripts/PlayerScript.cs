using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public float speed = 10;
    float distToGround;
    public float jumpForce = 10;
    public Transform top_left;
    public Transform bottom_right;
    public LayerMask ground_layers;
    //float verticalVel = 0;

	// Use this for initialization
	void Start () {
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    bool IsGrounded() {
        return Physics2D.OverlapArea(top_left.position, bottom_right.position, ground_layers);
    }

    void FixedUpdate() {
        Vector3 movement = Vector3.zero;
        movement.x += Input.GetAxis("Horizontal");
        if (movement.x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
        }
        else if (movement.x > 0) {
            Vector3 scale = transform.localScale;
            scale.x = 1;
            transform.localScale = scale;
        }
        if (Input.GetAxis("Vertical") > 0 && IsGrounded()) {
            GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        transform.Translate(movement * speed * Time.deltaTime);
        transform.rotation = Quaternion.identity;
    }
}
