
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class player_control : MonoBehaviour {
    private Rigidbody objeto;
    public int contador_coleccion;

    public GameObject respawn;
    public GameObject text_end;
    public  Text textPuntaje;
    public  Text textTiempo;
    public  Text final_text;
    private int minutos, segundos, miliseg;
    private float tiempo_pasado;
    public bool control_change = true;

    public bool tiempo_val = true;
    public float velocidad = 30.0f;

    // Codigo perteneciente a Kop Desarrollo
    public LayerMask capaTransitable;
    private NavMeshAgent miAgente;

    //
    // Start is called before the first frame update
    void Start()
    {
        objeto = GetComponent<Rigidbody>();

        respawn = GameObject.FindWithTag("p2");
        text_end = GameObject.FindWithTag("text_ui");
        text_end.SetActive(false);

        // Codigo perteneciente a Kop Desarrollo
        miAgente = this.GetComponent<NavMeshAgent>();
        //

    }

    // Update is called once per frame

    void FixedUpdate()
    {
        // se crean la variables para capturar las posiciones del movimiento del teclado
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");
        //Se crea el Vector3 para capturar el movimiento del jugador
        Vector3 movObjeto = new Vector3(movH, 0.0f, movV);
        // Se asigna el movimiento por desplazamiento al RigidBody
        
        textPuntaje.text = "SCORE: " + contador_coleccion.ToString(); 

        if (tiempo_val == true)
        {tiempo_pasado += Time.deltaTime;}
        if (Input.GetKey("m")) 
        {
            control_change = true;
            Debug.Log("Modo Raton activado");
            Debug.Log(control_change);
        }

        if (Input.GetKey("t")) 
        {
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            control_change = false;
            Debug.Log("Modo teclado activado");
            Debug.Log(control_change);
        }

        if (control_change == false) 

        {
            gameObject.GetComponent<NavMeshAgent>().enabled = true;

            Debug.Log("Modo teclado activado");
            objeto.AddForce(movObjeto * velocidad);
        }

        if (control_change == true) 
        {

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 100))
                    {
                        miAgente.SetDestination(hit.point);
                    }
            }
        }


        minutos = (int)(tiempo_pasado/ 60f); 
        segundos = (int)(tiempo_pasado - minutos/ 60f);  
        miliseg = (int)((tiempo_pasado - (int)tiempo_pasado)* 100f);
        
        textTiempo.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, miliseg);

        if (contador_coleccion == 20)
            {
                Debug.Log("esta listo");
                

                tiempo_val = false;
                text_end.SetActive(true);
                final_text.text = string.Format("El tiempo demorado es de {0:00}:{1:00}:{2:00} y el puntaje consegido es de "+ contador_coleccion + "", minutos, segundos, miliseg);

                gameObject.SetActive(false);


            }



        

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccion"))
        {


            other.gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject, 0.6f);
            contador_coleccion += 1;
            Debug.Log("Contador colecciones: "+ contador_coleccion);

            

            

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("puerta"))
        {
            if (contador_coleccion == 10)
            {
                Debug.Log("esta listo");
                
                respawn.transform.position = new Vector3(-1.89f, 1.665f,9.83f);


            }
            
        }
 
    }

    //Sonido pared
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("pared"))
        {


            other.gameObject.GetComponent<AudioSource>().Play();


            

            

        }
    }
    
}
    




