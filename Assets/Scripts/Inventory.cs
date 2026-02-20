using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemBase> startingItems = new List<ItemBase>();
    public List<ItemBase> items = new List<ItemBase>();

    public int Money = 100;

    void Awake()
    {
        items.AddRange(startingItems);
        Debug.Log("Inventario iniciado con " + items.Count + " items");
    }

    public bool AddItem(ItemBase item)
    {
        items.Add(item);
        Debug.Log("Item añadido: " + item.Name);
        return true;
    }

    public void RemoveItem(ItemBase item)
    {
        items.Remove(item);
        Debug.Log("Item eliminado: " + item.Name);
    }

    public bool HasMoney(int amount)
    {
        return Money >= amount;
    }

    public void AddMoney(int amount)
    {
        Money += amount;
        Debug.Log("Dinero actual: " + Money);
    }

    public void RemoveMoney(int amount)
    {
        Money -= amount;
        Debug.Log("Dinero actual: " + Money);
    }
}