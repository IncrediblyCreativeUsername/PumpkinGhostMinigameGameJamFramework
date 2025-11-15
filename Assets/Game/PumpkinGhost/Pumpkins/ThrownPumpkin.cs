using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ThrownPumpkin : MonoBehaviour
{

    public float speed;
    public GameObject model;
    private AudioSource _audio;

    [SerializeField] private AudioClip sound_pumpkinHit;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation.Set(0, transform.rotation.y, 0, transform.rotation.w);
        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Force);
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        model.transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        _audio.PlayOneShot(sound_pumpkinHit);
        // Check if colliding with a balloon
        if (other.gameObject.CompareTag("Balloon"))
        {
            //PumpkinGhost.PumpkinGhostPawn balloon = other.gameObject.GetComponent<PumpkinGhost.PumpkinGhostPawn>();
        }
    }
}
