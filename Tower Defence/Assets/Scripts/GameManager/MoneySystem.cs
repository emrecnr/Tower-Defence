using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySystem : MonoBehaviour
{
    // Start is called before the first frame update
    public static int money;

    private int startMoney = 225;


    private void Start()
    {
        money = startMoney;
    }
}
