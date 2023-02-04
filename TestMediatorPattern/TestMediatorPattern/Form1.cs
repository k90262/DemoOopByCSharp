namespace TestMediatorPattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            QuickEntryMediator qem = new QuickEntryMediator(textBox1, listBox1);
        }
    }
}