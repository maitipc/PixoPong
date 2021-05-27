using PixoPong.General;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PixoPong.MainMenu
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button playButton;

        private void Start()
        {
            playButton.onClick.AddListener(OnClickPlayButton);
        }

        private void OnClickPlayButton()
        {
            SceneManager.LoadSceneAsync(SceneNamesConstants.Game);
        }
    }
}
