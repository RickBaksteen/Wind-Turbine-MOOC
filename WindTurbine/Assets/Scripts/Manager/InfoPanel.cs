using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoPanel : MonoBehaviour {

    public Text infoText;
    public InfoItem item = null;

    public void UpdateInfo(InfoItem item)
    {
        this.item = item;
        infoText.text = item.GetInfo();
    }
}
