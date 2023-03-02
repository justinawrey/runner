using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
  [SerializeField]
  private PlayerInputController inputController;

  private void Start()
  {
    StartCoroutine(inputController.WaitForKeyPress(LoadGame));
  }

  private void LoadGame()
  {
    SceneManager.LoadScene("Game");
  }
}