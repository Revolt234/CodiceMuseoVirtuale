using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;

public class AttivaOggetto : MonoBehaviour
{
    public GameObject objectToActivate;

    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
        objectToActivate.SetActive(false);
    }



    public void OnClick()
    {
        // Attiva l'oggetto quando il pulsante viene cliccato 
        objectToActivate.SetActive(true);
    }
}