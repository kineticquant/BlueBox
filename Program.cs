namespace BlueBox
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            // to customize application configuration such as high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Main());
        }
    }
}