using System.Collections.Generic;
using CodeBase.Interfaces;

namespace CodeBase.Services
{
    public class GameResetService
    {
        private readonly List<IResettable> _resetTables = new List<IResettable>();

        public void RegisterResettable(IResettable resettable) => 
            _resetTables.Add(resettable);

        public void ResetAll()
        {
            foreach (var resettable in _resetTables) 
                resettable.ResetPosition();
        }
    }
}