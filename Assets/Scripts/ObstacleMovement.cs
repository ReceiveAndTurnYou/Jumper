using System;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private float moveSpeed = 2.8f;
    private float deadZone = -24f;
    public event EventHandler OnCollidingWithTriggerBox;

    private void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if(transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("TriggerBox"))
        {
            OnCollidingWithTriggerBox?.Invoke(this, EventArgs.Empty);
        }
    }
}
