using UnityEngine;
using UnityEngine.UI;

public class DisattivaOggetto : MonoBehaviour
{
    public GameObject objectToDeactivate;

    void Start()
    {
        // Aggiungi un listener per il click del button
        GetComponent<Button>().onClick.AddListener(DeactivateObject);
    }

    void DeactivateObject()
    {
        // Disattiva l'oggetto specificato
        Time.timeScale = 1;
        objectToDeactivate.SetActive(false);
    }
}
