using PixoPong.General;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixoPong.Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameOverUI gameOverUI;
        private void OnEnable()
        {
            ScoreAreaController.OnEnterScoreArea += TriggerGameOver;
        }

        private void TriggerGameOver(bool isPlayerScoreArea)
        {
            gameOverUI.hasPlayerWon = isPlayerScoreArea;
            gameOverUI.gameObject.SetActive(true);
        }

        private void OnDisable()
        {
            ScoreAreaController.OnEnterScoreArea -= TriggerGameOver;
        }
    }
}
