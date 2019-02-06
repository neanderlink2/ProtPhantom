using Assets.Scripts.Util;
using System;
using Unity.Collections.LowLevel.Unsafe;

namespace Assets.Scripts.Itens.Entities
{
    [NativeContainer]
    [Serializable]
    public struct Item
    {
        public int id;

        public string nomeItem;
        public string descricao;
        public string caminhoImagem;
        
        public async void Salvar ()
        {
            await FileManager.SalvarJson(this, "item.asset");
        }
    }
}
