using System;
using System.IO;
namespace ApiCine.Api.LogErrores{
public class LogErrores : ILogErrores
{
    private readonly string archivoLogs;

    public LogErrores()
    {
        var RutadirectorioLogs = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");//se crea la ruta del directorio que se llamara Logs donde estos se almacenaran en la raiz del contendor en este caso
        Directory.CreateDirectory(RutadirectorioLogs); //crea el directorio a traves de la ruta que hemos configurado arriba
        archivoLogs = Path.Combine(RutadirectorioLogs, "ApiPeliculasLog.txt"); //crea la ruta completa ahora con el fichero incluido donde se guardaran los logs
    }

    public void LogError(string message)
    {
        string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} error: {message}\n";
        File.AppendAllText(archivoLogs, logMessage);
    }
}}