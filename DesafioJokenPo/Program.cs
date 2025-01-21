// See https://aka.ms/new-console-template for more information
using DesafioJokenPo.Domain;

Jogador jogador = new Jogador("Rafael", JogadasEnum.Tesoura);
Jogador jogador2 = new Jogador("Alanis", JogadasEnum.Pedra);
Jogador jogador3 = new Jogador("Milene", JogadasEnum.Tesoura);

var jogadores = new List<Jogador>();

jogadores.Add(jogador);
jogadores.Add(jogador2);
jogadores.Add(jogador3);

Jogo jogo = new Jogo(jogadores);

var resultado = jogo.Jogar();

foreach (var result in resultado)
{
    Console.WriteLine($"o jogador {result.Nome} teve o resultado: {result.Resultado.ToString()}");
}

Console.ReadLine();
