using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBehaviour : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce = 10f;
    public float movementSpeed = 5f;
    public int CuentaDeMonedas = 0;
    public TextMeshProUGUI coinsText;
    public AudioClip coinSFX;
    public AudioClip especialcoinSFX;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        Vector3 movement = new Vector3();
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        rb.AddForce(movement * movementSpeed * Time.deltaTime, ForceMode.Impulse);

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Moneda"))
        {
            Debug.Log("He chocado con una moneda");
            CuentaDeMonedas = CuentaDeMonedas + 1;
            Debug.Log("Tienes " + CuentaDeMonedas + " monedas ");
            AudioSource.PlayClipAtPoint(coinSFX, transform.position);
        }
        else if(other.CompareTag("MonedaEspecial"))
        {
            Debug.Log("He tocado una moneda especial");
            CuentaDeMonedas += 5;
            Debug.Log("Tienes " + CuentaDeMonedas + " monedas ");
            AudioSource.PlayClipAtPoint(especialcoinSFX, transform.position);
        }

        if (other.tag.Contains("Moneda"))
        {
            coinsText.text = CuentaDeMonedas.ToString();
            other.gameObject.SetActive(false);
            
        }
    }
    
}
