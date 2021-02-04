using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnBackToMenu : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Return());
    }

    private IEnumerator Return()
    {
        yield return new WaitForSeconds(31f);
        SceneManager.LoadScene(0);
    }
}