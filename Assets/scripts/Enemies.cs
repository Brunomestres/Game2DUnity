using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Rigidbody2D rig;
    public float velocidade;
    public float tempoNaDirecao;
    float tempo;
    void Start()
    {
        
    }

    
    void Update()
    {
        tempo += Time.deltaTime;
        
        if(tempo >= tempoNaDirecao)
        {
            velocidade = -velocidade;
            tempo = 0f;
        }

        if(velocidade > 0f)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }

        if(velocidade < 0f)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        rig.velocity = new Vector2(velocidade, rig.velocity.y);

    }
}
