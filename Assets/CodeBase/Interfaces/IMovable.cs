using UnityEngine;

namespace CodeBase.Interfaces
{
    public interface IMovable
    {
        void Move(Vector3 to);
        void Rotate(Vector3 to);
    }
}