using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
  private int MAX_SCORE = 999;

  [SerializeField]
  private int currentScore = 0;

  [SerializeField]
  private SpriteRenderer ones;

  [SerializeField]
  private SpriteRenderer tens;

  [SerializeField]
  private SpriteRenderer hundreds;

  [SerializeField]
  private Sprite sprite0;

  [SerializeField]
  private Sprite sprite1;

  [SerializeField]
  private Sprite sprite2;

  [SerializeField]
  private Sprite sprite3;

  [SerializeField]
  private Sprite sprite4;

  [SerializeField]
  private Sprite sprite5;

  [SerializeField]
  private Sprite sprite6;

  [SerializeField]
  private Sprite sprite7;

  [SerializeField]
  private Sprite sprite8;

  [SerializeField]
  private Sprite sprite9;

  private Dictionary<int, Sprite> spriteMap = new Dictionary<int, Sprite>();

  void Start()
  {
    spriteMap.Add(0, sprite0);
    spriteMap.Add(1, sprite1);
    spriteMap.Add(2, sprite2);
    spriteMap.Add(3, sprite3);
    spriteMap.Add(4, sprite4);
    spriteMap.Add(5, sprite5);
    spriteMap.Add(6, sprite6);
    spriteMap.Add(7, sprite7);
    spriteMap.Add(8, sprite8);
    spriteMap.Add(9, sprite9);

    currentScore = 0;
    SetDigitSprite(hundreds, 0);
    SetDigitSprite(tens, 0);
    SetDigitSprite(ones, 0);
  }

  public void IncreaseScore()
  {
    if (currentScore >= MAX_SCORE)
    {
      return;
    }

    currentScore += 1;
    int[] digits = GetIntArray(currentScore);

    // Jank but functional
    if (digits.Length == 1)
    {
      SetDigitSprite(hundreds, 0);
      SetDigitSprite(tens, 0);
      SetDigitSprite(ones, digits[0]);
    }
    else if (digits.Length == 2)
    {
      SetDigitSprite(hundreds, 0);
      SetDigitSprite(tens, digits[0]);
      SetDigitSprite(ones, digits[1]);
    }
    else if (digits.Length == 3)
    {
      SetDigitSprite(hundreds, digits[0]);
      SetDigitSprite(tens, digits[1]);
      SetDigitSprite(ones, digits[2]);
    }
  }

  private int[] GetIntArray(int num)
  {
    List<int> listOfInts = new List<int>();
    while (num > 0)
    {
      listOfInts.Add(num % 10);
      num = num / 10;
    }
    listOfInts.Reverse();
    return listOfInts.ToArray();
  }

  private void SetDigitSprite(SpriteRenderer renderer, int digit)
  {
    renderer.sprite = spriteMap[digit];
  }
}