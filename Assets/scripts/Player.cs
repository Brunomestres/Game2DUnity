﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float velocidade;
    public Rigidbody2D rig;
    public float forcaPulo;
    bool estaPulando;
    public Animator anim;
    void Start()
    {
        
    }

    
    void Update()
    {
        Movimentar();
        Pular();

    }

    void Movimentar()
    {
        float direcao = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(direcao * velocidade, rig.velocity.y);

        if(direcao > 0f)
        {
            transform.eulerAngles = new Vector2(0f, 0f);

            if(estaPulando == false)
            {
            anim.SetInteger("transition",1);

            }

        }

        if(direcao < 0f)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
            if (estaPulando == false)
            {
                anim.SetInteger("transition", 1);

            }

        }

        if(direcao == 0 && estaPulando == false)
        {
            anim.SetInteger("transition", 0);
        }
    }

    void Pular()
    {
        if(Input.GetButtonDown("Jump") && estaPulando == false)
        {
            rig.AddForce(new Vector2(0f, forcaPulo), ForceMode2D.Impulse);
            estaPulando = true;
            anim.SetInteger("transition", 2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            estaPulando = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("enemieBody"))
        {

        }

        if (collision.CompareTag("enemieHead"))
        {
            rig.AddForce(new Vector2(0f, forcaPulo), ForceMode2D.Impulse);
            Destroy(collision.transform.parent.gameObject);
        }
    }
}
