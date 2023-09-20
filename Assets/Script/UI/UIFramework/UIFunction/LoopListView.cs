using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopListView : MonoBehaviour
{

    private bool firstItem = true;

    [SerializeField] private DisplayItem ItemPrefab;

    [SerializeField] private float ItemPadding_horizontal;
    [SerializeField] private float ItemPadding_vertical;

    [SerializeField] private bool topDownMode = false;
    [SerializeField] private bool leftRightMode = false;
    [SerializeField] private bool leftRight_topDownMode = false;

    private int currentElementsInLine = 0;
    [SerializeField] private int numElementInLine;

    private Vector3 lastItemPos;


    // Start is called before the first frame update
    void Start()
    {
        lastItemPos = ItemPrefab.GetComponent<RectTransform>().position;
    }

    public void turnToOrginal()
    {
        firstItem = true;
        lastItemPos = ItemPrefab.GetComponent<RectTransform>().position;
    }


    public DisplayItem addNewItem()
    {
        if (firstItem)
        {
            firstItem = false;
            return passItem();
        }
        else
        {
            if (topDownMode)
                return creatItem_TopDown();
            else if (leftRightMode)
                return creatItem_LeftRight();
            else if (leftRight_topDownMode)
                return creatItem_LeftRight_TopDown();
        }
            return null;

    }

    private DisplayItem creatItem_TopDown()
    {
        return createItemWithPosition(new Vector3(lastItemPos.x, lastItemPos.y + ItemPadding_vertical, 0));
    }

    private DisplayItem creatItem_LeftRight()
    {
        return createItemWithPosition(new Vector3(lastItemPos.x + ItemPadding_horizontal, lastItemPos.y, 0));
    }

    private DisplayItem creatItem_LeftRight_TopDown()
    {
        float xPosition = ItemPrefab.GetComponent<Transform>().position.x;
        Vector3 elementPositon;
        if (currentElementsInLine == numElementInLine)
        {
            elementPositon = new Vector3(xPosition, lastItemPos.y + ItemPadding_vertical, 0);
            currentElementsInLine = 1;
        }
        else
        {
            elementPositon = new Vector3(lastItemPos.x + ItemPadding_horizontal, lastItemPos.y, 0);
            currentElementsInLine++;
        }


        return createItemWithPosition(elementPositon);
    }

    private DisplayItem createItemWithPosition(Vector3 elementPostion)
    {
        DisplayItem Item = Instantiate(ItemPrefab, ItemPrefab.transform.parent, false);
        Item.GetComponent<RectTransform>().position = elementPostion;

        lastItemPos = elementPostion;

        return Item;
    }


    private DisplayItem passItem()
    {
        return ItemPrefab;
    }
}
