using CodeBase.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Controllers
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class BotMove : MonoBehaviour, IMovable, IResettable
    {
        [SerializeField] private Transform player;
        [SerializeField] private NavMeshAgent agent;
        private Vector3 _startPosition;

        private void Start() => 
            _startPosition = transform.position;

        private void Update()
        {
            Move(player.position);
            Rotate(player.position);
        }
        
        public void Move(Vector3 to)
        {
            var distanceToPlayer = Vector3.Distance(agent.transform.position, player.position);
            
            agent.isStopped = distanceToPlayer <= 3f && IsPlayerInSight();
            agent.SetDestination(player.position);
        }

        public void Rotate(Vector3 to)
        {
            var lookRotation = Quaternion.LookRotation((player.position - agent.transform.position).normalized);
            agent.transform.rotation = Quaternion.Lerp(transform.rotation,lookRotation,Time.deltaTime);

        }
        
        public void ResetPosition() => 
            transform.position = _startPosition;
        
        public bool IsPlayerInSight()
        {
            var directionToPlayer = (player.position - agent.transform.position).normalized;
            
            if (Physics.Raycast(agent.transform.position, directionToPlayer, out RaycastHit hit, 10f))
                return hit.transform == player;
            
            return false;
        }
    }
}
