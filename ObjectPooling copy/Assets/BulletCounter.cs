using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bulletCounterTextHolder;
    //Here we add a drag and drop box for the Game ui text obj to be written on

    void Start() 
    {
        BulletEvents.bulletFired.AddListener(WriteOver);
    }

    public void WriteOver(int NumberofShoots) 
    {
        bulletCounterTextHolder.text = "Bullets Fired: " + NumberofShoots;
    }

}
