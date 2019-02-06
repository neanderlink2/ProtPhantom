using Assets.Scripts.Itens.Entities;
using Assets.Scripts.Util;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Itens.EntityScriptable
{
    [CreateAssetMenu(fileName = "Item", menuName = "Objetos.../Inventário")]
    public class InventarioScriptable : ScriptableObject
    {
        public List<Item> items;

        //public int QuantidadeTotalDeItens => items.Count;

        public async void Salvar()
        {
            await FileManager.SalvarJson(this, "inventario.asset");
        }

        public async void Carregar()
        {
            await FileManager.LerJsonScriptable("inventario.asset", this);
        }
    }
}
