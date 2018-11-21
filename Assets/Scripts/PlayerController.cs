using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    
    private Rigidbody rb;
    private int count;

    public Text countText;

    private Animator anim;




    void Start () {
        rb = GetComponent<Rigidbody>();
        count = 5;
        SetCountText();
        anim = GetComponent<Animator>();
    }
	
	
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
       
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            count = count - 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Vida: " + count.ToString();
        if(count == 0)
        {
            countText.text = "You Lose";
        }
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("pulsaA", true);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("pulsaD", true);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("pulsaW", true);
        }
    }
}
