using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    // Posición del jugador
    public Transform lookAt;

    // Márgenes del movimiento dentro de la cámara
    public float margenX = 0.3f;
    public float margenY = 0.2f;

    // Vector de movimiento
    private Vector3 delta = Vector3.zero;

    // Update is called once per frame
    void LateUpdate()
    {
        delta = Vector3.zero;

        // Calcular X
        CalcularX();

        // Calcular Y
        CalcularY();

        // Mover cámara
        transform.position += new Vector3(delta.x, delta.y, 0);
    }

    // Calcular X
    private void CalcularX() {
        // Calcular X
        float lookX = lookAt.position.x;
        float transX = transform.position.x;
        float deltaX = lookX - transX;

        // Comprobar si hay que modificar la posición de la cámara
        if (deltaX > margenX || deltaX < -margenX) {
            // Comprobar en qué sentido hay que modificar la posición de la cámara
            if (transX < lookX) {
                // Hacia la derecha
                delta.x = deltaX - margenX;
            } else {
                // Hacia la izquierda
                delta.x = deltaX + margenX;
            }
        }
    }

    // Calcular Y
    private void CalcularY() {
        // Calcular Y
        float lookY = lookAt.position.y;
        float transY = transform.position.y;
        float deltaY = lookY - transY;

        // Comprobar si hay que modificar la posición de la cámara
        if (deltaY > margenY || deltaY < -margenY) {
            // Comprobar en qué sentido hay que modificar la posición de la cámara
            if (transY < lookY) {
                // Hacia arriba
                delta.y = deltaY - margenY;
            } else {
                // Hacia abajo
                delta.y = deltaY + margenY;
            }
        }
    }


}
