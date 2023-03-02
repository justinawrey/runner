using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

static class SceneLoader
{
  public static IEnumerator AsyncLoad(string name)
  {
    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);
    while (!asyncLoad.isDone)
    {
      yield return null;
    }
  }
}