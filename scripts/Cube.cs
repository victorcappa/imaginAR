using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using Lean.Touch;

public class Cube : MonoBehaviour
{

[SerializeField]
    int danos;
    [SerializeField]

    bool stopPlayLoop;
    [SerializeField]

    int acertou;

    public bool gravidade;

    int massa;

    public AudioSource cubeExplode;

    float escala;

    public GameObject danosTxt;



    

     private void OnCollisionEnter(Collision collision) {
   
        

       if (collision.contactCount == 1)
       {
   if  (collision.collider.tag == "pedra")
    {       
         danos++;
        //StartCoroutine(Diminui());
         danosTxt.GetComponent<TextMeshPro>().text = danos.ToString();
        StartCoroutine(MostraDano());
     
      
              
        if (danos >= 10)
        {
                this.GetComponent<Explode>().enabled = true;
                cubeExplode.GetComponent<AudioSource>().PlayDelayed(.6f);
        }


        this.GetComponent<AudioSource>().Play();

    }
       }
     

    }

    IEnumerator MostraDano()
    {
            this.gameObject.GetComponent<Animator>().Play("danosTxt");
            yield return new WaitForSeconds(.6f);
                       this.gameObject.GetComponent<Animator>().Play("danosTxt", -1, 0f);
                                    // yield return new WaitForSeconds(1f);
                                    //                         this.gameObject.GetComponent<Animator>().enabled = true;




    }
// PRECISA MUDAR A ANIM PULSE
    // IEnumerator Diminui()
    // {
    //     this.gameObject.GetComponent<Animator>().StopPlayback();
    //     yield return new WaitForSeconds(.1f);
    //     escala -= 0.05f;
    //       this.gameObject.transform.localScale = new Vector3 (escala, escala, escala);  
    //               yield return new WaitForSeconds(.1f);
    //                       this.gameObject.GetComponent<Animator>().Play("pulse");


    // }



private void Awake() {

       GeradorGravidade();
       GeradorMassa();
       CubeName();

       this.gameObject.AddComponent<LeanDragTranslate>();
       cubeExplode = GameObject.Find(name: "CubeManager").GetComponent<AudioSource>();
       escala = this.gameObject.transform.localScale.x;


     

}

private void Start() {
    
                if (gravidade == true)
                {
                    this.gameObject.GetComponent<Animator>().StopPlayback();
                }

                  if (gravidade == false)
                {
                    this.gameObject.GetComponent<Animator>().Play("pulse.pulse");
                }
}

private void CubeName() {


           this.gameObject.name = "Cube" + PlayerPrefs.GetInt("CubeNumber");
            int nextCube = PlayerPrefs.GetInt("CubeNumber") + 1;
           PlayerPrefs.SetInt("CubeNumber", nextCube);
		   	Debug.Log(gameObject.name);
		
    
}


private void Update() {
               			//this.gameObject.GetComponent<LeanDragTranslate>().gameObject = this.gameObject;
//
}

 public void GravidadeOff()
    {
           this.GetComponent<Rigidbody>().useGravity = false;
           this.gameObject.GetComponent<Animator>().Play("pulse");
           
    }


 public void GravidadeOn()
    {
        Debug.Log(gravidade);
        if (gravidade == true)
        {
           this.GetComponent<Rigidbody>().useGravity = true;

        }
        if (gravidade == false)
        {
           this.GetComponent<Rigidbody>().useGravity = false;

        }
           
    }
        void GeradorGravidade(){

         int escolheGravidade = Random.Range(1,11) ;
           Debug.Log("escolhe gravidade " + escolheGravidade);

         switch (escolheGravidade) {

            case 1 :

            gravidade = false;
            this.GetComponent<Rigidbody>().useGravity = gravidade;
            break;

            case 2:

            gravidade = true;
            this.GetComponent<Rigidbody>().useGravity = gravidade;
            break;


            case 3 :

            gravidade = true;
            this.GetComponent<Rigidbody>().useGravity = gravidade;
            break;


            case 4 :
            this.GetComponent<Rigidbody>().useGravity = gravidade;
            gravidade = true;

            break;


            case 5 :
            this.GetComponent<Rigidbody>().useGravity = gravidade;
           gravidade = true;

            break;


            case 6 :
            this.GetComponent<Rigidbody>().useGravity = gravidade;
            gravidade = true;

            break;


            case 7 :

            gravidade = false;
            this.GetComponent<Rigidbody>().useGravity = gravidade;
            break;


            case 8 :

            gravidade = true;
            this.GetComponent<Rigidbody>().useGravity = gravidade;
            break;

              case 9 :
            this.GetComponent<Rigidbody>().useGravity = gravidade;
            gravidade = false;
            this.GetComponent<Rigidbody>().useGravity = gravidade;
            break;



            case 10 :

            gravidade = true;
            this.GetComponent<Rigidbody>().useGravity = gravidade;


            break;
         }



   }
    
    void GeradorMassa() {

        float escolheMassa = Mathf.Round(Random.Range(10,20) );
         

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
    
}
