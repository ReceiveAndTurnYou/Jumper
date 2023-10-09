using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpStrength = 5f;
    [SerializeField] private Rigidbody rigidBody;

    private float groundY = 0.6f;
    private bool isPlayerCrouching = false;
    public event EventHandler OnPlayerDeath;

    private void Update()
    {
        float playerHeight = 0.5f;
        float moveDistance = .2f * Time.deltaTime;
        float playerRadius = 0.2f;
        bool isCollissionHappenned = false;

        if (Input.GetKeyDown(KeyCode.W))
        {
            isPlayerCrouching = false;
            if (rigidBody.position.y <= groundY)
            {
                rigidBody.velocity = Vector3.up * jumpStrength;
            }
        }

        if(Input.GetKey(KeyCode.S))
        {
            isPlayerCrouching = true;
        }
        else
        {
            isPlayerCrouching = false;
        }

        if (isPlayerCrouching)
        {
            //ставим здесь коллизию при приседании
            float crouchPlayerHeight = 0.3f;
            Debug.DrawRay(transform.position, transform.position + Vector3.up * crouchPlayerHeight, Color.blue);
            Vector3 crouchDirection = new Vector3(0.5f, 0.3f, 0.5f);
            isCollissionHappenned = SetCollission(crouchDirection, crouchPlayerHeight, moveDistance, playerRadius);
        }
        else
        {
            //игрок стоит или прыгает
            Vector3 direction = new Vector3(0.5f, 5f, 0.5f);
            isPlayerCrouching = false;
            isCollissionHappenned = SetCollission(direction, playerHeight, moveDistance, playerRadius);
            Debug.DrawRay(transform.position, transform.position + Vector3.up * playerHeight, Color.red);
        }

        if(isCollissionHappenned)
        {
            Destroy(gameObject);
            OnPlayerDeath?.Invoke(this, EventArgs.Empty);
        }

    }

    private bool SetCollission(Vector3 direction, float playerHeight, float moveDistance, float playerRadius)
    {
        return Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, direction, playerHeight);
    }

    public bool IsCrouching()
    {
        return isPlayerCrouching;
    }
}
