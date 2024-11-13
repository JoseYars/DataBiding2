namespace DataBiding2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //Registro rutas nav
            Routing.RegisterRoute(nameof(FormPage), typeof(FormPage));

        }
    }
}
