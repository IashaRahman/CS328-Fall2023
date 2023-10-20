public class MeleeEnemy : BaseEnemy
{
    public float attackRange = 1.5f;

    protected override void Start()
    {
        base.Start();
    }

    public override void Attack()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= attackRange)
        {
            
            Debug.Log("Melee attack!");
        }
    }
}
