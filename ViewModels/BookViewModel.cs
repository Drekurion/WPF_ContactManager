using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_ContactBook.Services;
using WPF_ContactBook.Utility;

namespace WPF_ContactBook.ViewModels
{
	public class BookViewModel : ObservableObject
	{
		private IContactDataService service;

		private ContactsViewModel contactsVM;
		public ContactsViewModel ContactsVM
		{
			get => contactsVM;
			set => OnPropertyChanged(ref contactsVM, value);
		}

		public ICommand LoadContactsCommand { get; private set; }
		public ICommand LoadFavouritesCommand { get; private set; }

		public BookViewModel(IContactDataService service)
		{
			ContactsVM = new ContactsViewModel(service);
			this.service = service;
			LoadContactsCommand = new RelayCommand(LoadContacts);
			LoadFavouritesCommand = new RelayCommand(LoadFavourites);
		}

		private void LoadContacts()
		{

			ContactsVM.LoadContacts(service.GetContacts());
		}

		private void LoadFavourites()
		{
			var favorites = service.GetContacts().Where(c => c.IsFavourite);
			ContactsVM.LoadContacts(favorites);
		}
	}
}
