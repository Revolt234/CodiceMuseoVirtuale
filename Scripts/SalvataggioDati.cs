using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class OggettoSalvato
{
    public string nomePrefab;
    public Vector3 posizione;
    public Quaternion rotazione;
}

public class SalvataggioDati : MonoBehaviour
{
    public void SalvaDati(List<OggettoSalvato> oggettiDaSalvare)
    {
        int numeroOggetti = oggettiDaSalvare.Count;
        PlayerPrefs.SetInt("NumeroOggetti", numeroOggetti);

        for (int i = 0; i < numeroOggetti; i++)
        {
            OggettoSalvato oggettoDaSalvare = oggettiDaSalvare[i];

            PlayerPrefs.SetString("NomePrefab_" + i, oggettoDaSalvare.nomePrefab);
            PlayerPrefs.SetFloat("PosizioneX_" + i, oggettoDaSalvare.posizione.x);
            PlayerPrefs.SetFloat("PosizioneY_" + i, oggettoDaSalvare.posizione.y);
            PlayerPrefs.SetFloat("PosizioneZ_" + i, oggettoDaSalvare.posizione.z);

            PlayerPrefs.SetFloat("RotazioneX_" + i, oggettoDaSalvare.rotazione.x);
            PlayerPrefs.SetFloat("RotazioneY_" + i, oggettoDaSalvare.rotazione.y);
            PlayerPrefs.SetFloat("RotazioneZ_" + i, oggettoDaSalvare.rotazione.z);
            PlayerPrefs.SetFloat("RotazioneW_" + i, oggettoDaSalvare.rotazione.w);
        }
    }

    public List<OggettoSalvato> CaricaDati()
    {
        int numeroOggetti = PlayerPrefs.GetInt("NumeroOggetti", 0);
        List<OggettoSalvato> oggettiSalvati = new List<OggettoSalvato>();

        for (int i = 0; i < numeroOggetti; i++)
        {
            OggettoSalvato oggettoSalvato = new OggettoSalvato();

            oggettoSalvato.nomePrefab = PlayerPrefs.GetString("NomePrefab_" + i);

            oggettoSalvato.posizione = new Vector3(
                PlayerPrefs.GetFloat("PosizioneX_" + i),
                PlayerPrefs.GetFloat("PosizioneY_" + i),
                PlayerPrefs.GetFloat("PosizioneZ_" + i)
            );

            oggettoSalvato.rotazione = new Quaternion(
                PlayerPrefs.GetFloat("RotazioneX_" + i),
                PlayerPrefs.GetFloat("RotazioneY_" + i),
                PlayerPrefs.GetFloat("RotazioneZ_" + i),
                PlayerPrefs.GetFloat("RotazioneW_" + i)
            );

            oggettiSalvati.Add(oggettoSalvato);
        }

        return oggettiSalvati;
    }
}