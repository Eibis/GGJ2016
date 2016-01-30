using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    GameObject prefab;

    void Awake()
    {
        prefab = Resources.Load<GameObject>("InventoryItem");
    }

    void OnEnable()
    {

        if (GameManager.Istance == null || prefab == null)
            return;

        foreach (Transform child in transform.GetChild(0))
        {
            Destroy(child.gameObject);
        }

        for (int i = 0;  i < GameManager.Istance.object_picked.Count; i++)
        {
            if (GameManager.Istance.object_picked[i].icon == null)
                continue;

            GameObject temp = Instantiate(prefab);
            temp.transform.SetParent(transform.GetChild(0));
            temp.GetComponent<Image>().overrideSprite = GameManager.Istance.object_picked[i].icon;
        }

        LayoutRebuilder.MarkLayoutForRebuild((RectTransform)transform.GetChild(0));
    }
}
