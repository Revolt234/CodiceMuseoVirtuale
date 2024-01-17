using UnityEngine;
using UnityEngine.UI;

public class GeneraOggetto : MonoBehaviour
{
    public GameObject prefabDaMostrare;
    private GameObject oggettoIstanziato;
    private bool mostraOggetto = false;
    private Transform museo; // Cambiato il tipo da GameObject a Transform 

    public GameObject GetPrefabDaMostrare()
    {
        return prefabDaMostrare;
    }

    public void Start()
    {
        // Trova l'oggetto con il tag "Museo" e assegna il suo transform a "museo" 
        museo = GameObject.FindWithTag("Museo").transform;

        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void Update()
    {
        GameObject[] oggettiReperto = GameObject.FindGameObjectsWithTag("Reperto");
        int t = 0;
        // Ora puoi scorrere l'array di oggetti "reperto"  
        foreach (GameObject reperto in oggettiReperto)
        {
            // Ottieni lo script associato all'oggetto  
            if (reperto.GetComponent<NomePrefabAssociato>().nomePrefab + " (UnityEngine.GameObject)" == gameObject.GetComponent<GeneraOggetto>().prefabDaMostrare.ToString())
            {
                t = 1;
                gameObject.GetComponent<Button>().interactable = false;
            }
        }
        if (t == 0)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
    }

    public void OnClick()
    {
        MostraOggettoSopraPiedistallo();
    }

    void MostraOggettoSopraPiedistallo()
    {
        if (prefabDaMostrare != null)
        {
            Camera telecamera = Camera.main; // Assume che la telecamera principale sia quella che vuoi utilizzare 

            if (telecamera != null)
            {
                GameObject[] piedistalli = GameObject.FindGameObjectsWithTag("Piedistallo");
                GameObject piedistalloPiùVicino = null;
                float distanzaMinima = Mathf.Infinity;

                foreach (GameObject piedistallo in piedistalli)
                {
                    float distanza = Vector3.Distance(telecamera.transform.position, piedistallo.transform.position);

                    if (distanza < distanzaMinima)
                    {
                        distanzaMinima = distanza;
                        piedistalloPiùVicino = piedistallo;
                    }
                }
                if (piedistalloPiùVicino != null)
                {
                    Vector3 posizionePiedistallo = piedistalloPiùVicino.transform.position + Vector3.up * 1.50f; // Altezza sopra il piedistallo 

                    oggettoIstanziato = Instantiate(prefabDaMostrare, posizionePiedistallo, Quaternion.identity);
                    mostraOggetto = true;

                    // Imposta il padre dell'oggetto istanziato come l'oggetto Museo 
                    oggettoIstanziato.transform.SetParent(museo);

                    // Trova tutti gli oggetti con tag "centroStanza" 
                    GameObject[] oggettiCentroStanza = GameObject.FindGameObjectsWithTag("centroStanza");

                    if (oggettiCentroStanza.Length > 0)
                    {
                        GameObject centroStanzaPiùVicino = null;
                        float distanzaMinimaCentroStanza = Mathf.Infinity;
                        foreach (GameObject centroStanza in oggettiCentroStanza)
                        {
                            float distanzaCentroStanza = Vector3.Distance(oggettoIstanziato.transform.position, centroStanza.transform.position);

                            if (distanzaCentroStanza < distanzaMinimaCentroStanza)
                            {
                                distanzaMinimaCentroStanza = distanzaCentroStanza;
                                centroStanzaPiùVicino = centroStanza;
                            }
                        }
                        if (centroStanzaPiùVicino != null)
                        {
                            // Calcola la direzione verso l'oggetto "centroStanza" più vicino 
                            Vector3 direzione = centroStanzaPiùVicino.transform.position - oggettoIstanziato.transform.position;
                            // Imposta l'angolo di inclinazione dell'asse X (rotazione X) a zero 
                            direzione.y = 0;
                            // Calcola la rotazione a partire dalla direzione 
                            Quaternion rotazione = Quaternion.LookRotation(direzione);
                            // Applica la rotazione all'oggetto generato 
                            oggettoIstanziato.transform.rotation = rotazione;
                        }
                    }
                }
            }
        }
    }

}