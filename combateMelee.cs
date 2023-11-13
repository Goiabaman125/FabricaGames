using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : MonoBehaviour
{
    public float attackRange = 2f; //variaveis do ataque inimigo
    public int attackDamage = 10;
    public float attackCooldown = 2f;
    public float chaseRange = 10f;  //perseguição, apenas quando necessario

    private GameObject player;
    private NavMeshAgent agent;
    private bool canAttack = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()  //calcula a distancia do jogador e ataca ou não depedendo da distancia
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= attackRange)
        {
            if (canAttack)
            {
                Attack();
            }
        }
        else if (distance <= chaseRange)
        {
            Chase();
        }
    }

    private void Chase() //opção opicional de perseguir o inimigo
    {
        agent.SetDestination(player.transform.position);
    }

    private void Attack()
    {
        // faz o jogador tomar dano
        player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        

        canAttack = false;
        Invoke("ResetAttack", attackCooldown);
    }

    private void ResetAttack()
    {
        canAttack = true;
    }
}