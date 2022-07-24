using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeManager : MonoBehaviour
{

   public GameObject cubePrefab, cubePrefabLoop;

   public Material[] materials;
   public AudioClip[] sons;
      public AudioClip[] sonsLoop;

      bool gravidade;

    
    private void Awake() {
      PlayerPrefs.DeleteAll();
    }

   public void CriaCubo() {

   Debug.Log(gravidade);

   int qualCuboMat = Random.Range(0, materials.Length -1 );
   int qualCuboSom = Random.Range(0, sons.Length -1 );
   float cuboScale = Random.Range(0.1f, maxInclusive: 0.5f);
   float cuboVolume = cuboScale;
   float qualPitch = Random.Range(0.6f, 1.7f);
    

    GameObject newCube = Instantiate(cubePrefab, this.transform.position, this.transform.rotation);
    newCube.GetComponent<MeshRenderer>().material = materials[qualCuboMat];
    newCube.GetComponent<AudioSource>().clip = sons[qualCuboSom];
    newCube.GetComponent<AudioSource>().pitch = qualPitch;
    newCube.transform.GetChild(0).GetComponent<TextMeshPro>().text = newCube.GetComponent<AudioSource>().clip.name;
    newCube.transform.localScale = new Vector3(cuboScale- 0.1f,y: cuboScale- 0.1f,cuboScale- 0.1f);
    

if (newCube.GetComponent<Cube>().gravidade == true) 
{
    Rigidbody rb = newCube.GetComponent<Rigidbody>();
                rb.velocity = new Vector3(0f, 0f, 0f);
                rb.angularVelocity = new Vector3(0f, 0f, 0f);
                        float force = 1.0f;
     rb.AddForce(this.transform.position * force);
}

  
  if(cuboVolume <= 1)
    {
   newCube.GetComponent<AudioSource>().volume = cuboVolume + 0.1f;
    }    
     else if(cuboVolume >= 0.8f){
       newCube.GetComponent<AudioSource>().volume = cuboVolume - 0.1f;
    }
    

   }


   public void CriaCuboLoop() {

    int qualCuboMat = Random.Range(0, materials.Length -1 );
    int qualCuboSom = Random.Range(0, sonsLoop.Length -1 );
    float cuboScale = Random.Range(0.1f, maxInclusive: 0.5f);
    float cuboVolume = cuboScale;
    float qualPitch = Random.Range(0.6f, 1.7f);
      

    GameObject newCube = Instantiate(cubePrefabLoop, this.transform.position, this.transform.rotation);
    newCube.GetComponent<MeshRenderer>().material = materials[qualCuboMat];
    newCube.GetComponent<AudioSource>().clip = sonsLoop[qualCuboSom];
    newCube.GetComponent<AudioSource>().pitch = qualPitch;
    newCube.GetComponent<AudioSource>().loop = true;
    newCube.GetComponent<AudioSource>().Play();
    newCube.transform.GetChild(0).GetComponent<TextMeshPro>().text = newCube.GetComponent<AudioSource>().clip.name;
        newCube.transform.localScale = new Vector3(cuboScale- 0.1f,y: cuboScale- 0.1f,cuboScale- 0.1f);

if (newCube.GetComponent<CubeLoop>().gravidade == true)
{
    Rigidbody rb = newCube.GetComponent<Rigidbody>();
                rb.velocity = new Vector3(0f, 0f, 0f);
                rb.angularVelocity = new Vector3(0f, 0f, 0f);
                        float force = 1.0f;
     rb.AddForce(this.transform.position * force);
}



   if(cuboVolume <= 1)
    {
   newCube.GetComponent<AudioSource>().volume = cuboVolume + 0.1f;
    }    
     else if(cuboVolume >= 0.8f){
       newCube.GetComponent<AudioSource>().volume = cuboVolume - 0.1f;
    }
    



   }

   public void DestroiCubos()
   {
      GameObject[] cubes = GameObject.FindGameObjectsWithTag("cubos");
      foreach(GameObject cube in cubes)
      { 
         cube.GetComponent<Explode>().enabled = true;
         cube.GetComponent<Cube>().cubeExplode.GetComponent<AudioSource>().PlayDelayed(.8f);


      }
   }

     public void DestroiEsferas()
   {
      GameObject[] esferas = GameObject.FindGameObjectsWithTag("esferas");
      foreach(GameObject esfera in esferas)
      //esfera.GetComponent<CubeLoop>().danos = 5;
     StartCoroutine(esfera.GetComponent<CubeLoop>().DestroiCubo());
   }

   
}
