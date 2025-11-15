using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ThrownPumpkin : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if colliding with a balloon
        if (other.gameObject.CompareTag("Balloon"))
        {
            //PumpkinGhost.PumpkinGhostPawn balloon = other.gameObject.GetComponent<PumpkinGhost.PumpkinGhostPawn>();
        }
    }
}
