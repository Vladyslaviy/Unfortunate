using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickUpScript : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    public int coinsCount = 0;
    public Rigidbody rigidbody;

    void Start()
    {
        coinsText.text = "Coins: 0";
    }

    void Update()
    {
        //if (rigidbody.IsSleeping())
        //{
        //    rigidbody.WakeUp();
        //}
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
