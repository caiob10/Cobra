using UnityEngine;

public class CorpoCobra : MonoBehaviour
{
    [HideInInspector] public CorpoCobra segmentoFrente;
    [HideInInspector] public Teste cabeca;

    public Vector2Int ultimaPosicao { get; private set; }

    private float tempoDeAndar = 0.5f;
    private float tempo;

    private void Update()
    {
        tempo += Time.deltaTime;

        if (tempo >= tempoDeAndar)
        {
            tempo = 0f;

            
            Vector3 posAtual = transform.position;
            ultimaPosicao = new Vector2Int(Mathf.RoundToInt(posAtual.x),Mathf.RoundToInt(posAtual.y));

            
            Vector2Int destinoGrid;

            if (segmentoFrente != null)
            {
                
                destinoGrid = segmentoFrente.ultimaPosicao;
            }
            else
            {
                
                destinoGrid = cabeca.ultimaPosicao;
            }

            
            transform.position = new Vector3(destinoGrid.x, destinoGrid.y, 0);
        }
    }
}
