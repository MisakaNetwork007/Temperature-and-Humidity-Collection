using Temperature_and_Humidity_Collection.Models;

namespace Temperature_and_Humidity_Collection
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            //ModbusClient m = new(ModbusMode.TCP,0,comPort:"COM31");
            //m.Connect();
            //m.WriteMultipleRegisters(0,[10,20,30,40,50,60]);
            //m.Dispose();

            //var t = new DBContextTest();
            //t.AddData();
            //var d = t.FindData();
            //t.UpdateData();
            //t.DeleteData();

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}