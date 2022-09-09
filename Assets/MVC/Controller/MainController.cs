using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    private MainPanle mainPanle;

    private static MainController controller = null;

    public static MainController Controller
    {
        get { return controller; }
    }

    public static void Showme()
    {
        if (controller == null)
        {
            GameObject res = Resources.Load<GameObject>("Prefabs/Main");
            GameObject obj = Instantiate(res);

            obj.transform.SetParent(GameObject.Find("Canvas").transform,false);
            controller = obj.GetComponent<MainController>();
        }
        controller.gameObject.SetActive(true);
    }

    public static void Hideme()
    {
        controller.gameObject.SetActive(false);
    }

    public void Start()
    {
        mainPanle = this.GetComponent<MainPanle>();

        mainPanle.UpdateInfo(WeaponModel.Data);
        mainPanle.btnwea.onClick.AddListener(OnClickBtnwea);
        WeaponModel.Data.AddEventListener(UpdateInfo);
    }

    private void UpdateInfo(WeaponModel data)
    {
        mainPanle.UpdateInfo(data);
    }

    public void OnClickBtnwea()
    {
        WeaponPanleController.ShowMe();
    }
    private void OnDestroy()
    {
        WeaponModel.Data.RemoveEventListener(UpdateInfo);
    }

}
