using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2.5f;

    public float jumpForce = 300.0f;
    public bool isJumping = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();

        playerJump();
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("floor")) {
            isJumping = false;
        }
    }

    private void playerMovement() {
         // left
        if (Input.GetKey(KeyCode.A)) {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        // right
        if (Input.GetKey(KeyCode.D)) {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        // forward
        if (Input.GetKey(KeyCode.W)) {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        // back
        if (Input.GetKey(KeyCode.S)) {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
    }

    private void playerJump() {
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false) {
            this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
            isJumping = true;
        }
    }
}
