namespace Phonebook.Domain.Command.Input
{
    public class CreateContactOwnerCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
