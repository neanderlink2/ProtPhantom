using Assets.Scripts.Itens.Entities;
using Assets.Scripts.Itens.EntityScriptable;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Itens.Behaviours
{
    public class InventarioController : MonoBehaviour
    {
        public InventarioScriptable inventario;

        private void Awake()
        {
            inventario = Instantiate(inventario);
        }

        public void AdicionarItem(Item item)
        {
            inventario.items.Add(item);
        }

        public bool VerificarItemNoInventario(string nomeItem)
        {
            return inventario.items.Any(x => x.nomeItem.Equals(nomeItem));
        }
    }
}
