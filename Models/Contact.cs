using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ContactBook.Utility;

namespace WPF_ContactBook.Models
{
	public class Contact : ObservableObject
	{
		private string firstName;
		public string FirstName
		{
			get => firstName;
			set => OnPropertyChanged(ref firstName, value);
		}

		private string[] phoneNumbers;
		public string[] PhoneNumbers
		{
			get => phoneNumbers;
			set => OnPropertyChanged(ref phoneNumbers, value);
		}

		private string[] emails;
		public string[] Emails
		{
			get => emails;
			set => OnPropertyChanged(ref emails, value);
		}

		private string[] locations;
		public string[] Locations
		{
			get => locations;
			set => OnPropertyChanged(ref locations, value);
		}

		private bool isFavourite;
		public bool IsFavourite
		{
			get => isFavourite;
			set => OnPropertyChanged(ref isFavourite, value);
		}

		private string imagePath;
		public string ImagePath
		{
			get => imagePath;
			set => OnPropertyChanged(ref imagePath, value);
		}
	}
}
