using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEngine.Experimental.Rendering.LWRP;
//using CodeMokey.Utils;

public class ItemWorld : MonoBehaviour
{
    private Item item;
    private SpriteRenderer spriteRenderer;
    private TextMeshPro textMeshPro;
    private PlayerController playerController;

    //public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    //{
    //    Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);

    //    ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
    //    itemWorld.SetItem(item);

    //    return itemWorld;
    //}

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
    }

    public void SetPlayer(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    //public static ItemWorld DropItem(Vector3 dropPosition, Item item)
    //{
    //    Vector3 randomDir = UtilsClass.GetRandomDir();  //USA LIBRERIAS PROPIAS QUE HAY QUE DESCARGAR
    //    ItemWorld itemWorld = SpawnItemWorld(dropPosition + randomDir * 5f, item);
    //    itemWorld.GetComponent<Rigidbody2D>().AddForce(randomDir * 5f, ForceMode2D.Impulse);
    //    return itemWorld;
    //}

    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
        if (item.amount > 1)
        {
            textMeshPro.SetText(item.amount.ToString());
        }
        else
        {
            textMeshPro.SetText("");
        }
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
