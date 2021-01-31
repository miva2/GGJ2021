using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroAnimation : MonoBehaviour
{
  public void IntroEnded()
  {
    // will load a bit but that's OK
    SceneManager.LoadScene("Scenes/Alley");
  }

    
}
