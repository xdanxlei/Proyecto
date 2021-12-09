using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    // Filtro de objetos
    public ContactFilter2D filtro;

    // BoxCollider
    private BoxCollider2D boxCollider;

    // Array de colisiones
    private Collider2D[] colisiones = new Collider2D[10];

    // Start is called before the first frame update
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // Calcular colisiones
        boxCollider.OverlapCollider(filtro, colisiones);

        // Comprobar colisiones una a una
        for (int i = 0; i < colisiones.Length; i++)
        {
            if (colisiones[i] == null) {
                // Si no hay colisión
                continue;
            }

            OnCollide(colisiones[i]);

            // Vaciar array
            colisiones[i] = null;
        }
    }

    // Al colisionar con algo
    protected virtual void OnCollide(Collider2D colision) {
    }
}
