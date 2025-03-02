using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public float delayBeforeNextScene = 5f; // 씬 변경까지 대기할 시간
    private bool isTransitioning = false;

    private void Start()
    {
        StartCoroutine(WaitAndFadeOut());
    }

    private IEnumerator WaitAndFadeOut()
    {
        yield return new WaitForSeconds(delayBeforeNextScene); // 대기

        if (!isTransitioning)
        {
            isTransitioning = true;
            SceneManager.LoadScene("3_YSA_Menu"); // 특정 씬으로 전환
        }
    }
}
