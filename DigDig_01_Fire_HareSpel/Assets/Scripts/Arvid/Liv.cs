using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Liv : MonoBehaviour
{
    Text lives;
    int Liv_amount=5;
    // Start is called before the first frame update
    void Start()
    {
        lives = GameObject.FindGameObjectWithTag("Finish").GetComponent<Text>();
    }

    public void loselives(int live)
    {
        Liv_amount = Liv_amount + live;
    }

    // Update is called once per frame
    void Update()
    {
        lives.text = "" + NewMovement.liv;
    }
}
