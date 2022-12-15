using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoJugador : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator animador;
    private SpriteRenderer sprite;
    
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask terrenoSaltable;
    private enum estadoMov {IDLE, CORRIENDO, SALTANDO, CAYENDO} 
    

    // Start is called before the first frame update
    private void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
        coll =  GetComponent<BoxCollider2D>();
        //animador = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && enTerrreno()){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        actualizarAnimacion();
    }

    private void actualizarAnimacion(){

        estadoMov estado;
        
        if(dirX > 0f){
            estado = estadoMov.CORRIENDO;
            sprite.flipX = false;
        } 
        else if(dirX < 0f){
            estado = estadoMov.CORRIENDO;
            sprite.flipX = true;
        }
        else{
            estado = estadoMov.IDLE;
        }

        if(rb.velocity.y > .1f){
            estado = estadoMov.SALTANDO;
        }
        else if(rb.velocity.y < -.1f){
            estado = estadoMov.CAYENDO;
        }
        //animador.SetInteger("estado", (int) estado);
    }

    private bool enTerrreno(){
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, terrenoSaltable);
    }
}
