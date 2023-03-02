using UnityEngine;

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
    StartCoroutine(SceneLoader.AsyncLoad("Game"));
  }
}