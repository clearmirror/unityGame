using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleInputManager : MonoBehaviour {

    // public Button yourButton;

    // Use this for initialization
    private GameObject player;
    private GameObject enemy;
    
    void Start () {
        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy");
    }

    public void TaskOnClick()
    {
        PlayerControl script = player.GetComponent<PlayerControl>();
        script.MoveTo(enemy.transform.position);
    }
}
