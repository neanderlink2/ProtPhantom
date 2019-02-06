using Assets.Scripts.Itens.Entities;
using Assets.Scripts.Itens.EntityScriptable;
using Assets.Scripts.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Itens.Behaviours
{
    public class ItemBehaviour : MonoBehaviour
    {
        public ItemScriptable item;
        private InventarioScriptable inventario;

        private bool m_podeColetar = false;

        public void Start()
        {
            inventario = GameObject
                .Find("Util")
                .GetComponent<InventarioController>()
                .inventario;
        }

        public void Update()
        {
            MyCanvas.TxtInteracao.text = m_podeColetar ? "Pressione F para interagir" : "";
            if (m_podeColetar && Input.GetButtonDown("Interacao"))
            {
                ColetarItem();
            }
        }

        public void ColetarItem()
        {
            inventario.items.Add(item.item);
            MyCanvas.TxtInteracao.text = "";
            gameObject.SetActive(false);
        }

        public void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                m_podeColetar = true;                
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                m_podeColetar = false;
            }
        }
    }
}
