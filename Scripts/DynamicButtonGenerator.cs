using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicButtonGenerator : MonoBehaviour
{
    public GameObject buttonPrefab; // Il prefab del pulsante che desideri generare
    public Transform buttonParent;  // Il genitore dei pulsanti (pannello, contenitore, ecc.)

    void Start()
    {
        // Carica tutti gli oggetti dalla cartella "Resources"
        GameObject[] objects = Resources.LoadAll<GameObject>("");

        foreach (GameObject obj in objects)
        {
            // Crea un nuovo pulsante dalla copia del prefab
            GameObject newButton = Instantiate(buttonPrefab, buttonParent);

            // Ottieni il nome dell'oggetto e imposta il testo del pulsante
            string objectName = obj.name;
            Debug.Log(objectName);
            newButton.GetComponentInChildren<Text>().text = objectName;

            // Ottieni la componente "GeneraOggetto" dal pulsante
            GeneraOggetto generaOggettoComponent = newButton.GetComponent<GeneraOggetto>();

            // Verifica se la componente è presente
            if (generaOggettoComponent != null)
            {
                // Imposta la variabile "PrefabDaMostrare" nella componente "GeneraOggetto"
                generaOggettoComponent.prefabDaMostrare = obj;
            }

            // Ottieni il pulsante figlio "Delete"
            Button deleteButton = newButton.transform.Find("Delete").GetComponent<Button>();

            // Ottieni la componente "DeleteOggetto" dal pulsante "Delete"
            DeleteOggetto deleteOggettoComponent = deleteButton.GetComponent<DeleteOggetto>();

            // Verifica se la componente è presente
            if (deleteOggettoComponent != null)
            {
                // Imposta la variabile "string" nella componente "DeleteOggetto" con il nome dell'oggetto
                deleteOggettoComponent.prefDaEliminare = objectName+"(Clone)";
            }

            // Aggiungi un listener per gestire il clic sul pulsante
            Button buttonComponent = newButton.GetComponent<Button>();
            if (buttonComponent != null)
            {
                buttonComponent.onClick.AddListener(() => OnButtonClick(objectName));
            }
        }
    }

    // Funzione da chiamare quando si fa clic su un pulsante
    void OnButtonClick(string objectName)
    {
        // Fai qualcosa con l'oggetto associato al pulsante
        // Puoi usare "Resources.Load" per caricare l'oggetto e lavorare con esso.
        // Ad esempio: GameObject loadedObject = Resources.Load<GameObject>(objectName);
    }
}
