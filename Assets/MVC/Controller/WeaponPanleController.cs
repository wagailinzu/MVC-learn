using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPanleController : MonoBehaviour
{
    public WeaponPanle weaponPanle;

    private static WeaponPanleController controller = null;
    public static WeaponPanleController Controller {
        get {
            return controller;
        }
    }

    public static void ShowMe()
    {
        if (controller == null)
        {
            GameObject res = Resources.Load<GameObject>("Prefabs/StrengthBGPre");
            GameObject obj = Instantiate(res);
            obj.transform.SetParent(GameObject.Find("Canvas").transform, false);
            controller = obj.GetComponent<WeaponPanleController>();
        }
        controller.gameObject.SetActive(true);
    }
    public static void Hide()
    {
        if (controller != null)
        {
            controller.gameObject.SetActive(false);
        }
    }
    public void Start()
    {
        weaponPanle = this.GetComponent<WeaponPanle>();
        weaponPanle.UpdateInfo(WeaponModel.Data);
        weaponPanle.btnClose.onClick.AddListener(OnClose);
        WeaponModel.Data.AddEventListener(UpdateInfo);
        weaponPanle.btnstrength.onClick.AddListener(LevUp);

    }
    public void OnClose()
    {
        Hide();
    }
    public void LevUp()
    {
        WeaponModel.Data.LevUp();
    }
    private void UpdateInfo(WeaponModel data)
    {
        weaponPanle.UpdateInfo(data);
    }

    private void OnDestroy()
    {
        WeaponModel.Data.RemoveEventListener(UpdateInfo);
    }

}
