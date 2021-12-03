using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // BoxCollider del sprite
    private BoxCollider2D boxCollider;

    // Vector de movimiento
    private Vector3 moveDelta;

    // Detector de colisión
    private RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        // Crear BoxCollider2D
        boxCollider = GetComponent<BoxCollider2D>();
    }



    // Update is called once per frame
    void FixedUpdate()
    {        
        // Resetear moveDelta
        ResetearMoveDelta();

        // Cambiar orientación del sprite (derecha o izquierda)
        CambiarOrientacion();

        // Mover sprite
        Mover();
    }

    // Resetear moveDelta usando input
    private void ResetearMoveDelta() {
        // Obtener botones de movimiento pulsados
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Resetear moveDelta
        moveDelta = new Vector3(x, y, 0);
    }

    // Cambiar orientación del sprite (derecha o izquierda) según input
    private void CambiarOrientacion() {
        if (moveDelta.x > 0) {
            // Derecha
            transform.localScale = Vector3.one;
        } else if (moveDelta.x < 0) {
            // Izquierda
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    // Mover sprite según input
    private void Mover() {
        Vector3 offset = boxCollider.offset;

        // Detección de colisión en y
        hit = Physics2D.BoxCast(transform.position + offset, boxCollider.size, 0, new Vector3(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

        // Comprobar que no hay colisión en y
        if (hit.collider == null) {
            // Mover y
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0); // * Time.deltaTime es fundamental para que la velocidad no dependa de los FPS
        }
        
        // Detección de colisión en x
        hit = Physics2D.BoxCast(transform.position + offset, boxCollider.size, 0, new Vector3(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

        // Comprobar que no hay colisión en x
        if (hit.collider == null) {
            // Mover x
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
