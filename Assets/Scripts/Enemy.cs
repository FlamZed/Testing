using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private Transform ball;
    [SerializeField] private PlayerController playerController;
    Rigidbody rb;
    public static int reactionSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(ball.position.x, 0 , 0) * reactionSpeed * 2, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerController.ResetPosition(true);
    }
}
