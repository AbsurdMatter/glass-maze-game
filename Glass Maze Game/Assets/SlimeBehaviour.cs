using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehaviour : MonoBehaviour
{
    Animator anim;
    public Collider SightArea;
    public Transform player;

    bool m_IsPlayerInRange;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {

                }
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
            anim.SetBool("isTriggered", true);
            anim.SetBool("isIdle", false);
            Debug.Log("TriggeredSlime.");
        }
        else
        {
            anim.SetBool("isIdle", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
            anim.SetBool("isIdle", true);
            anim.SetBool("isTriggered", false);

        }
    }
}
