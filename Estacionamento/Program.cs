using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Veiculo> veiculosEstacionados = new List<Veiculo>();
        double taxaPorHora = 5.0; // Taxa de estacionamento por hora

        while (true)
        {
            Console.WriteLine("1. Estacionar veículo");
            Console.WriteLine("2. Retirar veículo");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.Write("Informe a placa do veículo: ");
                    string placa = Console.ReadLine();
                    Console.Write("Informe a hora de entrada (HH:mm): ");
                    DateTime horaEntrada = DateTime.Parse(Console.ReadLine());

                    Veiculo veiculo = new Veiculo(placa, horaEntrada);
                    veiculosEstacionados.Add(veiculo);
                    Console.WriteLine("Veículo estacionado com sucesso!");
                    break;

                case 2:
                    Console.Write("Informe a placa do veículo: ");
                    string placaSaida = Console.ReadLine();
                    DateTime horaSaida = DateTime.Now;

                    Veiculo veiculoSaida = veiculosEstacionados.Find(v => v.Placa == placaSaida);
                    if (veiculoSaida != null)
                    {
                        TimeSpan tempoEstacionado = horaSaida - veiculoSaida.HoraEntrada;
                        double taxa = Math.Ceiling(tempoEstacionado.TotalHours) * taxaPorHora;

                        Console.WriteLine($"Placa: {veiculoSaida.Placa}");
                        Console.WriteLine($"Hora de entrada: {veiculoSaida.HoraEntrada}");
                        Console.WriteLine($"Hora de saída: {horaSaida}");
                        Console.WriteLine($"Tempo estacionado: {tempoEstacionado.TotalHours} horas");
                        Console.WriteLine($"Taxa a ser paga: R${taxa}");

                        veiculosEstacionados.Remove(veiculoSaida);
                    }
                    else
                    {
                        Console.WriteLine("Veículo não encontrado no estacionamento.");
                    }
                    break;

                case 3:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}

class Veiculo
{
    public string Placa { get; set; }
    public DateTime HoraEntrada { get; set; }

    public Veiculo(string placa, DateTime horaEntrada)
    {
        Placa = placa;
        HoraEntrada = horaEntrada;
    }
}