using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ThrownPumpkin : MonoBehaviour
{

    public float speed;
    public GameObject model;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation.Set(0, transform.rotation.y, 0, transform.rotation.w);
        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {
        model.transform.Rotate(0, speed * Time.deltaTime, 0);
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
