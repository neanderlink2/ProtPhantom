using Assets.Scripts.Player;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Util
{
    public static class MyCanvas
    {
        public static Text TxtInteracao => GameObject.Find("Canvas")
            .GetComponentsInChildren<Text>()
            .FirstOrDefault(x => x.name.Equals("TxtInteracao"));

        public static RectTransform CaixaMensagem => GameObject.Find("Canvas")
            .transform.Find("CaixaDeMensagem")
            .GetComponent<RectTransform>();

        public static void MostrarMensagem(string mensagem)
        {
            var caixa = CaixaMensagem;
            caixa.GetComponentInChildren<Text>()
                .text = mensagem;

            caixa.gameObject.SetActive(true);
        }

        public static void EsconderTexto()
        {
            CaixaMensagem.gameObject.SetActive(false);
        }
    }
}
