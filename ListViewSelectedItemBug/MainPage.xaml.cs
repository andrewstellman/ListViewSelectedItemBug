using System.Collections.ObjectModel;

namespace ListViewSelectedItemBug;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
    }

    private void Add_Clicked(object sender, EventArgs e)
    {
        if (Resources["collection"] is ObservableCollection<Measurement> collection)
            collection.Add(new Measurement() { Length = Random.Shared.Next() });
    }

    private void Remove_Clicked(object sender, EventArgs e)
    {
        if (Resources["collection"] is ObservableCollection<Measurement> collection
            && ListView.SelectedItem is Measurement measurement)
            collection.Remove(measurement);
    }

    private void Clear_Clicked(object sender, EventArgs e)
    {
        if (Resources["collection"] is ObservableCollection<Measurement> collection)
            collection.Clear();
    }

    private void GetSelectedItem_Clicked(object sender, EventArgs e)
    {
        if (ListView.SelectedItem is Measurement measurement)
            SelectedItem.Text = $"The selected mesurement is {measurement}";
        else
            SelectedItem.Text = "No selected mesurement found";
    }
}

