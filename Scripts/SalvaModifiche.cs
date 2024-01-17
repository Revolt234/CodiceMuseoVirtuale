using UnityEngine;
using UnityEngine.UI;


public class SalvaModifiche : MonoBehaviour
{
    public GestoreSalvataggioCaricamento gestoreSalvataggio; // Riferimento al tuo script GestoreSalvataggioCaricamento

    private void Start()
    {
        if (PlayerPrefs.GetInt("SceltaUtente")==1)
        {
            gameObject.SetActive(false);
        }
        else {
            Button pulsante = GetComponent<Button>();

            // Aggiungi un listener per gestire il click sul pulsante
            pulsante.onClick.AddListener(Salva);
        }
        // Ottieni il componente Button dal pulsante
        
    }

    private void Salva()
    {
        // Richiama il metodo per il salvataggio dei dati dal tuo script GestoreSalvataggioCaricamento
        gestoreSalvataggio.SalvaDati();
    }
}

