using System.Collections;
using System.Collections.Generic;

public sealed class PlayerInventoryManager
{
    private static PlayerInventoryManager sharedInstance;
    public List<Item> playerItems = new List<Item>();

    public static PlayerInventoryManager Singleton {
        get{
            if (sharedInstance == null) {
                sharedInstance = new PlayerInventoryManager();
            }
            return sharedInstance;
        }
    }

    public void Add(Item item){
        playerItems.Add(item);
        UIController.sharedInstance.UpdateInventoryUI();
    }

    public void Remove(Item item){
        playerItems.Remove(item);
        UIController.sharedInstance.UpdateInventoryUI();
    }

    public bool HasItem(Item itemToCheck){
        return playerItems.Contains(itemToCheck);
    }
}
