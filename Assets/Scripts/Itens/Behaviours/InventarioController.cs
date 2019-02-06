using Assets.Scripts.Itens.Entities;
using Assets.Scripts.Itens.EntityScriptable;
using Assets.Scripts.Util;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Itens.Behaviours
{
    public class InventarioController : MonoBehaviour
    {
        public InventarioScriptable inventario;
        public GameObject ui_painelItem;

        public bool isMostrandoInventario;

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

        public int VerificarQtdeItemNoInventario(string nomeItem)
        {
            return inventario.items.Where(x => x.nomeItem.Equals(nomeItem)).Count();
        }

        public void PopularInventario()
        {
            foreach (var item in inventario.items)
            {
                ui_painelItem.GetComponentsInChildren<Text>().FirstOrDefault(x => x.name.Equals("TxtDescricao")).text = item.descricao;
                ui_painelItem.GetComponentsInChildren<Text>().FirstOrDefault(x => x.name.Equals("TxtNome")).text = item.nomeItem;
                ui_painelItem.GetComponentsInChildren<Image>().FirstOrDefault(x => x.name.Equals("ImgIcone")).sprite = item.sprite;

                Instantiate(ui_painelItem, MyCanvas.PainelItens);
            }
        }
    }
}