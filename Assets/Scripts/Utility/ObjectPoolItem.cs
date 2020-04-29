using UnityEngine;

[System.Serializable]
public class ObjectPoolItem
{

	public GameObject objectToPool;
	public int amountToPool = 2;
	public bool shouldExpand = true;

}
