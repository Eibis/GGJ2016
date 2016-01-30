using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    RenderTexture[] rt;
    GameObject prefab;

    void Start()
    {
        prefab = Resources.Load<GameObject>("InventoryItem");
    }

    void OnEnable()
    {
        if(rt != null)
        { 
            for (int i = 0; i < rt.Length; i++)
                rt[i].Release();
        }

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        rt = new RenderTexture[GameManager.Istance.object_picked.Count];

        for (int i = 0;  i < GameManager.Istance.object_picked.Count; i++)
        {
            rt[i] = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
            rt[i].Create();

            GameObject temp = Instantiate(prefab);
            temp.transform.parent = transform;
            temp.GetComponent<RawImage>().texture = rt[i];
        }

        LayoutRebuilder.MarkLayoutForRebuild((RectTransform)transform);
    }
}
