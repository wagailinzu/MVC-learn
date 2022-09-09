using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponPanle : MonoBehaviour
{
    // Start is called before the first frame update

    public Button btnstrength;
    public Button btnClose;
    public Text lev;
    public Text atc;
    public Text hp;
    public Text rhp;
    public Text def;
    public Text rmp;
    public Text mp;

    public void UpdateInfo(WeaponModel data)
    {
        lev.text="LVE:"+ data.Lev;
        atc.text = "攻击力:" + data.Atc;
        hp.text = "血量:" + data.Hp;
        rhp.text = "回血:" + data.Rhp;
        def.text = "防御力:" + data.Def;
        rmp.text = "回蓝:" + data.Rmp;
        mp.text = "蓝量:" + data.Mp;
    }
     
}
