using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    Animator anim;
    public Transform target;
    private NavMeshAgent agent;

    // Distancia a la cual el enemigo empieza a atacar
    public float attackRange = 2.0f;
    // Duraci�n de la animaci�n de ataque
    public float attackDuration = 1.0f;
    // Cooldown entre ataques
    public float attackCooldown = 1.5f;

    // Rango de seguimiento
    public float chaseRange = 10.0f;

    private float lastAttackTime;

    [SerializeField] private float damage = 10f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        lastAttackTime = -attackCooldown; // Permitir atacar inmediatamente al inicio
    }

    private void Update()
    {
        if (target != null)
        {
            // Comprobar si el objetivo est� dentro del rango de seguimiento
            if (IsTargetWithinChaseRange(target.position))
            {
                agent.SetDestination(target.position);
            }
            else
            {
                agent.ResetPath(); // Detener el movimiento si el objetivo est� fuera del rango
            }
            UpdateAnimations();
        }
    }

    bool IsTargetWithinChaseRange(Vector3 targetPosition)
    {
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
        return distanceToTarget <= chaseRange;
    }

    void UpdateAnimations()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget <= attackRange && Time.time >= lastAttackTime + attackCooldown)
        {
            // Si el enemigo est� en rango de ataque y el cooldown ha pasado, ataca
            anim.SetBool("IsAttacking", true);
            anim.SetFloat("Movimientos", 0);
            lastAttackTime = Time.time; // Registrar el tiempo del ataque
            StartCoroutine(AttackAnimation());
        }
        else
        {
            // Si el enemigo no est� en rango de ataque, actualizar la animaci�n de movimiento
            anim.SetBool("IsAttacking", false);
            float Movimientos = agent.velocity.magnitude;
            Movimientos = Mathf.Clamp01(Movimientos);
            anim.SetFloat("Movimientos", Movimientos, 0.1f, Time.deltaTime);
        }
    }

    IEnumerator AttackAnimation()
    {
        yield return new WaitForSeconds(attackDuration);
        anim.SetBool("IsAttacking", false);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Vidas playerVidas = other.gameObject.GetComponent<Vidas>();
            if (playerVidas != null)
            {
                playerVidas.TomarDaño(damage);
            }
        }
    }
}
