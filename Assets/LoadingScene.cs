using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] Image progressBar;

    private static string nextSceneName;

    public static void ReserveLoadScene(string sceneName)
    {
        nextSceneName = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        yield return null;

        // 비동기 씬을 불러온다, 
        AsyncOperation op = SceneManager.LoadSceneAsync(nextSceneName);

        // 로딩이 끝나면 이동할건지 설정 
        op.allowSceneActivation = false;

        float timer = 0.0f;
        
        while (!op.isDone)
        {
            // 화면 갱신 
            yield return null;

            timer += Time.deltaTime;
            if (op.progress < 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
                if (progressBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);
                if (progressBar.fillAmount == 1.0f)
                {
                    // 다음 씬으로 이동 
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
