using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Lean.Touch;

public class CubeLoop : MonoBehaviour
{

[SerializeField]
    public int danos;
    [SerializeField]

    int colisao = 0;

        [SerializeField]

    bool colidiu;

    GameObject pedra;

    public GameObject ARCamera;

    float dist;
      public bool gravidade;

    int massa;
        [SerializeField]


bool podeColidir;

    AudioSource cubeExplode;

      public GameObject danosTxt;


    private void Awake() {
        
        pedra = GameObject.Find("pedra");
         ARCamera = GameObject.Find("ARCamera");

       GeradorGravidade();
       GeradorMassa();

              cubeExplode = GameObject.Find(name: "SomeEsfera").GetComponent<AudioSource>();

    }

private void Start() {
             ARCamera = GameObject.FindWithTag("MainCamera");
          

                if (gravidade == true)
                {
                    this.gameObject.GetComponent<Animator>().StopPlayback();
                }

                  if (gravidade == false)
                {
                    this.gameObject.GetComponent<Animator>().Play("pulse.pulse");
                }

            CubeName();
            podeColidir = true;




  

     

}


private void CubeName() {


           this.gameObject.name = "Cube" + PlayerPrefs.GetInt("CubeNumber");
            int nextCube = PlayerPrefs.GetInt("CubeNumber") + 1;
           PlayerPrefs.SetInt("CubeNumber", nextCube);
		   	Debug.Log(gameObject.name);
		
    
}
private void Update() {

                dist = Vector3.Distance(this.gameObject.transform.position, ARCamera.transform.position);



if (ARCamera != null)
{
if (dist >= 50)
    {
        Destroy(this.gameObject);
    }
}
    
     
}
public void GravidadeOff()
    {
           this.GetComponent<Rigidbody>().useGravity = false;
         this.gameObject.GetComponent<Animator>().Play("pulse");

        
    }


 public void GravidadeOn()
    {
        
        if (gravidade == true)
        {
           this.GetComponent<Rigidbody>().useGravity = true;
            this.gameObject.GetComponent<Animator>().StopPlayback();


        }
        if (gravidade == false)
        {
           this.GetComponent<Rigidbody>().useGravity = false;

        }
           
    }

        void GeradorGravidade()
        
        {

         int escolheGravidade = Random.Range(1,11) ;
           Debug.Log("escolhe gravidade " + escolheGravidade);

         switch (escolheGravidade) {

            case 1 :

            gravidade = false;
               this.GetComponent<Rigidbody>().useGravity = gravidade;
                Debug.Log(gravidade);

            break;


            case 2:

            gravidade = true;
               this.GetComponent<Rigidbody>().useGravity = gravidade;
                Debug.Log(gravidade);

            break;


            case 3 :

            gravidade = true;
               this.GetComponent<Rigidbody>().useGravity = gravidade;
                Debug.Log(gravidade);

            break;


            case 4 :

            gravidade = true;
               this.GetComponent<Rigidbody>().useGravity = gravidade;
                Debug.Log(gravidade);

            break;


            case 5 :

           gravidade = false;
              this.GetComponent<Rigidbody>().useGravity = gravidade;
                Debug.Log(gravidade);

            break;


            case 6 :

            gravidade = true;
               this.GetComponent<Rigidbody>().useGravity = gravidade;
                Debug.Log(gravidade);

            break;


            case 7 :

            gravidade = false;
               this.GetComponent<Rigidbody>().useGravity = gravidade;
                Debug.Log(gravidade);

            break;


            case 8 :

            gravidade = true;
               this.GetComponent<Rigidbody>().useGravity = gravidade;
                Debug.Log(gravidade);

            break;

              case 9 :

            gravidade = false;
               this.GetComponent<Rigidbody>().useGravity = gravidade;
                Debug.Log(gravidade);

            break;



            case 10 :

            gravidade = true;
               this.GetComponent<Rigidbody>().useGravity = gravidade;
                Debug.Log(gravidade);

            break;
         }

             
   

   }
    
    void GeradorMassa() {

        int escolheMassa = Random.Range(1,20) ;
         

        switch (escolheMassa) {

            case 1 :

             this.GetComponent<Rigidbody>().mass = massa;

            break;


            case 2:

             this.GetComponent<Rigidbody>().mass = massa;

            break;


            case 3 :

             this.GetComponent<Rigidbody>().mass = massa;

            break;


            case 4 :

             this.GetComponent<Rigidbody>().mass = massa;

            break;


            case 5 :

            this.GetComponent<Rigidbody>().mass = massa;

            break;


            case 6 :

             this.GetComponent<Rigidbody>().mass = massa;

            break;


            case 7 :

             this.GetComponent<Rigidbody>().mass = massa;

            break;


            case 8 :

            this.GetComponent<Rigidbody>().mass = massa;

            break;

              case 9 :

             this.GetComponent<Rigidbody>().mass = massa;

            break;



            case 10 :

             this.GetComponent<Rigidbody>().mass = massa;

            break;
         }


    }
    public IEnumerator DestroiCubo()
    {       
         cubeExplode.GetComponent<AudioSource>().PlayDelayed(.7f);
    this.gameObject.GetComponent<Animator>().enabled = false;
    float escala = this.gameObject.transform.localScale.x;

        for (float i = escala; i >= 0.00; i-= 0.05f)
        {

          yield return new WaitForSeconds(.3f);

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


    IEnumerator MostraDano()
    {
            this.gameObject.GetComponent<Animator>().Play("Base Layer.danosTxt");
            yield return new WaitForSeconds(.5f);
                       this.gameObject.GetComponent<Animator>().Play("danosTxt", -1, 0f);
                                    // yield return new WaitForSeconds(1f);
                                    //                         this.gameObject.GetComponent<Animator>().enabled = true;




    }
     private void OnCollisionEnter(Collision collision) {

        if (collision.contactCount == 1)
        {

if  (collision.collider.tag == "pedra" && podeColidir == true)
    {       
         danos++;
                  danosTxt.GetComponent<TextMeshPro>().text = danos.ToString();
        StartCoroutine(MostraDano());
              
        if (danos >= 4)
        {          

                    StartCoroutine(routine: DestroiCubo());



        }


         else if (this.GetComponent<AudioSource>().isPlaying == true && podeColidir == true)

        {   

                this.GetComponent<AudioSource>().Pause();
                this.GetComponent<AudioSource>().loop = false;
                podeColidir = false;
                StartCoroutine(PodeColidir());

          
           
        

            Debug.Log("1");

        }

        else if (this.GetComponent<AudioSource>().isPlaying == false && podeColidir == true)
        {

                this.GetComponent<AudioSource>().UnPause();
                this.GetComponent<AudioSource>().loop = true;
                 podeColidir = false;
                StartCoroutine(PodeColidir());
            

     

            Debug.Log("2");
        }
        

    }
        }   
     
        


     }

     IEnumerator PodeColidir()
     {
        yield return new WaitForSeconds(1f);
        podeColidir = true;

     }



   
}
