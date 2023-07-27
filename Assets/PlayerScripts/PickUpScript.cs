using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickUpScript : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public GameObject winText;
    public int coinsCount = 0;
    public Rigidbody rigidbody;

    void Start()
    {
        winText.SetActive(false);
        coinsText.text = "Coins: 0";
    }

    void Update()
    {
        if (coinsCount >= 10)
        {
            winText.SetActive(true);
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CoinObject")
        {
            Destroy(collision.gameObject);
            coinsCount++;
            coinsText.text = "Coins: " + coinsCount;
        }

        if (collision.gameObject.tag != "CoinObject")
        {
            Debug.Log("NotCoinObject");
        }
    }
}
