namespace Contact_MSTest
{
    [TestClass]
    public class Menu_Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            List<string> contacts = new List<string>();
            string newContact = "Sebbe";

            // Act
            contacts.Add(newContact);

            // Assert
            Assert.IsTrue(contacts.Contains(newContact));
        }
    }
}