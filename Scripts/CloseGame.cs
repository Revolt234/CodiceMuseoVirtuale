using UnityEngine;
using UnityEngine.UI;
public class CloseGame : MonoBehaviour
{
    void Start()
    {
        // Recupera il componente Button e aggiunge il listener per l'evento di clic
        GetComponent<Button>().onClick.AddListener(QuitGame);
    }

    void QuitGame()
    {
        // Chiude l'applicazione
        Application.Quit();
    }
}

