using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_ContactBook.Models;
using WPF_ContactBook.Services;
using WPF_ContactBook.Utility;

namespace WPF_ContactBook.ViewModels
{
	public class ContactsViewModel : ObservableObject
	{
		private Contact selectedContact;
		public Contact SelectedContact
		{
			get => selectedContact;
			set => OnPropertyChanged(ref selectedContact, value);
		}

		private bool isEditMode;
		public bool IsEditMode
		{
			get => isEditMode;
			set
			{
				OnPropertyChanged(ref isEditMode, value);
				OnPropertyChanged("IsDisplayMode");
			}
		}

		public bool IsDisplayMode
		{
			get { return !isEditMode; }
		}

		private IEnumerable<Contact> contacts;
		public ObservableCollection<Contact> Contacts { get; private set; }

		public ICommand EditCommand { get; private set; }
		public ICommand SaveCommand { get; private set; }
		public ICommand UpdateCommand { get; private set; }

		private IContactDataService dataService;

		public ContactsViewModel(IContactDataService dataService)
		{
			this.dataService = dataService;
			this.contacts = dataService.GetContacts();

			EditCommand = new RelayCommand(Edit, CanEdit);
			SaveCommand = new RelayCommand(Save, IsEdit);
			UpdateCommand = new RelayCommand(Update);
		}

		private void Update()
		{
			dataService.Save(contacts);
		}

		private void Save()
		{
			dataService.Save(contacts);
			IsEditMode = false;
			OnPropertyChanged("SelectedContact");
		}

		private bool IsEdit()
		{
			return IsEditMode;
		}

		private bool CanEdit()
		{
			if(SelectedContact == null)
			{
				return false;
			}
			return !IsEditMode;
		}

		private void Edit()
		{
			IsEditMode = true;
		}

		public void LoadContacts(IEnumerable<Contact> contacts)
		{
			Contacts = new ObservableCollection<Contact>(contacts);
			OnPropertyChanged("Contacts");
		}
	}
}
