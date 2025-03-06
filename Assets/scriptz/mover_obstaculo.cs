
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //for NavMeshAgent

public class mover_obstaculo : MonoBehaviour
{

    private void Start()
    {

    }

    private void Update()
    {
        {
            int random_number = Random.Range(1,200);
            int duracion = Random.Range(600,650);


            switch (random_number)
            {
                case 1:
                for (int i = 0; i < duracion; i++) 
                {
                    gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 50f *  Time.deltaTime));

                    gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0));
                    

                }    
                
                break;

                case 2:
                for (int i = 0; i < duracion; i++) 
                {
                    gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -50f * Time.deltaTime));

                    gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0));

                }   
                break;

                case 3:
                for (int i = 0; i < duracion; i++) 
                {
                    gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0 * Time.deltaTime, 0, 0));


                } 

                break;
            
        }

    }
}
}