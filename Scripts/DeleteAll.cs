using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DeleteAll : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("SceltaUtente") == 1)
        {
            gameObject.SetActive(false);
        }
            // Recupera il componente Button e aggiunge il listener per l'evento di clic
            GetComponent<Button>().onClick.AddListener(OnDeletePlayerPrefs);
    }
    public void OnDeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("PlayerPrefs eliminati!");
        SceneManager.LoadScene(1);
    }
}
