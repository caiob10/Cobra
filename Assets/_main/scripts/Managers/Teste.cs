using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Teste : MonoBehaviour
{
    private Vector2Int gridPosition;
    private Vector2Int gridMoveDirection;
    private float gridMoveTimer;
    private float gridMoveTimerMax;

    //Teste git

    public Vector2Int ultimaPosicao { get; private set; }

    [SerializeField] private Maca macaViraCorpo;

    private void Awake()
    {
        gridPosition = new Vector2Int(10, 10);
        gridMoveTimerMax = 0.5f;
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = new Vector2Int(0, -1);
        
    }

    public void Movimento(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 input = context.ReadValue<Vector2>();
            Vector2Int novaDirecao = Vector2Int.RoundToInt(input);

            
            if (gridMoveDirection.x != 0 && novaDirecao.x != 0)
                return;

            if (gridMoveDirection.y != 0 && novaDirecao.y != 0)
                return;

            
            gridMoveDirection = novaDirecao;
        }
    }

    private void Update()
    {
        if(gridPosition.x < -17.24)
        {
            gridPosition = new Vector2Int(17, gridPosition.y);
        }
        else if (gridPosition.x > 17.24)
        {
            gridPosition = new Vector2Int(-17, gridPosition.y);
        }

        else if (gridPosition.y < -9.5)
        {
            gridPosition = new Vector2Int(gridPosition.x, 9);
        }
        else if (gridPosition.y > 9.5)
        {
            gridPosition = new Vector2Int(gridPosition.x, -9);
        }



        transform.position = new Vector3(gridPosition.x, gridPosition.y);

        gridMoveTimer += Time.deltaTime;
        if (gridMoveTimer >= gridMoveTimerMax)
        {
            
            gridMoveTimer -= gridMoveTimerMax;

            ultimaPosicao = gridPosition;

            gridPosition += gridMoveDirection;
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Maca"))
        {
            Debug.Log("Colidiu com a maça");
            Destroy(other.gameObject);
            macaViraCorpo.nascerMaca();
            macaViraCorpo.nascerCorpo();
        }

        if (other.CompareTag("Corpo"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }




}
