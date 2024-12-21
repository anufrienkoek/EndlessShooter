using _Project.CodeBase.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace _Project.CodeBase.Controllers.AI
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class BotMovementController : MovementController
    {
        [SerializeField] private Transform player;

        private NavMeshAgent _agent;

        protected override void Awake()
        {
            base.Awake();
            
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            Move(player.position);
            Rotate(player.position);
        }

        public override void Move(Vector3 to)
        {
            var distanceToPlayer = Vector3.Distance(_agent.transform.position, player.position);
            _agent.isStopped = distanceToPlayer <= 3f && IsPlayerInSight();
            _agent.SetDestination(to);
        }

        public void Rotate(Vector3 to)
        {
            var lookRotation = Quaternion.LookRotation((player.position - _agent.transform.position).normalized);
            _agent.transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime);
        }

        private bool IsPlayerInSight()
        {
            var directionToPlayer = (player.position - _agent.transform.position).normalized;

            if (Physics.Raycast(_agent.transform.position, directionToPlayer, out RaycastHit hit, 10f))
                return hit.transform == player;

            return false;
        }
    }
}