using UnityEngine;

public class Score : MonoBehaviour
{
  private int currentScore = 0;

  void Start()
  {
    currentScore = 0;
  }

  public void IncreaseScore()
  {
    currentScore += 1;
    print($"Current score: ${currentScore}");
  }
}
