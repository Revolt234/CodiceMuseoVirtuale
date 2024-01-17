using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Video;

public class VideoButtonGenerator : MonoBehaviour
{
    public GameObject buttonPrefab;   // Il prefab del pulsante
    public Transform buttonParent;    // Il genitore dei pulsanti
    public VideoPlayer videoPlayer;   // Il VideoPlayer in cui verranno riprodotti i video
    public GameObject videoDynamic;   // L'oggetto VideoDinamico

    void Start()
    {
        // Ottieni il percorso della cartella "Videos" all'interno di "StreamingAssets"
        string videosFolderPath = Path.Combine(Application.streamingAssetsPath, "Videos");

        // Verifica se la cartella esiste
        if (Directory.Exists(videosFolderPath))
        {
            // Ottieni tutti i file video nella cartella "Videos"
            string[] videoFiles = Directory.GetFiles(videosFolderPath, "*.mp4");

            foreach (string videoFilePath in videoFiles)
            {
                // Estrai il nome del file video senza estensione
                string videoFileName = Path.GetFileNameWithoutExtension(videoFilePath);

                // Crea un nuovo pulsante dalla copia del prefab
                GameObject newButton = Instantiate(buttonPrefab, buttonParent);

                // Imposta il testo del pulsante con il nome del file video
                newButton.GetComponentInChildren<Text>().text = videoFileName;

                // Aggiungi un listener per gestire il clic sul pulsante
                Button buttonComponent = newButton.GetComponent<Button>();
                if (buttonComponent != null)
                {
                    buttonComponent.onClick.AddListener(() => OnVideoButtonClick(videoFilePath));
                }
            }
        }
        else
        {
            Debug.LogWarning("La cartella 'Videos' non esiste in 'StreamingAssets'.");
        }
    }

    // Funzione da chiamare quando si fa clic su un pulsante video
    void OnVideoButtonClick(string videoFilePath)
    {
        
        // Imposta il URL del VideoPlayer al percorso del video selezionato
        videoPlayer.url = "file://" + videoFilePath;
       
        PlayerPrefs.SetString("URL" , "file://" + videoFilePath);
        
    }
}
