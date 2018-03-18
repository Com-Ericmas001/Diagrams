namespace Com.Ericmas001.Diagrams.Xaml.Ressources
{
    public partial class ElementsDataTemplate
    {
        //Expose it as singleton to avoid multiple instances of this dictionary
        public static ElementsDataTemplate Instance { get; } = new ElementsDataTemplate();

        public ElementsDataTemplate()
        {
            InitializeComponent();
        }
    }
}