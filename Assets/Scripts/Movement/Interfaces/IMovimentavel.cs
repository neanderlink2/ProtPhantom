using UnityEngine;
namespace Assets.Scripts.Movement.Interfaces
{
    public interface IMovimentavel
    {
        float Velocidade { get; set; }
        float ForcaPulo { get; set; }
        void Mover(Vector3 direcao);
        void Pular();
    }

}