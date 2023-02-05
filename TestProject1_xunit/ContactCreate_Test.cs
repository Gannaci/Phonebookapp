using Newtonsoft.Json;
using test.Models;
using test.Services;

namespace TestProject1_xunit
{
    public class ContactCreate_Test
    {
        [Fact]
        public void AddContact_SavesContactToFile()
        {
            // Arrange
            string tempFilePath = Path.GetTempFileName();
            Menu menu = new contact(tempFilePath);

            // Act
            ContactCreate contact = new ContactCreate { FirstName = "sebbe", PhoneNumber = "31123123" };
            ContactCreate.AddContact(contact);

            // Assert
            string json = File.ReadAllText(tempFilePath);
            List<ContactCreate> contacts = JsonConvert.DeserializeObject<List<ContactCreate>>(json);
            Assert.Single(contacts, c => c.FirstName == contact.FirstName && c.PhoneNumber == contact.PhoneNumber);
        }
    }
}