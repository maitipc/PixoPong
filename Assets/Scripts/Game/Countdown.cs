using System.Collections;
using TMPro;
using UnityEngine;

namespace PixoPong.Game
{
    public class Countdown : MonoBehaviour
    {
        private TMP_Text countdownTimer;
        public float time = 3f;
        public bool isCountdownFinished;

        private void Start()
        {
            countdownTimer = GetComponent<TMP_Text>();
            countdownTimer.text = time.ToString();
        }

        private void Update()
        {
            time -= 1 * Time.deltaTime;
            countdownTimer.text = time.ToString("0");

            if (time <= 0)
            {
                countdownTimer.text = "Go!";
                StartCoroutine(DestroyCountdown());
            }
        }

        private IEnumerator DestroyCountdown()
        {
            yield return new WaitForSeconds(1f);
            isCountdownFinished = true;
            gameObject.SetActive(false);
        }
    }
}

