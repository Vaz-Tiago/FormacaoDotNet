using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    /// <summary>
    /// Classe que armazena as contas correntes criadas.
    /// </summary>
    public class ListaDeContaCorrentes
    {
        private ContaCorrente[] _itens;
        private int _proximaPosicao;

        public int Tamanho
        { 
            get
            {
                return _proximaPosicao;
            }
        }

        public ListaDeContaCorrentes(int capacidadeInicial = 5)
        {
            _itens = new ContaCorrente[capacidadeInicial];
            _proximaPosicao = 0;
        }

        public ContaCorrente GetItemNoIndice(int indice)
        {
            if(indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
        }

        /// <summary>
        /// Salva <see cref="ContaCorrente"/> no armazenamento do sistema
        /// </summary>
        /// <param name="item">Deve ser um Objeto <see cref="ContaCorrente"/></param>
        public void Adicionar(ContaCorrente item)
        {
            VerificaCapacidade(_proximaPosicao + 1);
            //Console.WriteLine($"Adicionando item na proxima posicao. Indice atual: {_proximaPosicao}");
            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        } 

        public void AdicionarVarios(params ContaCorrente[] itens)
        {
            foreach(ContaCorrente conta in itens)
            {
                Adicionar(conta);
            }
        }

        /// <summary>
        /// Remove <see cref="ContaCorrente"/> do armazenamento do sistema
        /// </summary>
        /// <param name="item">Deve der um objeto <see cref="ContaCorrente"/></param>
        public void Remover(ContaCorrente item)
        {
            int indiceItem = -1; // Valor padrão para item não encontrado em arrays;

            // Faz a busca pelo indice do item passado como argumento
            for (int i = 0; i < _proximaPosicao; i++)
            {
                ContaCorrente itemAtual = _itens[i];
                if (itemAtual.Equals(item))
                {
                    indiceItem = i;
                    break;
                }
            }

            // Após achar o item, define a sua posição como a posição do item seguinte
            // E assim continua, até chegar no item anterior a próxima posição
            for (int i = indiceItem; i < _proximaPosicao-1; i++)
            {
                _itens[i] = _itens[i + 1];
            }

            // Diminui o valor da proximaPosicao em 1 pois um elemento foi excluído
            // E seta como null para não ficar como valor duplicado
            _proximaPosicao--;
            _itens[_proximaPosicao] = null;
        }

        private void VerificaCapacidade(int tamanhoNecessário)
        {
            if (_itens.Length >= tamanhoNecessário)
            {
                return;
            }
            
            int novoTamanho = _itens.Length * 2;
            if(novoTamanho < tamanhoNecessário)
            {
                novoTamanho = tamanhoNecessário;
            }
            // Console.WriteLine("Aumentando a capacidade da lista");
            ContaCorrente[] novoArray = new ContaCorrente[novoTamanho];

            for(int indice = 0; indice < _itens.Length; indice++)
            {
                novoArray[indice] = _itens[indice];
                //Console.WriteLine(".");
            }

            _itens = novoArray;
        }

        // Indexador de Classe - Recuperar elementos como é feito com array
        public ContaCorrente this[int indice]
        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }
    }
}
