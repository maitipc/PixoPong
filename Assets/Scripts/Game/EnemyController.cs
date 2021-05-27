using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixoPong.Game
{    
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Transform ballTarget;

        public float Speed;        

        private void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, 
                new Vector2(transform.position.x, ballTarget.position.y), Speed * Time.deltaTime);
        }

    }
}
    
