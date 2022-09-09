using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainPanle : MonoBehaviour
{
    // Start is called before the first frame update


    public Text coin;
    public Button btnwea;

    public void UpdateInfo(WeaponModel data)
    {
        coin.text = data.Coin.ToString();    
    }


}
