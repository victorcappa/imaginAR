using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Explode : MonoBehaviour { 
    public int cubesPerAxis = 8;
    public float delay = 1f;
    public float force = 400f;
    public float radius = 2f;

    void Start() {
        Invoke("Main", delay);
    }

 void Main() {
        for (int x = 0; x < cubesPerAxis; x++) {
            for (int y = 0; y < cubesPerAxis; y++) {
                for (int z = 0; z < cubesPerAxis; z++) {
                    CreateCube(new Vector3(x, y, z));
                }
            }
        }

        Destroy(gameObject);
    }


   

    void CreateCube(Vector3 coordinates) {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        Renderer rd = cube.GetComponent<Renderer>();
        rd.material = GetComponent<Renderer>().material;

        cube.transform.localScale = transform.localScale / cubesPerAxis;

        Vector3 firstCube = transform.position - transform.localScale / 2 + cube.transform.localScale / 2;
        cube.transform.position = firstCube + Vector3.Scale(coordinates, cube.transform.localScale);

        Rigidbody rb = cube.AddComponent<Rigidbody>();
        rb.AddExplosionForce(force, transform.position, radius);

        cube.AddComponent<DestruiCubinhos>();
    }

    
}
