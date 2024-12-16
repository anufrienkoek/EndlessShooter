using UnityEngine;

namespace _Project.CodeBase.Interfaces
{
    public interface IMovable
    {
       abstract void Move(Vector3 to);
        abstract void Rotate(Vector3 to);
    }
}