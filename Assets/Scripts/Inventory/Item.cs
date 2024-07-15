using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private string _name;
    [SerializeField] private int _maxStack;
    [SerializeField] private Sprite _sprite;
    public int ID { get => id;}
    public string Name { get => _name;}
    public int MaxStack { get => _maxStack;}
    public Sprite Sprite { get => _sprite;}
    public virtual bool CanEquip()
    {
        return false;
    }
}
