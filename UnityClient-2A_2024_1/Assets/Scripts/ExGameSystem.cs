using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    private int idex;       //�� �� �ҹ���
    private string name;
    private ItemType type;
    private Sprite image;
    //������� private �� ���� �Ұ�

    public int Index        //������Ƽ ���� ( ���� �̸� �� �� �빮�� )
    {
        get { return Index; }
        set { Index = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public ItemType Type        //������Ƽ ���� Ŭ������ ����
    {
        get { return type; }
        set { type = value; }
    }

    public Sprite Image     //������Ƽ ���� ����Ƽ Ŭ������ ����
    {
        get { return Image; }
        set { Image = value; }
    }
    
    public Item(int idex, string name, ItemType type)       //�������� �����ϴ� ������ �Լ�
    {
        this.idex = idex;                                   //�� �������� �Լ��� �޾Ƽ� ����
        this.name = name;
        this.type = type;
    }
}

public class Inventory
{
    private Item[] items = new Item[16];

    //������ �ε���(Indexer)
    public Item this[int index]
    {
        get { return items[index]; }
        set { items[index] = value; }
    }

    //���� �κ��丮�� �ִ� ������ ��
    public int ItemCount
    {
        get
        {
            int count = 0;      //������ �� �˻縦 ���� ����
            foreach(Item item in items)
            {
                if(item != null) count++;       //�������� null�� �ƴϸ� +1
            }
            return count;
        }
    }

    //������ �߰�
    public bool AddItem(Item item)
    {
        for(int i = 0; i < items.Length; i++)       //����ĭ�� �˻� (for ������ �տ��� ���� �˻�)
        {
            if (items[i] == null)
            {
                items[i] = item;
                return true;
            }
        }
        return false;   //�κ��丮�� ���� á�� ���
    }

    //������ ����
    public void RemoveItem(Item item)
    {
        for (int i = 0; i < items.Length; i++)       //����ĭ�� �˻� (for ������ �տ��� ���� �˻�)
        {
            if (items[i] == item)                   //������ �������� �˻��ϰ�
            {
                items[i] = null;                    //null ���� �ִ´�.
                break;
            }
        }
    }
}

public enum ItemType        //������ ���� ����
{
    Weapon,
    Armor,
    Potion,
    Questitem       //�ٸ� ������ Ÿ�Ե��� �߰� �� �� �ִ�
}
public class ExGameSystem : MonoBehaviour
{

    private Inventory inventory = new Inventory();      //�κ��丮 Ŭ���� ����

    void Start()
    {
        Item sword = new Item(0, "Sword", ItemType.Weapon);     //������ ���� Į ����
        Item shield = new Item(0, "Shield", ItemType.Armor);     //������ ���� ���� ����

        inventory.AddItem(sword);                               //������ �������� ���濡 �ִ´�
        inventory.AddItem(shield);
        
        Debug.Log("Player Inventory : " + GetInvectoryAsString());
    }

    private string GetInvectoryAsString()
    {
        string result = "";
        for (int i = 0; i < inventory.ItemCount; i++)       //�κ��丮�ȿ� Item �� ������ �ش� �̸� ���
        {
            if (inventory[i] != null)
            {
                result += inventory[i].Name + ",";
            }
        }
        return result.TrimEnd(',');     //������ �޸� ����
    }
}
