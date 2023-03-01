using System;
using System.Collections;
using UnityEngine;

class PlayerInputController : MonoBehaviour
{
  private bool inputEnabled = true;

  public bool JumpInputDown => inputEnabled ? Input.GetKeyDown(KeyCode.Space) : false;
  public bool JumpInputUp => inputEnabled ? Input.GetKeyUp(KeyCode.Space) : false;

  public void DisableInput()
  {
    inputEnabled = false;
  }

  public void EnableInput()
  {
    inputEnabled = true;
  }

  public IEnumerator WaitForKeyPress(Action cb)
  {
    while (!Input.anyKeyDown)
    {
      yield return null;
    }

    cb();
  }
}