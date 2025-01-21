using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioJokenPo.Domain
{
    public class Jogo
    {
        public Jogo(List<Jogador> jogadores)
        {
            Jogadores = jogadores;
        }

        public List<Jogador> Jogadores { get; set; }

        public List<Jogador> Empatou()
        {
            var resultado = ResultadoEnum.Èmpate;

            foreach (var item in Jogadores) { 
                item.Resultado = resultado;
            }

            return Jogadores;
        }

        public List<Jogador> Jogar()
        {
            IDictionary<JogadasEnum, List<JogadasEnum>> combinacoes = new Dictionary<JogadasEnum, List<JogadasEnum>>()
        {
            { JogadasEnum.Pedra, new List<JogadasEnum> { JogadasEnum.Tesoura } },
            { JogadasEnum.Papel, new List<JogadasEnum> { JogadasEnum.Pedra } },
            { JogadasEnum.Tesoura, new List<JogadasEnum> { JogadasEnum.Papel } }
        };

            var jogadasDestintas = Jogadores.Select(x => x.Jogada).Distinct().Count();

            if (jogadasDestintas > 2)
                return Empatou();

            foreach (var jogada in Jogadores)
            {
                var jogadasFortes = combinacoes.Where(x => x.Key == jogada.Jogada).FirstOrDefault();

                if (jogadasFortes.Value == null)
                    throw new Exception("Jogada não encontrada!");

                var excetoMinhaJogada = Jogadores.Where(x => x.Nome != jogada.Nome).Select(x => x.Jogada).ToList();

                if (jogadasFortes.Value.Where(x => !excetoMinhaJogada.Contains(x)).Any())
                {
                    jogada.Resultado = ResultadoEnum.Perdeu;
                }
                else
                {
                    jogada.Resultado = ResultadoEnum.Ganhou;
                }

            }

            return Jogadores;
        }
    }
    public class Jogador
    {
        public Jogador(string nome, JogadasEnum jogada)
        {
            Nome = nome;
            Jogada = jogada;
        }

        public string Nome { get; set; }
        public JogadasEnum Jogada { get; set; }
        public ResultadoEnum Resultado { get; set; }
    }

    public enum JogadasEnum
    {
        Pedra = 0,
        Papel = 1,
        Tesoura = 2,
    }

    public enum ResultadoEnum
    {
        Èmpate = 0,
        Ganhou = 1,
        Perdeu = 2,
    }
}

