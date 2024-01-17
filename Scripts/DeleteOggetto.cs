using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeleteOggetto : MonoBehaviour
{
   public String prefDaEliminare;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("SceltaUtente") == 1)
        {
            gameObject.SetActive(false);
            
        }
        // Recupera il componente Button e aggiunge il listener per l'evento di clic
        GetComponent<Button>().onClick.AddListener(OnDeleteOggetto);
    }

    public void OnDeleteOggetto()
    {
        string nomeoggetto=prefDaEliminare;
        //string nomeoggetto = generaOggetto.prefabDaMostrare.ToString();
       //string nomeoggetto ="PivotVicta(Clone)"; // devo ottenere il nome del prefab dal bottone padre in modo da generare direttamente l oggetto.
        if (nomeoggetto != null) { 
            Debug.Log("Oggetto da eliminare: " + nomeoggetto);
        }
        else 
        { 
            Debug.LogWarning("L'oggetto con il nome " + nomeoggetto + " non è stato trovato.");
        }

        GameObject oggettodaEliminare = GameObject.Find(nomeoggetto);
        if (oggettodaEliminare != null)
        {
            Destroy(oggettodaEliminare);
        }
        else
        {
            // L'oggetto con il nome specificato non è stato trovato
            Debug.LogWarning("L'oggetto con il nome " + nomeoggetto + " non è stato trovato.");
        }

        
    }

   
}
