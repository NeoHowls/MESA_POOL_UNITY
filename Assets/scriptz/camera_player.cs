
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_player : MonoBehaviour
{
    //identificar el jugador sin ser su hijo, se hará por Script
    //variables.
    //Importante.
    //al dejarlo publico se puede asignar el objeto desde el mismo Unity
    public GameObject jugador;
    //variable para registrar la diferencia de la camara y el jugador.
    private Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        //diferencia de posición entre la camara y la del jugador
        offset = transform.position - jugador.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //efecto de tener la camara retrasada del jugador
        //Problema del update, pues va de frame a frame y se necesita ejecutar despues de los frames.
    }
    
    //se ejecuta todo el frame pero despues de haber procesado las imagenes, esto es más exacto para la camara.
    //para que quede optimo y no lento.
    void LateUpdate()
    {
        //actualiza la posición de la camara
        transform.position = jugador.transform.position + offset;
        
    }
}