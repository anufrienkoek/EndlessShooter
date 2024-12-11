using System.Linq;
using CodeBase.Interfaces;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase
{
    public class GameManager : MonoBehaviour
    {
        private GameResetService resetService;
        public CollisionService Service { get; set; }

        private void Awake()
        {
            resetService = new GameResetService();
            Service = new CollisionService();
        }

        private void Start()
        {
            foreach (var resettable in FindObjectsOfType<MonoBehaviour>().OfType<IResettable>()) 
                resetService.RegisterResettable(resettable);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.R)) 
                ResetAll();
        }

        public void ResetAll() => 
            resetService.ResetAll();

        private void OnTriggerEnter(Collider other) => 
            Debug.Log(other.gameObject.name);

        private void OnTriggerExit(Collider other) 
        {
            if(other.GetComponent<Bullet>()) 
                Destroy(other);
        }
    }
}
