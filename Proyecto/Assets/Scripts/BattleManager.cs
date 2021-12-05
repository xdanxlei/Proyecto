using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // Party del jugador
    public List<GameObject> aliados;

    // Party del enemigo
    public List<GameObject> enemigos;

    // Start is called before the first frame update
    void Start()
    {
        // Colocar en sus posiciones
        Aliados();
        Enemigos();
    }

    // Colocar aliados
    private void Aliados() {
        // Número de aliados
        int nAliados = aliados.Count;

        // Posición del más alto
        float inicial =  -0.3f + 0.3f * (nAliados - 1);

        // Establecer cada posición
        for (int i = 0; i < nAliados; i++)
        {
            float y = inicial - 0.3f * i;
            aliados[i].transform.position = new Vector3(-0.7f, y, 0);
        }
    }

    // Colocar enemigos
    private void Enemigos() {
        // Número de enemigos
        int nEnemigos = enemigos.Count;

        // Posición del más alto
        float inicial =  -0.3f + 0.3f * (nEnemigos - 1);

        // Establecer cada posición
        for (int i = 0; i < nEnemigos; i++)
        {
            float y = inicial - 0.3f * i;
            enemigos[i].transform.position = new Vector3(0.7f, y, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
