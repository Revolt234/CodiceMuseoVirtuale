using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class FileUpload : MonoBehaviour
{
    public string videoFolder = "Video"; // Specifica il nome della cartella contenente i video sul desktop

    private VideoPlayer videoPlayer;
    private string[] videoFiles;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        // Ottieni il percorso della cartella "Videos" all'interno di "StreamingAssets"
        string videosFolderPath = Path.Combine(Application.streamingAssetsPath, "Videos");

        // Verifica se la cartella esiste
        if (Directory.Exists(videosFolderPath))
        {
            // Ottieni tutti i file nella cartella "Videos"
            string[] videoFiles = Directory.GetFiles(videosFolderPath, "*.mp4");

            foreach (string videoFilePath in videoFiles)
            {
                // Elimina i file video esistenti
                File.Delete(videoFilePath);
            }
        }

        // Dopo aver rimosso i file esistenti, carica i nuovi video
        LoadVideosFromDesktop();
    }

    void LoadVideosFromDesktop()
    {
        // Ottieni il percorso completo della cartella sul desktop
        string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        string folderPath = Path.Combine(desktopPath, "ProvaEditorMuseo", videoFolder);

        // Verifica se la cartella esiste
        if (Directory.Exists(folderPath))
        {
            // Ottieni tutti i file video nella cartella
            videoFiles = Directory.GetFiles(folderPath, "*.mp4");

            // Copia i video nella cartella "StreamingAssets" del progetto
            string streamingAssetsPath = Path.Combine(Application.streamingAssetsPath, "Videos");
            Directory.CreateDirectory(streamingAssetsPath);

            foreach (string videoFile in videoFiles)
            {
                string destinationPath = Path.Combine(streamingAssetsPath, Path.GetFileName(videoFile));
                File.Copy(videoFile, destinationPath, true);
            }
        }
        else
        {
            Debug.Log("La cartella dei video sul desktop non esiste.");
        }
    }

}
