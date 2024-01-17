using UnityEngine;
using UnityEngine.Video;

public class VideoSalvato : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Riferimento al VideoPlayer

    void Start()
    {
        // Controlla se esiste un URL salvato nelle PlayerPrefs
        string savedURL = PlayerPrefs.GetString("URL");

        if (!string.IsNullOrEmpty(savedURL))
        {
            // Imposta l'URL del VideoPlayer se è stato salvato
            videoPlayer.url = savedURL;
            videoPlayer.Prepare(); // Prepara il video
            
        }
    }
}
