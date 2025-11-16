using UnityEngine;

public class Maca : MonoBehaviour
{
    [SerializeField] private GameObject macaPrefab;
    [SerializeField] private GameObject corpoPrefab;
    [SerializeField] private Teste cabeca;

    private CorpoCobra ultimoCorpo;

    int minX = -17;
    int maxX = 17;
    int minY = -9;
    int maxY = 9;

    private void Start()
    {
        nascerMaca();
    }

    public void nascerMaca()
    {
        int x = Random.Range(minX, maxX + 1);
        int y = Random.Range(minY, maxY + 1);

        Vector3 posicao = new Vector3(x, y, 0);
        Instantiate(macaPrefab, posicao, Quaternion.identity);
    }

    public void nascerCorpo()
    {
       
        Vector2Int pos = cabeca.ultimaPosicao;
        Vector3 nascerPos = new Vector3(pos.x, pos.y, 0);

        GameObject obj = Instantiate(corpoPrefab, nascerPos, Quaternion.identity);
        CorpoCobra novoCorpo = obj.GetComponent<CorpoCobra>();

        
        novoCorpo.cabeca = cabeca;

        if (ultimoCorpo == null)
        {
            
            novoCorpo.segmentoFrente = null;
        }
        else
        {
            
            novoCorpo.segmentoFrente = ultimoCorpo;
        }

        
        ultimoCorpo = novoCorpo;
    }
}
