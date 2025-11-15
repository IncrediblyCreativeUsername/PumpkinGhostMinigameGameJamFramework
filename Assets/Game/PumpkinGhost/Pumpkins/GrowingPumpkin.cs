using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using PumpkinGhost;

public class GrowingPumpkin : MonoBehaviour
{

    public float maxSize;
    public float minSize;
    public float growRate;
    public float size = 1.0f;
    public GameObject unripe;
    public GameObject ripe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (size < maxSize){
            // Increase size if applicable
            size += growRate * Time.deltaTime;

            //Determine what model should be used based on ripeness
            if (size < minSize)
            {
                GetComponent<SphereCollider>().enabled = false;
                unripe.SetActive(true);
                ripe.SetActive(false);
            }
            else
            {
                GetComponent<SphereCollider>().enabled = true;
                unripe.SetActive(false);
                ripe.SetActive(true);
            }

            // Set size to max if it goes above
            if (size > maxSize)
            {
                size = maxSize;
            }

            // Set scale to factor by size
            transform.localScale = new Vector3(size, size, size);
        }
    }

    // Collision detection for the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if colliding with a player
        if (other.gameObject.CompareTag("Player") && size > minSize)
        {
            PumpkinGhost.PumpkinGhostPawn player = other.gameObject.GetComponent<PumpkinGhost.PumpkinGhostPawn>();
            player.pumpkinPickup = this;
        }
    }

    // Player exiting
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PumpkinGhost.PumpkinGhostPawn player = other.gameObject.GetComponent<PumpkinGhost.PumpkinGhostPawn>();

            if (player.pumpkinPickup == this)
            {
                player.pumpkinPickup = null;
            }
            
        }
    }

    // Returns the size of the pumpkin
    public float GetSize() {
        return size;
    }

    public void Delete()
    {
        gameObject.SetActive(false);
        Destroy(this);
    }
}
