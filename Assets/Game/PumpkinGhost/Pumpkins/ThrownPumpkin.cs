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
<<<<<<< Updated upstream
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
=======
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        
=======
        //GetComponent<Rigidbody>().Move();
>>>>>>> Stashed changes
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
