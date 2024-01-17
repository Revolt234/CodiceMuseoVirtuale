using UnityEngine;

public class CambioMaterialePannello : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Reperto"))
        {
            NomePrefabAssociato nomePrefabScript = collision.gameObject.GetComponent<NomePrefabAssociato>();
            if (nomePrefabScript != null)
            {
                string nomeAlbedo = nomePrefabScript.nomeAlbedo;

                // Cerca il figlio "descrizione" sull'oggetto 1 
                Transform figlioDescrizione = transform.Find("descrizione");

                if (figlioDescrizione != null)
                {
                    // Cerca il figlio "map_italy" in "descrizione" 
                    Transform figlioMapItaly = figlioDescrizione.Find("map_italy");

                    if (figlioMapItaly != null)
                    {
                        Renderer rend = figlioMapItaly.GetComponent<Renderer>();

                        // Carica la texture (Albedo) dalla cartella Resources 
                        Texture albedoTexture = Resources.Load<Texture>(nomeAlbedo);

                        if (albedoTexture != null)
                        {
                            // Applica la texture (Albedo) al materiale dell'oggetto figlio 
                            rend.material.SetTexture("_MainTex", albedoTexture);
                        }
                        else
                        {
                            // Avviso invece di errore 
                            Debug.LogWarning("Texture (Albedo) non trovata: " + nomeAlbedo);
                        }
                    }
                    else
                    {
                        Debug.LogError("Oggetto figlio 'map_italy' non trovato in 'descrizione' su oggetto 1.");
                    }
                }
                else
                {
                    Debug.LogError("Oggetto figlio 'descrizione' non trovato su oggetto 1.");
                }
            }
            else
            {
                Debug.LogError("Script NomePrefab non trovato sull'oggetto 2.");
            }
        }
    }
}