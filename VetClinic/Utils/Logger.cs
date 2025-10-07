namespace VetClinic.Utils;

public static class Logger
{
    // Ruta del archivo de log (puedes cambiarla si lo deseas)
    private static readonly string logFile = "error_log.txt";

    /// <summary>
    /// Registra un mensaje de error en un archivo de texto y lo muestra en consola.
    /// </summary>
    /// <param name="message">Mensaje de error a registrar</param>
    public static void LogError(string message)
    {
        string fullMessage = $"[{DateTime.Now}] ERROR: {message}";
            
        // Mostrar en consola
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(fullMessage);
        Console.ResetColor();

        // Guardar en archivo
        try
        {
            File.AppendAllText(logFile, fullMessage + Environment.NewLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Logger Error] No se pudo escribir en el archivo de log: {ex.Message}");
        }
    }

    /// <summary>
    /// Muestra en consola todo el contenido del log de errores.
    /// </summary>
    public static void ShowLog()
    {
        try
        {
            if (!File.Exists(logFile))
            {
                Console.WriteLine("No hay errores registrados aún.");
                return;
            }

            Console.WriteLine("\n--- Error Log ---");
            string content = File.ReadAllText(logFile);
            Console.WriteLine(content);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"No se pudo leer el archivo de log: {ex.Message}");
        }
    }
}