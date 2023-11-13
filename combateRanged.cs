using System;
using UnityEngine;

public class InimigoAtaqueADistancia : MonoBehaviour
{
    public Transform jogador;
    public GameObject projetilPrefab;
    public float alcanceDeAtaque = 10.0f;
    public float velocidadeProjetil = 10.0f;
    public float taxaDeDisparo = 1.0f;

    private float tempoDesdeOUltimoDisparo = 0.0f;

    private void Update()
    {
        // Verifica se o jogador está presente
        if (jogador == null)
        {
            return;
        }

        // Calcula a distância entre o inimigo e o jogador
        float distanciaAoJogador = Vector3.Distance(transform.position, jogador.position);

        // Se o jogador estiver dentro do alcance de ataque
        if (distanciaAoJogador <= alcanceDeAtaque)
        {
            tempoDesdeOUltimoDisparo += Time.deltaTime;

            // Dispara projéteis em direção ao jogador com uma taxa definida
            if (tempoDesdeOUltimoDisparo >= 1.0f / taxaDeDisparo)
            {
                Atirar();
                tempoDesdeOUltimoDisparo = 0.0f;
            }
        }
    }

    private void Atirar()
    {
        // Cria um projetil a partir do prefab e define sua posição e rotação
        GameObject projetil = Instantiate(projetilPrefab, transform.position, transform.rotation);

        // Obtém a direção em que o projetil deve ser disparado (em direção ao jogador)
        Vector3 direcao = (jogador.position - transform.position).normalized;

        // Obtém o componente Rigidbody do projetil e aplica uma força para movê-lo
        Rigidbody rb = projetil.GetComponent<Rigidbody>();
        rb.velocity = direcao * velocidadeProjetil;
    }
}
