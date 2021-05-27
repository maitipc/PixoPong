using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace PixoPong.Game
{
    public class BallController : MonoBehaviour
    {
        public Countdown countdown;
        public float ballSpeed;
        private AudioSource audioSource;
        private Vector2 velocity;
        private bool hasLaunched;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        /**
         * Ao invés de usar o velocity do Rigidbody, para não usar a física da Unity,
         * apliquei a fórmula de movimento uniforme: Posição inicial + (velocidade * tempo)
         * O Translate irá pegar a posição atual e incrementar o valor calculado de
         * velocidade * tempo.
         */
        private void FixedUpdate()
        {
            if (countdown.isCountdownFinished && !hasLaunched)
            {
                LaunchBall();

            }
            transform.Translate(velocity * Time.fixedDeltaTime);
        }

        private void LaunchBall()
        {
            hasLaunched = true;
            float x = Random.Range(0, 2) == 0 ? -1 : 1;
            float y = Random.Range(0, 2) == 0 ? -1 : 1;
            velocity = new Vector2(x, y).normalized * ballSpeed;
        }

        /**
         * Para fazer a colisão sem usar física da Unity, apliquei a fórmula:
         * velocidade nova = velocidade − 2 (velocidade * normal) * normal
         * sendo que velocidade * normal é o dot product.
         * Usei a função Dot da Unity para calcular o Dot product.
         */
        private void OnCollisionEnter2D(Collision2D other)
        {
            audioSource.Play();
            velocity = velocity - 2 * (Vector2.Dot(velocity, other.contacts[0].normal)) * other.contacts[0].normal;
        }
    }
}
