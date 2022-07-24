using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class Magnet : MonoBehaviour
{
    // Name of the tags you're using to mark objects to be affected by the magnet
    const string AttractTagName = "projectile";
    const string RepulseTagName = "repele";
     [SerializeField]
    float MaxRange = 10f; // maximum distance the magnet will begin pulling an object from
     [SerializeField]
    float MaxStrength = 10f; // Maximum strength the magnet will pull something right next to it. Goes down as the object gets further away
    // We use FixedUpdate() instead of Update() because we're working entirely with rigidbodies and physics
    // FixedUpdate() occurs at regular intervals in time with the physics system, not once per frame like Update() does.
    // For almost anything else you do you should use Update()
    private void FixedUpdate()
    {
        // Find all colliders in range of the magnet
        Collider[] Colliders = Physics.OverlapSphere(transform.position, MaxRange);
        foreach(Collider Collider in Colliders)
        {
            if (Collider.tag == AttractTagName) // The object has a tag saying it should be attracted by the magnet
            {
                Rigidbody rb = Collider.GetComponent<Rigidbody>(); // get the rigidbody on the object
                if (rb != null)
                {   // object had a rigidbody, apply the force
                    Attract(rb);
                }
                else
                {   // object did not have a rigidbody, log a warning to show that's why it's not being affected by the magnet
                    Debug.LogWarning("Object had an attract tag, but did not have a rigidbody component");
                }
            }
            else if (Collider.tag == RepulseTagName) // The object has a tag saying it should be repulsed by the magnet
            {
                Rigidbody rb = Collider.GetComponent<Rigidbody>(); // get the rigidbody on the object
                if (rb != null)
                {   // object had a rigidbody, apply the force
                    Repulse(rb);
                }
                else
                {   // object did not have a rigidbody, log a warning to show that's why it's not being affected by the magnet
                    Debug.LogWarning("Object had an attract tag, but did not have a rigidbody component");
                }
            }
        }
    }
    private void Attract(Rigidbody rb)
    {
        float Distance = Vector3.Distance(rb.transform.position, this.transform.position);
        float TDistance = Mathf.InverseLerp(MaxRange, 0f, Distance); // Give a decimal representing how far between 0 distance and max distance the object is.
        float strength = Mathf.Lerp(0f, MaxStrength, TDistance); // Use that decimal to work out how much strength the magnet should apply
        Vector3 FromObjectToMagnet = (this.transform.position - rb.transform.position).normalized; // Get the direction from the object to the magnet
        rb.AddForce(FromObjectToMagnet * strength, ForceMode.Force);// apply force to the object
    }
    private void Repulse(Rigidbody rb)
    {   // This is exactly the same as Attract(), the direction is just reversed
        float Distance = Vector3.Distance(rb.transform.position, this.transform.position);
        float TDistance = Mathf.InverseLerp(MaxRange, 0f, Distance); // Give a decimal representing how far between 0 distance and max distance the object is.
        float strength = Mathf.Lerp(0f, MaxStrength, TDistance); // Use that decimal to work out how much strength the magnet should apply
        Vector3 FromMagnetToObject = (rb.transform.position - this.transform.position).normalized; // Get the direction from the object to the magnet
        rb.AddForce(FromMagnetToObject * strength, ForceMode.Force);// apply force to the object
    }
}
 
