using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GrowingPumpkin : MonoBehaviour
{

    public float maxSize;
    public float growRate;
    private float size = 1.0f;

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

            // Set size to max if it goes above
            if (size < maxSize) {
                size = maxSize;
            }

            // Set scale to factor by size
            transform.localScale = new Vector3(size, size, size);

        }
    }

    // Collision detection for the trigger
    private void OnTriggerEnter(Collider other)
    {

    }
}
