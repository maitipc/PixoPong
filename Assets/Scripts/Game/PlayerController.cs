using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixoPong.Game
{
    public class PlayerController : MonoBehaviour
    {
        public float Speed;

        private void Update()
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector2.down * Speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector2.up * Speed * Time.deltaTime);
            }
        }
    }
}
    
