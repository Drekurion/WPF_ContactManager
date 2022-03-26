using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ContactBook.Services;
using WPF_ContactBook.Utility;
using WPF_ContactBook.ViewModels;

namespace WPF_ContactBook
{
	public class AppViewModel : ObservableObject
	{
		private object currentView;
		public object CurrentView
		{
			get { return currentView; }
			set { OnPropertyChanged(ref currentView, value); }
		}

		private BookViewModel bookVM;
		public BookViewModel BookVM
		{
			get { return bookVM; }
			set { OnPropertyChanged(ref bookVM, value); }
		}

		public AppViewModel()
		{
			var dataService = new MockDataService();
			BookVM = new BookViewModel(dataService);
			CurrentView = BookVM;
		}
	}
}
