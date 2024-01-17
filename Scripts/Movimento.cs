using UnityEngine;

public class Movimento : MonoBehaviour
{
    public float velocitaMovimento = 5.0f;
    public float velocitaRotazione = 2.0f;

    private float mouseX = 0.0f;
    private float mouseY = 0.0f;

    void Update()
    {
        // Movimento della telecamera
        float movimentoOrizzontale = Input.GetAxis("Horizontal");
        float movimentoVerticale = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(movimentoOrizzontale, 0, movimentoVerticale) * velocitaMovimento * Time.deltaTime;
        transform.Translate(movimento);

        // Rotazione della telecamera con il mouse
        mouseX += Input.GetAxis("Mouse X") * velocitaRotazione;
        mouseY -= Input.GetAxis("Mouse Y") * velocitaRotazione;
       // mouseY = Mathf.Clamp(mouseY, -90, 0); // Impedisce la rotazione sotto l'orizzonte

        transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
    }
}