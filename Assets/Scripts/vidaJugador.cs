using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vidaJugador : MonoBehaviour
{
    private Rigidbody2D rb; 

    private void Start(){
        rb =  GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(transform.position.y < -4.80)
        {
            reiniciar();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("trampa")){
            reiniciar();
        }
    }


    private void reiniciar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
