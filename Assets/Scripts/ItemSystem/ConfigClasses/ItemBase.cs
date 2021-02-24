using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Base", menuName = "Items/Base", order = 20)]
public class ItemBase : ScriptableObject
{
    public RectTransform GUIItemPrefab;
    public Texture2D Icon;
    public Item Visual;
    public string Name;
    public int check = 0;
    
    public void SpawnFromInventory(Transform _spawnPoint)
    {
        var obj = GameObject.Instantiate(Visual, _spawnPoint.position, new Quaternion());
        obj.config = this;
    }

    public virtual string ShowInfo()
    {
        return $"{Name},\n Uses: {check}\n";
    }

    public virtual RectTransform GenerateGUIBlock()
    {
        var block = GameObject.Instantiate(GUIItemPrefab);
        block.gameObject.GetComponent<ItemBlock>().Icon.texture = Icon;
        block.gameObject.GetComponent<ItemBlock>().Name.text = Name;
        return block;
    }
}
