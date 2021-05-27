using PixoPong.General;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PixoPong.Game
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private Button playAgainBtn;
        [SerializeField] private TMP_Text gameOverTxt;

        public bool hasPlayerWon;

        private void Start()
        {
            playAgainBtn.onClick.AddListener(OnPlayAgainClicked);
            ShowFinalResult();
        }

        private void ShowFinalResult()
        {
            if (hasPlayerWon)
            {
                gameOverTxt.color = Color.green;
                gameOverTxt.text = "YOU WON!";
            }
            else
            {
                gameOverTxt.color = Color.red;
                gameOverTxt.text = "YOU LOSE!";
            }
        }

        private void OnPlayAgainClicked()
        {
            SceneManager.LoadSceneAsync(SceneNamesConstants.Game);
        }
    }
}
