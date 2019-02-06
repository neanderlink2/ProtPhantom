using Assets.Scripts.Util;
using System;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Assets.Scripts.Itens.Entities
{
    [NativeContainer]
    [Serializable]
    public struct Item
    {
        public int id;

        public string nomeItem;
        public string descricao;

        public Sprite sprite;

        public async void Salvar ()
        {
            await FileManager.SalvarJson(this, "item.asset");
        }
    }
}
