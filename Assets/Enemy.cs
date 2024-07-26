using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int rutina;
    public float tiempo;
    public Animator ani;
    public Quaternion angulo;
    public float rango;

    void Start()
    {
        ani = GetComponent<Animator>();
    }
    public void Comportamiento()
    {
        tiempo += 1 * Time.deltaTime;
        if (tiempo >= 4)
        {
            rutina = Random.Range(0, 2);
            tiempo = 0;
        }
        switch (rutina)
        {
            case 0:
                ani.SetBool("Walk", false);
                break;

            case 1:
                rango = Random.Range(0, 360);
                angulo = Quaternion.Euler(0, rango, 0);
                rutina++;
                break;
            case 2:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                ani.SetBool("Walk", true);
                break;
        }
    }
    void Update()
    {
        Comportamiento();
    }
}
