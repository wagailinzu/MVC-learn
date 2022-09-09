using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponModel 
{
    private int coin;
    public int Coin
    {
        get { return coin; }
    }

    private int lev;
    public int Lev { get { return lev; } }

    private int atc;
    public int Atc { get{ return atc; } }

    private int hp;
    public int Hp { get { return hp; } }

    private int def;
    public int Def { get { return def; } }

    private int rhp;
    public int Rhp { get { return rhp; } }

    private int rmp;
    public int Rmp { get { return rmp; } }

    private int mp;
    public int Mp { get { return mp; } }

    private static WeaponModel data=null;

    public static WeaponModel Data
    {
        get 
        {
            if (data == null)
            {
                data = new WeaponModel();
                data.Init();
            }
            return data;
        }
    }

    private event UnityAction<WeaponModel> updateEvent;
    public void Init()
    {
        coin = PlayerPrefs.GetInt("PlayerCoin",999);
        lev = PlayerPrefs.GetInt("PlayerLev",1);
        atc = PlayerPrefs.GetInt("PlayerAtc", 10);
        hp = PlayerPrefs.GetInt("PlayerHp", 100);
        def = PlayerPrefs.GetInt("PlayerDef", 20);
        rhp = PlayerPrefs.GetInt("PlayerRhp", 1);
        rmp = PlayerPrefs.GetInt("PlayerRmp", 2);
        mp = PlayerPrefs.GetInt("PlayerLev", 50);
    }

    public void LevUp()
    {
        lev += 1;
        coin -= lev;
        atc += lev;
        hp += lev;
        def += lev;
        rhp += lev;
        rmp += lev;
        mp += lev;
        SaveDate();
    }

    public void SaveDate()
    {
        PlayerPrefs.GetInt("PlayerCoin", coin);
        PlayerPrefs.GetInt("PlayerLev", lev);
        PlayerPrefs.GetInt("PlayerAtc", atc);
        PlayerPrefs.GetInt("PlayerHp", hp);
        PlayerPrefs.GetInt("PlayerDef", def);
        PlayerPrefs.GetInt("PlayerRhp", rhp);
        PlayerPrefs.GetInt("PlayerRmp", rmp);
        PlayerPrefs.GetInt("PlayerLev", lev);

        UpdateInfo();
    }

    public void AddEventListener(UnityAction<WeaponModel> function)
    {
        updateEvent += function;
    }

    public void RemoveEventListener(UnityAction<WeaponModel> function)
    {
        updateEvent -= function;
    }

    public void UpdateInfo()
    {
        updateEvent?.Invoke(this);
    }
}
