using System.Collections.Generic;

public class GenericObjectPooler<T> : NonMonoSingleton<GenericObjectPooler<T>> where T : class
{  
    private List<PooledItem<T>> pooledItems = new List<PooledItem<T>>();
    public virtual T GetItem()
    {
        if (pooledItems.Count < 0) return null;
        PooledItem<T> pooledItem = pooledItems.Find(i => i.isUsed == false);
        if (pooledItem != null)
        {
            pooledItem.isUsed = true;
            return pooledItem.item;
        }
        PooledItem<T> newPooledItem = new PooledItem<T>();
        newPooledItem.item = CreateItem();
        newPooledItem.isUsed = true;
        pooledItems.Add(newPooledItem);
        return newPooledItem.item;
    }

    public virtual void ReturnItem(T item)
    {
        PooledItem<T> pooledItem = pooledItems.Find(i => i.item == item);
        if (pooledItem != null)
        {
            pooledItem.isUsed = false;
        }
    }

    public virtual T CreateItem()
    {
        return (T)null;
    }
} 

public class PooledItem<T> where T : class
{
    public T item;
    public bool isUsed;
}