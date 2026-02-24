using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemBase> StartingItems = new List<ItemBase>();
    public List<ItemBase> Items = new List<ItemBase>();

    public int Money = 100;

    void Awake()
    {
        Items.AddRange(StartingItems);
        Debug.Log("Inventario iniciado con " + Items.Count + " items");
    }

    public bool AddItem(ItemBase Item)
    {
        Items.Add(Item);
        Debug.Log("Item añadido: " + Item.Name);
        return true;
    }

    public void RemoveItem(ItemBase Item)
    {
        Items.Remove(Item);
        Debug.Log("Item eliminado: " + Item.Name);
    }

    public bool HasMoney(int Amount)
    {
        return Money >= Amount;
    }

    public void AddMoney(int Amount)
    {
        Money += Amount;
        Debug.Log("Dinero actual: " + Money);
    }

    public void RemoveMoney(int Amount)
    {
        Money -= Amount;
        Debug.Log("Dinero actual: " + Money);
    }
}