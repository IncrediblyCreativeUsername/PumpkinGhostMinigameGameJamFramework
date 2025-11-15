using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ThrownPumpkin : MonoBehaviour
{

    public float speed;
    public GameObject model;
<<<<<<< Updated upstream
    private AudioSource _audio;

    [SerializeField] private AudioClip sound_pumpkinHit;
=======
    public int playerNum;
    public GameObject pumpkinRespawn;
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation.Set(0, transform.rotation.y, 0, 0);
        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Force);
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        model.transform.Rotate(0, speed * Time.deltaTime, 0);
        transform.rotation.Set(0, transform.rotation.y, 0, 0);
        transform.position.Set(transform.position.x, 0, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        _audio.PlayOneShot(sound_pumpkinHit);
        // Check if colliding with a balloon
        if (other.gameObject.CompareTag("Respawn"))
        {
            // Place 1-3 new pumpkins on the ground
            int numPumpkins = Random.Range(0, 2);
            for (int i = 0; i < numPumpkins; i++)
            {
                // Places a pumpkin
                pumpkinRespawn.transform.position = transform.position + new Vector3 (Random.Range(-3.0f, 3.0f), 0, Random.Range(-3.0f, 3.0f));
                Instantiate(pumpkinRespawn);
            }

            Destroy(this);
            gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("EditorOnly") || other.gameObject.CompareTag("MainCamera"))
        {
            pumpkinRespawn.transform.position = transform.position;
            Instantiate(pumpkinRespawn);
            Destroy(this);
            gameObject.SetActive(false);
        }
    }
}
