using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nosso serviços.");
            Console.ReadLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Série a seu Dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar Série");
            Console.WriteLine("2 - Inserir uma nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar Série");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada. ");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genêro que deseja inserir:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Títule da Série:");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da Série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da Série:");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }

        public static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da série:");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genêro entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Títule da Série:");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da Série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da Série:");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSeria = new Serie(id: indiceSerie, genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, atualizaSeria);

        }

        public static void ExcluirSerie()
        {
            Console.WriteLine("Digite o Id da Serie:");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        public static void VisualizarSerie()
        {
            Console.WriteLine("Digite o Id da Serie:");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }
    }
}
