using Newtonsoft.Json;
using Refit;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace GetCep
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var cepClient = RestService.For<ICepApiService>("http://viacep.com.br");
                
                Console.WriteLine("Informe seu CEP:");
                string cepInformado = Console.ReadLine().ToString();
                
                Console.WriteLine("\nConsultando informações do CEP: " + cepInformado);

                var adrress = await cepClient.GetAddressAsync(cepInformado);

                Console.WriteLine("");

                foreach (PropertyInfo propertyInfo in adrress.GetType().GetProperties())
                {
                    Console.WriteLine(propertyInfo.Name + ": " + propertyInfo.GetValue(adrress, null));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Erro na consulta de CEP: " + e.Message);
            }
        }
    }
}
