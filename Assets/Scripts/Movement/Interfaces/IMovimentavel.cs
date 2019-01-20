using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovimentavel
{
    float Velocidade { get; set; }
    float ForcaPulo { get; set; }
    void Mover(Vector3 direcao);
    void Pular();
}
