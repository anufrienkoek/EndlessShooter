using UnityEngine;
using System.Collections.Generic;
using _Project.CodeBase.Interfaces;

namespace _Project.CodeBase.Services
{
    public class GameResetService : MonoBehaviour
    {
        private List<IResettable> _resettables;

        private void Awake() => 
            _resettables = new List<IResettable>();

        public void Initialize(IResettable resettable) => 
            _resettables.Add(resettable);
        
        public void Reset()
        {
            foreach (var resettable in _resettables)
                resettable.Reset();
        }
    }
}
