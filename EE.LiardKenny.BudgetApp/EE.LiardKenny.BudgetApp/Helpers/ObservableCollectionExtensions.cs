using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EE.LiardKenny.BudgetApp.Helpers
{
    public static class ObservableCollectionExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            var observableCollection = new ObservableCollection<T>();

            foreach (var item in collection)
            {
                observableCollection.Add(item);
            }

            return observableCollection;
        }
    }
}
