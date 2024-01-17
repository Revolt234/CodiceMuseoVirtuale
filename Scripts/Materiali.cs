using UnityEngine;

public class Materiali : MonoBehaviour
{
    public GameObject DaAttivare;
   

    void Start()
    {
        
          
        if (PlayerPrefs.GetInt("SceltaUtente") == 0)
        {
            enabled = true;
            DaAttivare.SetActive(true);
        }

            
        
        
    }

    void Update()
    {
        // Verifica se il tasto "E" è stato premuto
    /*    if (Input.GetKeyDown(KeyCode.E) && pannelloMateriali != null)
        {
            // Attiva o disattiva il pannello con il tag "Materiali"
            pannelloMateriali.SetActive(!pannelloMateriali.activeSelf);
        }*/
    }
}
