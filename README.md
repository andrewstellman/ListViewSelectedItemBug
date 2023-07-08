# ListViewSelectedItemBug

This is code to reproduce a bug with the .NET MAUI ListView, where the SelectedItem property retains a reference to an object even after the item has been removed or the ListView has been cleared.

![image](https://github.com/andrewstellman/ListViewSelectedItemBug/assets/7516297/1a4c83a1-241c-4680-856e-05395a12b46a)

How to reproduce:
1. Build and run the ListViewSelectedItemBug app
3. Select a measurement and click **Get Selected Item** to fetch ListView.SelectedItem and write it to the Label.
   * The event handler for that button checks if ListView.SelectedItem returns a Measurement. Since no item is selected, it does not, so it updates the label with "No selected measurement found"
2. Click the **Add Random Measurement** button to add several random measurements to the ListView.
3. Select a measurement and click **Get Selected Item** to fetch ListView.SelectedItem and write it to the Label.
4. Do one of the following:
   * Click a different measurement and click **Remove Selected Item** to remove it
   * Click **Clear** to clear the list
6. Click **Get Selected Item** to fetch ListView.SelectedItem and write it to the Label.

**Expected:** ListView.SelectedItem should not return a measurement, since none is selected, so the label should be updated with "No selected measurement found"

**Actual:** ListView.SelectedItem keeps a reference to the measurement even after it's removed from the ListView or the ListView is cleared, so the label is updated with the measurement.
