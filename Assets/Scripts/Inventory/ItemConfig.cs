
using UnityEngine;

[CreateAssetMenu(fileName ="Item",menuName ="ItemMenu/item",order =0)]
public class ItemConfig : ScriptableObject
{
    public int id;
    public string title;
    public Sprite image;
}
