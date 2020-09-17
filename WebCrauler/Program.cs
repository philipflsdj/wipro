using HtmlAgilityPack;
using System;
using System.Net.Http;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace WebCrauler
{
    class Program
    {
        static void Main(string[] args)
        {
            
            GetGloboDolar();
            //GetUOLDolar();
            //GetHtmlAsync();
            Console.ReadLine();

        }
        private static void GetGloboDolar()
        {
            var dataagora = DateTime.Now;

            //Tempo de Resposta
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            //Config Html Agile Pack
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("https://valor.globo.com/valor-data/");
            //Criação Txt
            StreamWriter Dolartxt = new StreamWriter("Dolar " + DateTime.Today.ToString("MM-dd-yyyy")+ ".txt");
            //Cabeçaho
            Console.WriteLine("Cotação de " + dataagora + " Globo https://valor.globo.com/valor-data/" );
            
            //  Dólar comercial
            var nodesCom = document.DocumentNode.SelectNodes("//html/body/main/div/div/div").Where(x => x.InnerText.Contains("Dólar Comercial")).ToList();
            var dolarComecial = nodesCom[0].InnerText.Substring(19,4);
            Console.WriteLine("Dólar Comercial R$: " + dolarComecial);
            Dolartxt.WriteLine("Dólar Comercial R$: " + dolarComecial);
            //Dólar PTXA
            var nodesPTXA = document.DocumentNode.SelectNodes("//html/body/main/div/div/div").Where(x => x.InnerText.Contains("Dólar PTAX")).ToList();
            var dolarPTXA = nodesPTXA[0].InnerText.Substring(14, 4);
            Console.WriteLine("Dólar PTXA : R$" + dolarPTXA);
            Dolartxt.WriteLine("Dólar PTXA : R$" + dolarPTXA);
            //Dólar Turismo
            var nodesTurismo = document.DocumentNode.SelectNodes("//html/body/main/div/div/div").Where(x => x.InnerText.Contains("Dólar Turismo")).ToList();
            var dolarTurismo = nodesTurismo[0].InnerText.Substring(17, 4);
            Console.WriteLine("Dólar Turismo : R$" + dolarTurismo);
            Dolartxt.WriteLine("Dólar Turismo : R$" + dolarTurismo);
            //Média 
            
            //Finalização tempo de resposta
            stopwatch.Stop();
            Console.WriteLine($"Tempo passado: {stopwatch.ElapsedMilliseconds} Milessegundos");
            Dolartxt.WriteLine($"Tempo passado: {stopwatch.ElapsedMilliseconds} Milessegundos");
            Dolartxt.Close();


        }
        private static void GetUOLDolar()
        {
            #region Teste
            //Console.WriteLine("Iniciado");
            //var url = "https://valor.globo.com/valor-data/";
            //var httpClient = new HttpClient();
            //var html = httpClient.GetStringAsync(url);
            //var htmlDocument = new HtmlDocument();
            //htmlDocument.LoadHtml(url);
            //Console.WriteLine(html.Result);


            ////Gravar no TXT
            //StreamWriter escritor = new StreamWriter("nome.txt");
            //escritor.WriteLine("Teste" + html.Result);
            //escritor.Close();


            //Console.WriteLine(html.Result);
            //Console.ReadKey();
            #endregion
        }

    }
}
