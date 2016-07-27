namespace Simple.Wpf.Tabs.Helpers
{
    public static class ColumnHelper
    {
        public static string DisplayName(string columnName)
        {
            return columnName.Replace(Constants.UI.Grids.ColumnNameSeperator,
                Constants.UI.Grids.ColumnNameDisplaySeperator);
        }
    }
}