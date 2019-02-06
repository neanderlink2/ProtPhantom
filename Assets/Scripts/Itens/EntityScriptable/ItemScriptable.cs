using Assets.Scripts.Itens.Entities;
using UnityEngine;

namespace Assets.Scripts.Itens.EntityScriptable
{
    [CreateAssetMenu(fileName = "Item", menuName = "Objetos.../Item")]
    public class ItemScriptable : ScriptableObject
    {
        public Item item;
    }
}