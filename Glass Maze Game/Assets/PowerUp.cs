using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour 
{
    public GameObject pickupEffect;
    public float HeightMultiplier = 1.5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp(other);
        }
    }

    void PickUp(Collider player)
    {
        Debug.Log("Power up picked up");

        // Spawn an effect
        Instantiate(pickupEffect, transform.position, transform.rotation);

        // Apply effect to player
        player.transform.localScale *= HeightMultiplier;

        // Remove power up object
        Destroy(gameObject);
    }
}
