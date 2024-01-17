using UnityEngine;

public class InterazioneOggetto : MonoBehaviour
{
    private GameObject oggettoSelezionato;
    private Camera telecamera;
    private bool muoviOggetto = false;
    private bool ruotaOggetto = false;
    private float velocitaMovimento = 50.0f;
    private float distanzaOggettoDalCursore = 1.0f;
    public float minDistanza = 1.0f;

    void Start()
    {
        if (PlayerPrefs.GetInt("SceltaUtente") == 1)
        {
            enabled = false;
        }
        telecamera = Camera.main;
    }

    void Update()
    {
        bool tastoSinistroPremuto = Input.GetMouseButtonDown(0);
        bool tastoDestroPremuto = Input.GetMouseButtonDown(1);

        if (tastoSinistroPremuto && !tastoDestroPremuto)
        {
            muoviOggetto = true;
            ruotaOggetto = false;
            HandleObjectSelection();
        }
        else if (tastoDestroPremuto && !tastoSinistroPremuto)
        {
            muoviOggetto = false;
            ruotaOggetto = true;
            HandleObjectSelection();
        }

        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            RilasciaOggetto();
        }

        if (muoviOggetto && oggettoSelezionato != null)
        {
            if (Input.GetKey(KeyCode.C))
            {
                Destroy(oggettoSelezionato);
            }
            float rotazioneRuota = Input.GetAxis("Mouse ScrollWheel");
            distanzaOggettoDalCursore += rotazioneRuota * 5.0f;

            distanzaOggettoDalCursore = Mathf.Max(distanzaOggettoDalCursore, minDistanza);

            Vector3 posizioneMouseNelMondo = telecamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanzaOggettoDalCursore));
            oggettoSelezionato.transform.position = Vector3.Lerp(oggettoSelezionato.transform.position, posizioneMouseNelMondo, Time.deltaTime * velocitaMovimento);
        }

        if (ruotaOggetto && oggettoSelezionato != null)
        {
            float rotazioneX = Input.GetAxis("Mouse X");
            float rotazioneY = Input.GetAxis("Mouse Y");
            oggettoSelezionato.transform.Rotate(Vector3.up, rotazioneX * 10.0f);
            oggettoSelezionato.transform.Rotate(Vector3.left, rotazioneY * 10.0f);
        }
    }

    private void HandleObjectSelection()
    {
        if (Physics.Raycast(telecamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Reperto"))
            {
                oggettoSelezionato = hit.collider.gameObject;

                Rigidbody rb = oggettoSelezionato.GetComponent<Rigidbody>();
                if (rb != null)
                {

                    if (!oggettoSelezionato.GetComponent<NomePrefabAssociato>().Kinematic)
                    {
                        rb.useGravity = false;
                        rb.isKinematic = true;
                    }

                }

                distanzaOggettoDalCursore = Vector3.Distance(oggettoSelezionato.transform.position, hit.point);
            }
        }
    }

    private void RilasciaOggetto()
    {
        if (oggettoSelezionato != null)
        {
            Rigidbody rb = oggettoSelezionato.GetComponent<Rigidbody>();
            if (rb != null && !oggettoSelezionato.GetComponent<NomePrefabAssociato>().Kinematic)
            {
                rb.useGravity = true;
                rb.isKinematic = false;
            }
            oggettoSelezionato = null; // Resetta l'oggetto selezionato quando rilasci il tasto
        }
    }
}