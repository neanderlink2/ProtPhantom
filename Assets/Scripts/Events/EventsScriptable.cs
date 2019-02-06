using Assets.Scripts.Itens.Behaviours;
using Assets.Scripts.Itens.Entities;
using Assets.Scripts.Itens.EntityScriptable;
using Assets.Scripts.Player;
using Assets.Scripts.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Events
{
    [CreateAssetMenu(menuName = "Objetos.../Ações")]
    public class EventsScriptable : ScriptableObject
    {
        public void LimparInventario ()
        {
            PlayerController.Inventario.inventario.items = new List<Item>();
        }

        public void CarregarInventário ()
        {
            PlayerController.Inventario.inventario.Carregar();
        }

        public void SalvarInventario ()
        {
            PlayerController.Inventario.inventario.Salvar();
        }
    }
}
