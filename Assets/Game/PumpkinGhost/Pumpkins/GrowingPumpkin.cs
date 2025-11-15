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

    public GameObject pumpkinBody;
    private Renderer _pumpkinBodyRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _pumpkinBodyRenderer = pumpkinBody.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (size < maxSize){
            // Increase size if applicable
            size += growRate * Time.deltaTime;

            // Set color based on size
            if (size < minSize)
            {
                _pumpkinBodyRenderer.material.SetColor("_Color", Color.HSVToRGB(0.08f + (0.17f * (1 - ((size - 0.6f) / 0.4f))), 0.95f, 0.9f, false));
            }

            //Enable/disable collider based on size
            if (size < minSize)
            {
                GetComponent<SphereCollider>().enabled = false;
            }
            else
            {
                GetComponent<SphereCollider>().enabled = true;
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
