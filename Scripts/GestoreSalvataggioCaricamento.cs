using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GestoreSalvataggioCaricamento : MonoBehaviour
{
    public SalvataggioDati salvataggioDati;
    public Button pulsanteSalva;
    public GameObject museo;

    private void Start()
    {
        CaricaDati();
        pulsanteSalva.onClick.AddListener(SalvaDati);
    }

    public void SalvaDati()
    {
        // Crea una lista di OggettoSalvato
        List<OggettoSalvato> oggettiDaSalvare = new List<OggettoSalvato>();

        foreach (Transform child in museo.transform)
        {
            NomePrefabAssociato nomePrefabComponent = child.GetComponent<NomePrefabAssociato>();
            if (nomePrefabComponent != null)
            {
                // Ottieni il nome del prefab associato all'oggetto
                string nomePrefab = nomePrefabComponent.nomePrefab;

                // Aggiungi l'oggetto alla lista senza una chiave univoca
                OggettoSalvato oggettoDaSalvare = new OggettoSalvato();
                oggettoDaSalvare.nomePrefab = nomePrefab;
                oggettoDaSalvare.posizione = child.transform.position;
                oggettoDaSalvare.rotazione = child.transform.rotation;
                oggettiDaSalvare.Add(oggettoDaSalvare);
            }
        }

        // Chiamare la funzione SalvaDati dal tuo script di SalvataggioDati
        salvataggioDati.SalvaDati(oggettiDaSalvare);
    }

    private void CaricaDati()
    {
        List<OggettoSalvato> oggettiSalvati = salvataggioDati.CaricaDati();

        foreach (OggettoSalvato oggettoSalvato in oggettiSalvati)
        {
            GameObject prefabDaIstanziare = Resources.Load<GameObject>(oggettoSalvato.nomePrefab);

            if (prefabDaIstanziare != null)
            {
                GameObject oggettoIstanziato = Instantiate(prefabDaIstanziare, oggettoSalvato.posizione, oggettoSalvato.rotazione);
                oggettoIstanziato.transform.SetParent(museo.transform);
            }
            else
            {
                Debug.LogWarning("Prefab non trovato: " + oggettoSalvato.nomePrefab);
            }
        }
    }
}
