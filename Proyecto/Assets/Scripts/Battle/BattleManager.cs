using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // Party del jugador
    public List<GameObject> aliados;

    // Party del enemigo
    public List<GameObject> enemigos;

    // Menús
    public GameObject menuAccion;
    public GameObject menuObjetivo;

    // Número de aliados por escoger acción
    private int restantes;

    // Sonidos
    public AudioClip botonEn;
    public AudioClip botonPos;

    // Lista de acciones a realizar este turno
    public List<Action> acciones = new List<Action>();

    // Almacena la acción actual
    public Action accionAux;

    // Start is called before the first frame update
    void Start()
    {
        // Colocar en sus posiciones
        Aliados();
        Enemigos();

        // Obtener datos de los aliados
        DatosAliados();

        // Número de aliados por escoger acción
        CalcularRestantes();

        // Mostrar menú de acciones
        ElegirAcciones();
    }

    // Obtener datos de los aliados
    private void DatosAliados() {
        aliados[0].GetComponent<Battler>().HP = GameManager.instance.vidaJ1;
        aliados[0].GetComponent<Battler>().maxHP = GameManager.instance.vidaMaxJ1;
        aliados[0].GetComponent<Battler>().velocidad = GameManager.instance.velJ1;
    }

    // Ciclo de batalla
    private void CicloDeBatalla() {
        // Los enemigos eligen sus acciones
        AccionesIA();

        // Ordena las acciones en función de su prioridad y la velocidad de sus usuarios
        acciones.Sort();

        // Ejecutar acciones
        EjecutarAcciones();

        // Vaciar lista de acciones
        EliminarAcciones();

        // Eventos al final del turno
        FinTurno();

        // Número de aliados por escoger acción
        CalcularRestantes();

        // Mostrar menús si el combate debe seguir
        if (Batallar()) {
            ElegirAcciones();
        } else {
            TerminarCombate();
        }
    }

    // Número de aliados por escoger acción
    private void CalcularRestantes() {
        restantes = 0;
        foreach (GameObject aliado in aliados)
        {
            // Contar solo los que puedan luchar
            if (aliado.GetComponent<Battler>().PuedeLuchar()){
                restantes ++;
            }
        }
    }

    // Decide si el combate debe continuar
    private bool Batallar() {
        return restantes > 0 && EnemigosRestantes();
    }

    // Comprueba si quedan enemigos que puedan luchar
    private bool EnemigosRestantes() {
        foreach (GameObject enemigo in enemigos)
        {
            // Si uno de ellos puede luchar
            if (enemigo.GetComponent<Battler>().PuedeLuchar()){
                return true;
            }
        }

        return false;
    }

    // Muestra los menús apropiados para que el jugador escoja sus acciones
    private void ElegirAcciones() {
        menuAccion.gameObject.SetActive(true);
    }

    // Muestra los menús apropiados para que el jugador escoja un objetivo
    private void MostrarElegirObjetivo() {
        menuAccion.gameObject.SetActive(false);
        menuObjetivo.gameObject.SetActive(true);
    }

    // Añade la acción atacar
    public void Atacar() {
        // Crear acción
        accionAux = gameObject.AddComponent<Attack>();
        accionAux.usuario = aliados[0].GetComponent<Battler>();
        ((Attack) accionAux).damage = 40;

        // Elegir objetivo
        MostrarElegirObjetivo();
    }

    // Elige un objetivo para la acción y la añade
    public void ElegirObjetivo(int objetivo) {
        // Ocultar menú objetivo
        menuObjetivo.gameObject.SetActive(false);

        // Añadir acción
        ((Attack) accionAux).objetivo = enemigos[objetivo].GetComponent<Battler>();
        acciones.Add(accionAux);

        // Terminar turno del aliado
        Siguiente();
    }

    // Añade la acción defender
    public void Defender() {
        // Ocultar menú acciones
        menuAccion.gameObject.SetActive(false);

        // Añadir acción
        accionAux = gameObject.AddComponent<SelfStateAction>();
        accionAux.usuario = aliados[0].GetComponent<Battler>();
        accionAux.prioridad = 1;
        State estado = gameObject.AddComponent<State>();
        estado.id = "defendido";
        estado.turnos = 1;
        ((SelfStateAction) accionAux).estado = estado;
        acciones.Add(accionAux);

        // Terminar turno del aliado
        Siguiente();
    }

    // Termina el turno de un aliado e inicia el siguiente
    private void Siguiente() {
        // Disminuir la cuenta de combatientes
        restantes--;

        // Volver a elegir acciones si queda alguien por elegir
        if (restantes > 0) {
            ElegirAcciones();
        } else {
            CicloDeBatalla();
        }
    }

    // Obtiene las acciones de los enemigos
    private void AccionesIA() {
        foreach (GameObject enemigo in enemigos)
        {
            // Contar solo los que puedan luchar
            if (enemigo.GetComponent<Battler>().PuedeLuchar()){
                acciones.Add(enemigo.GetComponent<Battler>().ElegirAccion(this));
            }
        }
    }

    // Ejecuta todas las acciones
    private void EjecutarAcciones() {
        foreach (Action accion in acciones)
        {
            // Comprobar que el usuario puede luchar
            if (accion.usuario.PuedeLuchar()) {
                // Ejecutar acción
                accion.Efecto(this);
            }
        }
    }

    // Eventos al final de cada turno
    private void FinTurno(){
        foreach (GameObject aliado in aliados)
        {
            aliado.GetComponent<Battler>().FinTurno();
        }
        foreach (GameObject enemigo in enemigos)
        {
            enemigo.GetComponent<Battler>().FinTurno();
        }
    }

    // Destruye todas las acciones y reninicia la lista
    private void EliminarAcciones() {
        // Destruir acciones
        foreach (Action accion in acciones)
        {
            Destroy(accion);
        }

        // Reiniciar lista
        acciones = new List<Action>();
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

    // Terminar combate
    public void TerminarCombate(){
        if (restantes >= 1) {
            Victoria();
        } else {
            Derrota();
        }
    }

    // Terminar combate
    public void Victoria(){
        if (restantes >= 1) {
            Victoria();
        } else {
            Derrota();
        }
    }

    // Terminar combate
    public void Derrota(){
    }

    // Sonidos
    public void botonEnter(){
        GameManager.instance.sonido.PlayOneShot(botonEn);
    }

    public void botonPositive(){
        GameManager.instance.sonido.PlayOneShot(botonPos);
    }
}
