using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruiCubinhos : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(routine: DestroiCubo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     IEnumerator DestroiCubo()
    {       yield return new WaitForSeconds(4f);

    float escala = this.gameObject.transform.localScale.x;

        for (float i = escala; i >= 0.0000; i-= 0.01f)
        {

          yield return new WaitForSeconds(.5f);

        this.gameObject.transform.localScale = new Vector3 (i,i,i);
        }
        // yield return new WaitForSeconds(4f);
        // this.gameObject.transform.localScale = new Vector3 (0.1f,0.5f,0.5f);
        //  yield return new WaitForSeconds(.5f);
        // this.gameObject.transform.localScale = new Vector3 (0.4f,0.4f,0.4f);
        //  yield return new WaitForSeconds(.5f);
        // this.gameObject.transform.localScale = new Vector3 (0.3f,0.3f,0.3f);
        //  yield return new WaitForSeconds(.5f);
        // this.gameObject.transform.localScale = new Vector3 (x: 0.2f,0.2f,z: 0.2f);
        //   yield return new WaitForSeconds(.5f);
        // this.gameObject.transform.localScale = new Vector3 (x: 0.1f,0.1f,z: 0.1f);


        Destroy(this.gameObject);
    }
}
