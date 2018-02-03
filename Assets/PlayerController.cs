using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f;
    public float jump = 2f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(0, jump, 0, ForceMode.Impulse);
            Debug.Log("JUMP!");
            //rb.AddForce(movement * speed);
            //rb.transform.position.y = jumpY + 5;

        }
        else { rb.AddForce(movement * speed); }
    }


}