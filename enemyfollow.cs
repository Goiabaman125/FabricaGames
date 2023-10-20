using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distanceBetween; //voce seleciona a distancia que o inimigo pode começar a perseguir

    private float distance;

    void Start()
    {

    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position) //pega a distancia e retorna no float
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Red2Dag; //calcula o angulo de dois pontos
        
        if(distance < distanceBetween)
        {
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime)// comanda o inimigo a ir atras do player e a velocidade dele
        transform.rotation = Quaternion.Euler(Vector3.forward * angle); //faz o inimigo rotacionar melhor
        }
    }
}