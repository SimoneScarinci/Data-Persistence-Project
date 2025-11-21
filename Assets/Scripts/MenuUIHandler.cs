using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField NameInputField;
    public TextMeshProUGUI BestScoreText;
    

    private void Start()
    {
        if (DataManager.Instance != null && DataManager.Instance.BestScore > 0)
        {
            BestScoreText.text = $"Best Score : {DataManager.Instance.BestPlayerName} : {DataManager.Instance.BestScore}";
        }
        else
        {
            BestScoreText.text = "Best Score : -";
        }
    }

    public void StartNew()
    {
        if (DataManager.Instance != null)
        {
            DataManager.Instance.PlayerName = NameInputField.text;
        }

        // Assumiamo che la scena di gioco sia index 1
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
