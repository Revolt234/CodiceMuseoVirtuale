using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CaricaScena : MonoBehaviour
{
    public int permessi = 0;
    public int indiceScenaDaCaricare; // Imposta l'indice della scena che vuoi caricare

    void Start()
    {
       
        Button button = GetComponent<Button>();

        
            button.onClick.AddListener(CaricaLaScena);
        
    }

    void CaricaLaScena()
    {
        PlayerPrefs.SetInt("SceltaUtente", permessi);
        // Carica la scena con indice 1 (o il nome della tua scena)
      
        // Carica la scena con l'indice specificato
        SceneManager.LoadScene(indiceScenaDaCaricare);
    }
}
