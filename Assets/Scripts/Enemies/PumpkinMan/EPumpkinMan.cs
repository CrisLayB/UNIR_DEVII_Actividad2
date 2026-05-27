using UnityEngine;

public class EPumpkinMan : IDamageable, IAttack
{
    [SerializeField, Range(1, 100)] private int health = 50;
    private int _health;

    private void Awake()
    {
        _health = health;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AttackDefault()
    {
        throw new System.NotImplementedException();
    }

    public void Damage()
    {
        throw new System.NotImplementedException();
    }
}
