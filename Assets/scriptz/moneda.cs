
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneda : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Gira el elemento una cantidad diferente en cada dirección en cada intervalo de tiempo.
        //frame
        //Se vuelve ocupar la clase Time.deltaTime, tiempo transcurrido en cada Frame (60 fps), 1/60s).
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

    }
}
