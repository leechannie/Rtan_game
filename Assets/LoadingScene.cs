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

        // �񵿱� ���� �ҷ��´�, 
        AsyncOperation op = SceneManager.LoadSceneAsync(nextSceneName);

        // �ε��� ������ �̵��Ұ��� ���� 
        op.allowSceneActivation = false;

        float timer = 0.0f;
        
        while (!op.isDone)
        {
            // ȭ�� ���� 
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
                    // ���� ������ �̵� 
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
