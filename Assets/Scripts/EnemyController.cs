using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Vector3 startPosition;
    public float speed = 3;
    public Rigidbody rb;


    private void Awake()
    {
        startPosition = transform.position;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag ("Player"))
        {
            transform.position = startPosition;
            speed = speed - 0.5f;
        }
    }
}
