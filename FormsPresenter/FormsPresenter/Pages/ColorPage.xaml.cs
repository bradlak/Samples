using Xamarin.Forms;

namespace FormsPresenter
{
    public partial class ColorPage : ContentPage
    {
        public ColorPage()
        {
            InitializeComponent();
        }

        public void SetProperties(NamedColor namedColor)
        {
            label.Text = namedColor.Name + " page";
            Title = namedColor.Name;
            box.Color = namedColor.Color;
        }
    }
}
