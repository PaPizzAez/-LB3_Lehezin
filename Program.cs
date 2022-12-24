namespace LABA2
{
  static class Program
  {
    /// <summary>
    /// Главная точка входа для приложения.
    /// </summary>
    [STAThread]
    static void Main()
    {
      string dir = "C:\\StudioSave";
      if (!Directory.Exists(dir))
      {
        Directory.CreateDirectory(dir);
      }

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Screen());
    }
  }
}
