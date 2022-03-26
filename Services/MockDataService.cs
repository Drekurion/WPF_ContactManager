using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ContactBook.Models;

namespace WPF_ContactBook.Services
{
	public class MockDataService : IContactDataService
	{
		private IEnumerable<Contact> contacts;
		public MockDataService()
		{
			contacts = new List<Contact>()
			{
				new Contact
				{
					FirstName = "John Doe",
					PhoneNumbers = new string[]
					{
						"555-111-1111",
						"555-222-2222"
					},
					Emails = new string[]
					{
						"Johndoe@personal.com",
						"Johndoe@business.com"
					},
					Locations = new string[]
					{
						"111 Fake Street",
						"222 Fake Ave"
					}
				},
				new Contact
				{
					FirstName = "Jane Doe",
					PhoneNumbers = new string[]
					{
						"555-333-3333",
						"555-444-4444"
					},
					Emails = new string[]
					{
						"Janedoe@personal.com",
						"Janedoe@business.com"
					},
					Locations = new string[]
					{
						"333 Fake Street",
						"444 Fake Ave"
					}
				},
			};
		}
		public IEnumerable<Contact> GetContacts()
		{
			return contacts;
		}

		public void Save(IEnumerable<Contact> contacts)
		{
			this.contacts = contacts;
		}
	}
}
