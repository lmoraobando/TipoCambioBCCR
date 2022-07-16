// See https://aka.ms/new-console-template for more information
using System.Xml;

Console.WriteLine("Hello, World!");
XmlDocument xmlDocument = new XmlDocument();

using (var client = new ServiceReference1.wsindicadoreseconomicosSoapClient(ServiceReference1.wsindicadoreseconomicosSoapClient.EndpointConfiguration.wsindicadoreseconomicosSoap))
{
    string Date = DateTime.Now.ToString("dd/MM/yyyy");

    var test = client.ObtenerIndicadoresEconomicosXMLAsync("317", Date, Date, "Leonardo Mora Obando", "N", "<email>", "<token>");
    test.GetAwaiter();
    var res = test.GetAwaiter().GetResult();
    xmlDocument.LoadXml(res);
    string xpath = "Datos_de_INGC011_CAT_INDICADORECONOMIC/INGC011_CAT_INDICADORECONOMIC/NUM_VALOR";

    XmlNode node = xmlDocument.SelectSingleNode(xpath);

    Console.WriteLine("Tipo de cambio de hoy es: " + node?.InnerText.ToString());
};
