
namespace JogoDaVelha
{
    class JogoDaVelhaclass
    {
        private bool fimDejogo; /// Variável para definir os parâmetros de fim de jogo;
        private char[] posicoes; /// Pocições da matriz;
        private char vez;
        private int quantidadepreenchida;
        
        public JogoDaVelhaclass()
        {
            fimDejogo = false;  
            posicoes = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            vez = 'X';
            quantidadepreenchida = 0;
            
        }
        public void Iniciar()
        {
            while (!fimDejogo) //Enquanto não for fim de jogo acontece o jogo;
            {
                RenderizarTabela();
                LerEscolhaDoUsuario();
                RenderizarTabela();
                VerificarFimDeJogo();
                MudarVez();

            }
        }

        private void LerEscolhaDoUsuario()
        {
            Console.WriteLine($"Agora é a vez de {vez}, entre uma posição de 1 a 9 que esteja disponível na tabela!");
            bool conversao = int.TryParse(Console.ReadLine(), out int posicaoescolhida);
            while(!conversao || !ValidarEscolhaUsuario(posicaoescolhida))
            {
                Console.WriteLine("O campo escolhido é inválido, por favor digite um número entre 1 e 9 que esteja disponível na tabela.");
                conversao = int.TryParse(Console.ReadLine(), out posicaoescolhida);
            }
            PreencherEscolha(posicaoescolhida);
        }
        private void PreencherEscolha(int posicaoescolhida)
        {
            int indice = posicaoescolhida - 1;
            posicoes[indice] = vez;
            quantidadepreenchida++;
        }

        private bool ValidarEscolhaUsuario(int posicaoescolhida)
        {
            var indice = posicaoescolhida - 1;

            return posicoes[indice] != 'O' && posicoes[indice] != 'X';
            

        }
        private void RenderizarTabela()
        {
            Console.Clear();
            Console.WriteLine(ObterTabela());
        }

        private void VerificarFimDeJogo()
        {
            if (quantidadepreenchida < 5)
                return;

            if(ExisteVitoriaHorizontal() || ExisteVitoriaVertical() || ExisteVitoriaDiagonal())
            {
                fimDejogo = true;
                Console.WriteLine($"Fim de jogo!!! Vitória de {vez}");
                return;
            }

            if (quantidadepreenchida is 9)
            {
                fimDejogo = true;
                Console.WriteLine("Fim de Jogo!!! EMPATE");
            }
        }
        private bool ExisteVitoriaHorizontal()
        {
            bool VitoriaLinha1 = posicoes[0] == posicoes[3] && posicoes[0] == posicoes[6];
            bool VitoriaLinha2 = posicoes[1] == posicoes[4] && posicoes[1] == posicoes[7];
            bool VitoriaLinha3 = posicoes[2] == posicoes[5] && posicoes[2] == posicoes[8];

            return VitoriaLinha1 || VitoriaLinha2 || VitoriaLinha3;
        }
        private bool ExisteVitoriaVertical()
        {
            bool VitoriaLinha1 = posicoes[0] == posicoes[1] && posicoes[0] == posicoes[2];
            bool VitoriaLinha2 = posicoes[3] == posicoes[4] && posicoes[3] == posicoes[5];
            bool VitoriaLinha3 = posicoes[6] == posicoes[7] && posicoes[6] == posicoes[8];

            return VitoriaLinha1 || VitoriaLinha2 || VitoriaLinha3;
        }
        private bool ExisteVitoriaDiagonal()
        {
            bool VitoriaLinha1 = posicoes[0] == posicoes[4] && posicoes[0] == posicoes[8];
            bool VitoriaLinha2 = posicoes[2] == posicoes[4] && posicoes[2] == posicoes[6];

            return VitoriaLinha1 || VitoriaLinha2;
        }
        private void MudarVez()
        {
            vez = vez == 'X' ? 'O' : 'X';

            // OR
            //if (vez == 'X')
            //    vez = 'O';
            //else
            //    vez = 'X';
        }
        private string ObterTabela()
        {
            return $"__{posicoes[0]}__|__{posicoes[1]}__|__{posicoes[2]}__\n" +
                   $"__{posicoes[3]}__|__{posicoes[4]}__|__{posicoes[5]}__\n" +
                   $"  {posicoes[6]}  |  {posicoes[7]}  |  {posicoes[8]}  \n\n";

        }
    }
}
